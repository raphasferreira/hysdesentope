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
import { clienteAPIData } from 'src/static-data/clientesAPI';
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
import { ClienteModel } from 'src/app/_models/ClienteModel';
import { predefinedCountries } from './Paises';
import { environment } from 'src/environments/environment';

export interface CountryState {
  name: string;
  population: string;
  flag: string;
}

@Component({
  selector: 'vex-cliente-tela-edit',
  templateUrl: './cliente-tela-edit.component.html',
  styleUrls: ['./cliente-tela-edit.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class ClienteTelaEditComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  labelBotao:string='Adiconar Cliente';
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
      label: 'Nome',
      property: 'Celular',
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
      label: 'País',
      property: 'pais',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'celular',
      property: 'celular',
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
      label: '',
      property: 'menu',
      type: 'button',
      cssClasses: ['text-secondary', 'w-10']
    },
  ];

  form: FormGroup;
  dtNascimento = undefined;
  urlTela = 'clientes';

  placeholder = "Selecione o País";

  defaultValue: Country = {
    name: 'Portugal',
    alpha2Code: 'PT',
    alpha3Code: 'PRT',
    numericCode: '620',
  }

  editar = false;
  pais: Country = this.defaultValue;
  clienteSelecionado = new ClienteModel();
  predefinedCountries = predefinedCountries;
  constructor(private cd: ChangeDetectorRef,
              private router: Router,
              private fb: FormBuilder, 
              private commomService: CommomService,
              private snackbar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.iniciarFormVazio();
    
    this.clienteSelecionado = JSON.parse(localStorage.getItem('clienteSelecionado')) as ClienteModel;
    this.clienteSelecionado? this.iniciarFormEditar() : this.iniciarFormVazio();
    
  }

  iniciarFormVazio(){
    this.form = this.fb.group({
      nome: ["", [Validators.required]],
      nif: ["", Validators.required],
      endereco: [""],
      numeroCasa: [""],
      pais: ["", Validators.required],
      cidade: [""],
      usuario: ["", Validators.required],
      senha: ["", Validators.required],
      codPostal: [""],
      telefone: [""],
      celular: ["", Validators.required],
      moeda: [""],
      email: [""],
      site: [""]
    });
  }

  iniciarFormEditar(){
    this.form = this.fb.group({
      nome: [this.clienteSelecionado.nome, [Validators.required]],
      nif: [this.clienteSelecionado.nif, Validators.required],
      endereco: [this.clienteSelecionado.endereco],
      pais: [this.clienteSelecionado.pais, Validators.required],
      cidade: [this.clienteSelecionado.cidade],
      usuario: [this.clienteSelecionado.usuario, Validators.required],
      senha: ["", Validators.required],
      celular: [this.clienteSelecionado.celular, Validators.required],
      moeda: [this.clienteSelecionado.moeda],
      email: [this.clienteSelecionado.email],
    });
  }

  onCountrySelected(event: Pais) {    
    
  }

  getDate(event= new Date()){
    let date: Date = new Date(`${event}`);
    this.dtNascimento = `${date.getFullYear()}` + `-${date.getMonth()+1}-` + `${date.getDay}`
  }

  
  montarBody(){
    if(this.editar){
      return this.clienteSelecionado;
    }else{
      return {
        nome: this.form.get('nome').value,
        companyTaxID: this.form.get('companyTaxID').value,
        endereco: this.form.get('endereco').value,
        numeroCasa: this.form.get('numeroCasa').value,
        pais: this.form.get('pais').value,
        dsPais: this.form.get('dsPais').value,
        cidade: this.form.get('cidade').value,
        usuario: this.form.get('usuario').value,
        moeda: this.form.get('moeda').value,
        dsMoeda: this.form.get('dsMoeda').value,
        telefone: this.form.get('telefone').value,
        celular: this.form.get('celular').value,
        site: this.form.get('site').value,
        criadoPor: this.form.get('criadoPor').value,
        email: this.form.get('email').value,
      }
    }
  }

  salvar(){
    const body: any = this.montarBody()

    this.commomService.post(`${environment.clientes}`, body)
    .subscribe(()=> {
      this.iniciarFormVazio();
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_CLIENTE_SUCESSO, 'Close', { duration: 6000 }): 
      this.snackbar.open(MessagesSnackBar.CRIAR_CLIENTE_SUCESSO, 'Close', { duration: 6000 });
    },
    (error) => {
      console.log(error.message);
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_CLIENTE_ERRO, 'Close', { duration: 6000 }):
      this.snackbar.open(MessagesSnackBar.CRIAR_CLIENTE_ERRO, 'Close', { duration: 6000 });
    });
  }

  toggleVisibility() {
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

  tableData = clienteAPIData;


  toggleStar(id: Contact['id']) {
    const contact = this.tableData.find(c => c.id === id);

    if (contact) {
      contact.starred = !contact.starred;
    }
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Adiconar Cliente'?'Voltar Lista':'Adiconar Cliente';
   
  }
}

