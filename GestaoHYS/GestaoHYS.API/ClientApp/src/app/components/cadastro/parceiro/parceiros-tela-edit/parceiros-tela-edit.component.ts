import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import icVisibility from '@iconify/icons-ic/twotone-visibility';
import icVisibilityOff from '@iconify/icons-ic/twotone-visibility-off';
import icSmartphone from '@iconify/icons-ic/twotone-smartphone';
import icPerson from '@iconify/icons-ic/twotone-person';
import icArrowDropDown from '@iconify/icons-ic/twotone-arrow-drop-down';
import icMenu from '@iconify/icons-ic/twotone-menu';
import icCamera from '@iconify/icons-ic/twotone-camera';
import icPhone from '@iconify/icons-ic/twotone-phone';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { debounceTime, map, startWith } from 'rxjs/operators';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import format_list_bulleted from '@iconify/icons-ic/format-list-bulleted'
import icEdit from '@iconify/icons-ic/twotone-edit';
import icClose from '@iconify/icons-ic/twotone-close';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { stagger60ms } from 'src/@vex/animations/stagger.animation';
import { Router } from '@angular/router';
import { CommomService } from 'src/app/services/commom.service';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import { Pais } from 'src/app/_models/Pais';
import { Country } from '@angular-material-extensions/select-country';
import { Contact } from 'src/static-data/contact';
import { Parceiro } from 'src/app/_models/Parceiro';
import { environment } from 'src/environments/environment';
import { EventEmitterService } from 'src/app/services/event.service';

export interface CountryState {
  name: string;
  population: string;
  flag: string;
}

@Component({
  selector: 'vex-parceiros-tela-edit',
  templateUrl: './parceiros-tela-edit.component.html',
  styleUrls: ['./parceiros-tela-edit.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class ParceirosTelaEditComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  labelBotao:string='Adiconar Parceiro';
  searchCtrl = new FormControl();

  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  @Input() boolGeralCliente: boolean;
  selectCtrl: FormControl = new FormControl();
  inputType = 'password';
  visible = false;

  icPhone = icPhone;
  icCamera = icCamera;
  icMenu = icMenu;
  icArrowDropDown = icArrowDropDown;
  icSmartphone = icSmartphone;
  icPerson = icPerson;
  icVisibility = icVisibility;
  icVisibilityOff = icVisibilityOff;
  icMoreVert = icMoreVert;
  format_list_bulleted =format_list_bulleted;
  icEdit = icEdit;


  stateCtrl = new FormControl();
  states: CountryState[] = [
    {
      name: 'Arkansas',
      population: '2.978M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Arkansas.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg'
    },
    {
      name: 'California',
      population: '39.14M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_California.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/0/01/Flag_of_California.svg'
    },
    {
      name: 'Florida',
      population: '20.27M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Florida.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg'
    },
    {
      name: 'Texas',
      population: '27.47M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Texas.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg'
    }
  ];
  filteredStates$ = this.stateCtrl.valueChanges.pipe(
    startWith(''),
    map(state => state ? this.filterStates(state) : this.states.slice())
  );


  accountFormGroup: FormGroup;
  passwordFormGroup: FormGroup;
  confirmFormGroup: FormGroup;

  verticalAccountFormGroup: FormGroup;
  verticalPasswordFormGroup: FormGroup;
  verticalConfirmFormGroup: FormGroup;

  phonePrefixOptions = ['+1', '+27', '+44', '+49', '+61', '+91'];

  passwordInputType = 'password';


  tableColumns: TableColumn<any>[] = [
    {
      label: 'Entidade',
      property: 'entidade',
      type: 'text',
      cssClasses: ['font-medium']
    },
    {
      label: 'Nome',
      property: 'name',
      type: 'text',
      cssClasses: ['font-medium']
    },
    {
      label: 'NIF',
      property: 'companyTaxID',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Termo de Pesquisa',
      property: 'termoPesquisa',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'País',
      property: 'pais',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Telefone',
      property: 'phone',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'EMAIL',
      property: 'electronicMail',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Grupo',
      property: 'grupo',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: '',
      property: 'menu',
      type: 'button',
      cssClasses: ['text-secondary', 'w-10']
    },
  ];

  form: FormGroup;
  dtNascimento = undefined;

  placeholder = "Selecione o País";

  defaultValue: Country = {
    name: 'Portugal',
    alpha2Code: 'PT',
    alpha3Code: 'PRT',
    numericCode: '620',
  }
  parceiroSelecionado = new Parceiro();
  editar = false;
  predefinedCountries = null;

  constructor(private cd: ChangeDetectorRef,
              private router: Router,
              private fb: FormBuilder, 
              private commomService: CommomService,
              private snackbar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    EventEmitterService.get('ParceiroAlterado').subscribe(()=>this.enviarParceiro());
    this.iniciarFormVazio();
    
    this.parceiroSelecionado = JSON.parse(localStorage.getItem('parceiroSelecionado')) as Parceiro;
    this.parceiroSelecionado? this.iniciarFormEditar() : this.iniciarFormVazio();
  }
  iniciarFormEditar(){
    this.editar = true;
    this.form = this.fb.group({
      nome: [this.parceiroSelecionado.nome, [Validators.required]],
      nif: [this.parceiroSelecionado.nif, Validators.required],
      endereco: [this.parceiroSelecionado.endereco],
      dataNascimento: [this.parceiroSelecionado.dtNascimento, Validators.required],
      telefone: [this.parceiroSelecionado.telefone, Validators.required],
      email: [this.parceiroSelecionado.email],
      dsServico: [this.parceiroSelecionado.dsServico, Validators.required],
      pais: [this.parceiroSelecionado.parceiroPais, Validators.required]
    });
  }
  iniciarFormVazio(){
    this.form = this.fb.group({
      nome: ["", [Validators.required]],
      nif: ["", Validators.required],
      endereco: [""],
      dataNascimento: ["", Validators.required],
      telefone: ["", Validators.required],
      email: [""],
      dsServico: ["", Validators.required],
      pais: [this.defaultValue]
    });
  }

  
  onCountrySelected($event: Pais) {
    console.log($event);
  }

  getDate(event= new Date()){
    let date: Date = new Date(`${event}`);
    this.dtNascimento = `${date.getFullYear()}` + `-${date.getMonth()+1}-` + `${date.getDay}`
  }

  montarBody(){
      return {
          id: this.editar? this.parceiroSelecionado.id: undefined,
          nome: this.form.get('nome').value,
          nif: this.form.get('nif').value.toString(),
          endereco: this.form.get('endereco').value,
          dtNascimento: "2021-05-12T02:04:52.505Z",
          telefone: this.form.get('telefone').value,
          email: this.form.get('email').value,
          dsServico: this.form.get('dsServico').value,
          parceiroPais: this.defaultValue
      }
  }

  enviarParceiro(){
    this.editar? this.alterar() : this.salvar();
  }

  alterar(){
    let body: any = this.montarBody()
    body.parceiroPais.id = this.parceiroSelecionado.parceiroPaisId
    console.log(body);
    
    this.commomService.put(`${environment.parceiros}`, body)
    .subscribe(()=> {
      this.snackbar.open(MessagesSnackBar.EDITAR_PARCEIRO_SUCESSO, 'Close', { duration: 6000 })
      EventEmitterService.get('buscarParceiros').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackbar.open(MessagesSnackBar.EDITAR_PARCEIRO_ERRO, 'Close', { duration: 6000 })
    });
  }

  salvar(){
    const body: any = this.montarBody()

    if(body.nome)this.commomService.post(`${environment.parceiros}`, body)
    .subscribe(()=> {
      this.iniciarFormVazio();
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_PARCEIRO_SUCESSO, 'Close', { duration: 6000 }): 
      this.snackbar.open(MessagesSnackBar.CRIAR_PARCEIRO_SUCESSO, 'Close', { duration: 6000 });
      EventEmitterService.get('trocarTela').emit();
      EventEmitterService.get('buscarParceiros').emit();
    },
    (error) => {
      console.log(error.message);
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_PARCEIRO_ERRO, 'Close', { duration: 6000 }):
      this.snackbar.open(MessagesSnackBar.CRIAR_PARCEIRO_ERRO, 'Close', { duration: 6000 });
    });
  }


  togglePassword() {
    if (this.visible) {
      this.inputType = 'password';
      this.visible = false;
      this.cd.markForCheck();
    } else {
      this.inputType = 'text';
      this.visible = true;
      this.cd.markForCheck();
    }
  }

  filterStates(name: string) {
    return this.states.filter(state => state.name.toLowerCase().indexOf(name.toLowerCase()) === 0);
  }

  
  showPassword() {
    this.passwordInputType = 'text';
    this.cd.markForCheck();
  }

  hidePassword() {
    this.passwordInputType = 'password';
    this.cd.markForCheck();
  }

  submit() {
    this.snackbar.open('Hooray! You successfully created your account.', null, {
      duration: 5000
    });
  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(MailComposeComponent, {
    //   width: '70%',
      
    // });

    //this.trocarTela();
  }


  toggleStar(id: Contact['id']) {
    // const contact = this.tableData.find(c => c.id === id);

    // if (contact) {
    //   contact.starred = !contact.starred;
    // }
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Adiconar Parceiro'?'Voltar Lista':'Adiconar Parceiro';
   
  }

  result: string;

  openDialog() {
    // this.dialog.open(DialogWithTableComponent, {
    //   disableClose: false,
    //   width: '800px'
    // }).afterClosed().subscribe(result => {
    //   this.result = result;
    // });
  }
}


