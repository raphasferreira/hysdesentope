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
import { Empresa } from 'src/app/_models/Empresa';
import { Parceiro } from 'src/app/_models/Parceiro';
import { environment } from 'src/environments/environment';
import { EventEmitterService } from 'src/app/services/event.service';

export interface CountryState {
  name: string;
  population: string;
  flag: string;
}

@Component({
  selector: 'vex-empresa-tela-edit',
  templateUrl: './empresa-tela-edit.component.html',
  styleUrls: ['./empresa-tela-edit.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class EmpresaTelaEditComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  labelBotao:string='Adiconar Empresa';
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
  urlTela = 'empresas';

  placeholder = "Selecione o País";

  defaultValue: Country = {
    name: 'Portugal',
    alpha2Code: 'PT',
    alpha3Code: 'PRT',
    numericCode: '620',
  }
  empresaSelecionada = new Empresa();
  editar = false;

  constructor(private cd: ChangeDetectorRef,
              private router: Router,
              private fb: FormBuilder, 
              private commomService: CommomService,
              private snackbar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    EventEmitterService.get('EmpresaAlterada').subscribe(()=>this.enviarEmpresa());
    this.iniciarFormVazio();
      
    this.empresaSelecionada = JSON.parse(localStorage.getItem('empresaSelecionada')) as Empresa;
    this.empresaSelecionada? this.iniciarFormEditar() : this.iniciarFormVazio();
    console.log(this.empresaSelecionada);
  
  }

  iniciarFormEditar(){
    this.editar = true;
    this.form = this.fb.group({
      nome: [this.empresaSelecionada.nome, [Validators.required]],
      nipc: [this.empresaSelecionada.nipc, Validators.required],
      endereco: [this.empresaSelecionada.endereco],
      razaoSocial: [this.empresaSelecionada.razaoSocial, Validators.required],
      contato: [this.empresaSelecionada.contato, Validators.required],
      email: [this.empresaSelecionada.email],
      dsServico: [this.empresaSelecionada.dsServico, Validators.required],
  });
  }
  iniciarFormVazio(){
    this.form = this.fb.group({
      nome: ["", [Validators.required]],
      nipc: ["", Validators.required],
      endereco: [""],
      razaoSocial: ["", Validators.required],
      contato: ["", Validators.required],
      email: [""],
      dsServico: ["", Validators.required],
  });
  }
  
  montarBody(){
      return {
        id: this.editar? this.empresaSelecionada.id : undefined,
        nome: this.form.get('nome').value,
        nipc: this.form.get('nipc').value.toString(),
        endereco: this.form.get('endereco').value,
        razaoSocial: this.form.get('razaoSocial').value,
        contato: this.form.get('contato').value,
        email: this.form.get('email').value,
        dsServico: this.form.get('dsServico').value,
        isDeleted: false
      }
  }

  enviarEmpresa(){
    this.editar? this.alterar() : this.salvar();
  }

  alterar(){
    let body: any = this.montarBody()
    this.commomService.put(`${environment.empresas}`, body)
    .subscribe(() => {
      this.snackbar.open(MessagesSnackBar.EDITAR_EMPRESA_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarEmpresas').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackbar.open(MessagesSnackBar.EDITAR_EMPRESA_ERRO, 'Close', { duration: 4000 });
    });
  }  

  salvar(){
    const body: any = this.montarBody()

    this.commomService.post(`${environment.empresas}`, body)
    .subscribe(()=> {
      this.iniciarFormVazio();
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_EMPRESA_SUCESSO, 'Close', { duration: 6000 }): 
      this.snackbar.open(MessagesSnackBar.CRIAR_EMPRESA_SUCESSO, 'Close', { duration: 6000 });
      EventEmitterService.get('trocarTela').emit();
      EventEmitterService.get('buscarEmpresas').emit();
    },
    (error) => {
      console.log(error.message);
      this.editar? 
      this.snackbar.open(MessagesSnackBar.EDITAR_EMPRESA_ERRO, 'Close', { duration: 6000 }):
      this.snackbar.open(MessagesSnackBar.CRIAR_EMPRESA_ERRO, 'Close', { duration: 6000 });
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

  tableData = clienteAPIData;


  toggleStar(id: Contact['id']) {
    const contact = this.tableData.find(c => c.id === id);

    if (contact) {
      contact.starred = !contact.starred;
    }
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Adiconar Empresa'?'Voltar Lista':'Adiconar Empresa';
   
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

  predefinedCountries: Country[] = [
    {
      name: 'Afeganistão',
      alpha2Code: 'AF',
      alpha3Code: 'AFG',
      numericCode: '004'
    },
    {
      name: 'Albânia',
      alpha2Code: 'AL',
      alpha3Code: 'ALVA',
      numericCode: '008'
    },
    {
      name: 'Argélia',
      alpha2Code: 'DZ',
      alpha3Code: 'DZA',
      numericCode: '012',
    },
    {
      name: 'Andorra',
      alpha2Code: 'AD',
      alpha3Code: 'AND',
      numericCode: '020'
    },
    {
      name: 'Angola',
      alpha2Code: 'AO',
      alpha3Code: 'AGO',
      numericCode: '024',
    },
  {
      name: 'Anguilla',
      alpha2Code: 'AI',
      alpha3Code: 'AIA',
      numericCode: '660',
    },
  {
      name: 'Antártica',
      alpha2Code: 'AQ',
      alpha3Code: 'ATA',
      numericCode: '010',
    },
  {
      name: 'Antigua e Barbuda',
      alpha2Code: 'AG',
      alpha3Code: 'ATG',
      numericCode: '028',
    },
  {
      name: 'Argentina',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
  {
      name: 'Armênia',
      alpha2Code: 'AM',
      alpha3Code: 'ARM',
      numericCode: '051',
    },
  {
      name: 'Argentina',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
  {
      name: 'Aruba',
      alpha2Code: 'AW',
      alpha3Code: 'ABW',
      numericCode: '553',
    },
  {
      name: 'Austrália',
      alpha2Code: 'AU',
      alpha3Code: 'AUS',
      numericCode: '036',
    },
  {
      name: 'Áustria',
      alpha2Code: 'AT',
      alpha3Code: 'AUT',
      numericCode: '040',
    },
  {
      name: 'Azerbaijão',
      alpha2Code: 'AZ',
      alpha3Code: 'AZE',
      numericCode: '031',
    },
  {
      name: 'Bahamas',
      alpha2Code: 'BS',
      alpha3Code: 'BHS',
      numericCode: '044',
    },
  {
      name: 'Bahrain',
      alpha2Code: 'BH',
      alpha3Code: 'BHR',
      numericCode: '048',
    },
  {
      name: 'Bangladesh',
      alpha2Code: 'BD',
      alpha3Code: 'BGD',
      numericCode: '050',
    },
  {
      name: 'Barbados',
      alpha2Code: 'BB',
      alpha3Code: 'BRB',
      numericCode: '052',
    },
  {
      name: 'Bielo-Rússia',
      alpha2Code: 'BY',
      alpha3Code: 'BLR',
      numericCode: '112',
    },
  {
      name: 'Bélgica',
      alpha2Code: 'BE',
      alpha3Code: 'BEL',
      numericCode: '056',
    },
  {
      name: 'Belize',
      alpha2Code: 'BZ',
      alpha3Code: 'BLZ',
      numericCode: '084',
    },
  {
      name: 'Benin',
      alpha2Code: 'BJ',
      alpha3Code: 'BEN',
      numericCode: '204',
    },
   {
      name: 'Bermudas',
      alpha2Code: 'BM',
      alpha3Code: 'BMU',
      numericCode: '060',
    },
   {
      name: 'Butão',
      alpha2Code: 'BT',
      alpha3Code: 'BTN',
      numericCode: '064',
    },
   {
      name: 'Bolívia',
      alpha2Code: 'BO',
      alpha3Code: 'BOL',
      numericCode: '068',
    },
   {
      name: 'Bonaire, Sint Eustatius e Saba',
      alpha2Code: 'BQ',
      alpha3Code: 'BES',
      numericCode: '535',
    },
   {
      name: 'Bósnia e Herzegovina',
      alpha2Code: 'BA',
      alpha3Code: 'BIH',
      numericCode: '070',
    },
   {
      name: 'Botswana',
      alpha2Code: 'BW',
      alpha3Code: 'BWA',
      numericCode: '072',
    },
   {
      name: 'Ilha Bouvet',
      alpha2Code: 'BV',
      alpha3Code: 'BVT',
      numericCode: '074',
    },
   {
      name: 'Brasil',
      alpha2Code: 'BR',
      alpha3Code: 'BRA',
      numericCode: '076',
    },
   {
      name: 'Território Britânico do Oceano Índico',
      alpha2Code: 'IO',
      alpha3Code: 'IOT',
      numericCode: '086',
    },
   {
      name: 'Brunei Darussalam',
      alpha2Code: 'BN',
      alpha3Code: 'BRN',
      numericCode: '096',
    },
   {
      name: 'Bulgária',
      alpha2Code: 'BG',
      alpha3Code: 'BGR',
      numericCode: '100',
    },
   {
      name: 'Burkina Faso',
      alpha2Code: 'BF',
      alpha3Code: 'BFA',
      numericCode: '854',
    },
   {
      name: 'Burundi',
      alpha2Code: 'BI',
      alpha3Code: 'BDI',
      numericCode: '108',
    },
   {
      name: 'Cabo verde',
      alpha2Code: 'CV',
      alpha3Code: 'CPV',
      numericCode: '132',
    },
   {
      name: 'Camboja',
      alpha2Code: 'KH',
      alpha3Code: 'KHM',
      numericCode: '116',
    },
   {
      name: 'Camarões',
      alpha2Code: 'CM',
      alpha3Code: 'CMR',
      numericCode: '120',
    },
   {
      name: 'Canadá',
      alpha2Code: 'CA',
      alpha3Code: 'CAN',
      numericCode: '124',
    },
   {
      name: 'Ilhas Cayman',
      alpha2Code: 'KY',
      alpha3Code: 'CYM',
      numericCode: '136',
    },
   {
      name: 'República Centro-Africana',
      alpha2Code: 'CF',
      alpha3Code: 'CAF',
      numericCode: '140',
    },
   {
      name: 'Chade',
      alpha2Code: 'TD',
      alpha3Code: 'TCD',
      numericCode: '148',
    },
   {
      name: 'Chile',
      alpha2Code: 'CL',
      alpha3Code: 'CHL',
      numericCode: '152',
    },
   {
      name: 'China',
      alpha2Code: 'CN',
      alpha3Code: 'CHN',
      numericCode: '156',
    },
   {
      name: 'Ilha do Natal',
      alpha2Code: 'CX',
      alpha3Code: 'CXR',
      numericCode: '162',
    },
   {
      name: 'Ilhas Cocos',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
   {
      name: 'Colômbia',
      alpha2Code: 'CO',
      alpha3Code: 'COL',
      numericCode: '170',
    },
   {
      name: 'Comores',
      alpha2Code: 'KM',
      alpha3Code: 'COM',
      numericCode: '174',
    },
   {
      name: 'Congo',
      alpha2Code: 'CD',
      alpha3Code: 'COD',
      numericCode: '180',
    },
   {
      name: 'Congo',
      alpha2Code: 'CG',
      alpha3Code: 'COG',
      numericCode: '178',
    },
   {
      name: 'Ilhas Cook',
      alpha2Code: 'CK',
      alpha3Code: 'COK',
      numericCode: '184',
    },
   {
      name: 'Costa Rica',
      alpha2Code: 'CR',
      alpha3Code: 'CRI',
      numericCode: '188',
    },
   {
      name: 'Croácia',
      alpha2Code: 'HR',
      alpha3Code: 'HRV',
      numericCode: '191',
    },
   {
      name: 'Cuba',
      alpha2Code: 'CU',
      alpha3Code: 'CUB',
      numericCode: '192',
    },
   {
      name: 'Curaçao',
      alpha2Code: 'CW',
      alpha3Code: 'CUW',
      numericCode: '531',
    },
   {
      name: 'Chipre',
      alpha2Code: 'CY',
      alpha3Code: 'CYP',
      numericCode: '196',
    },
   {
      name: 'Czechia',
      alpha2Code: 'CZ',
      alpha3Code: 'CZE',
      numericCode: '203',
    },
   {
      name: 'Costa do Marfim',
      alpha2Code: 'CI',
      alpha3Code: 'CIV',
      numericCode: '384',
    },
   {
      name: 'Dinamarca',
      alpha2Code: 'DK',
      alpha3Code: 'DNK',
      numericCode: '208',
    },
   {
      name: 'Djibouti',
      alpha2Code: 'DJ',
      alpha3Code: 'DJI',
      numericCode: '262',
    },
   {
      name: 'Dominica',
      alpha2Code: 'DM',
      alpha3Code: 'DMA',
      numericCode: '212',
    },
   {
      name: 'República Dominicana',
      alpha2Code: 'DO',
      alpha3Code: 'DOM',
      numericCode: '214',
    },
   {
      name: 'Equador',
      alpha2Code: 'EC',
      alpha3Code: 'ECU',
      numericCode: '218',
    },
   {
      name: 'Egito',
      alpha2Code: 'EG',
      alpha3Code: 'EGY',
      numericCode: '818',
    },
   {
      name: 'El Salvador',
      alpha2Code: 'SV',
      alpha3Code: 'SLV',
      numericCode: '222',
    },
   {
      name: 'Guiné Equatorial',
      alpha2Code: 'GQ',
      alpha3Code: 'GNQ',
      numericCode: '226',
    },
   {
      name: 'Eritreia',
      alpha2Code: 'ER',
      alpha3Code: 'ERI',
      numericCode: '232',
    },
   {
      name: 'Estônia',
      alpha2Code: 'EE',
      alpha3Code: 'EST',
      numericCode: '233',
    },
   {
      name: 'Eswatini',
      alpha2Code: 'SZ',
      alpha3Code: 'SWZ',
      numericCode: '748',
    },
   {
      name: 'Etiópia',
      alpha2Code: 'ET',
      alpha3Code: 'ETH',
      numericCode: '231',
    },
   {
      name: 'Ilhas Malvinas',
      alpha2Code: 'FK',
      alpha3Code: 'FLK',
      numericCode: '238',
    },
   {
      name: 'Fiji',
      alpha2Code: 'FJ',
      alpha3Code: 'FJI',
      numericCode: '242',
    },
   {
      name: 'Finlândia',
      alpha2Code: 'FI',
      alpha3Code: 'FIN',
      numericCode: '246',
    },
   {
      name: 'França',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
   {
      name: 'Guiana Francesa',
      alpha2Code: 'GF',
      alpha3Code: 'GUF',
      numericCode: '254',
    },
   {
      name: 'Polinésia Francesa',
      alpha2Code: 'PF',
      alpha3Code: 'PYF',
      numericCode: '258',
    },
   {
      name: 'Territórios Franceses do Sul',
      alpha2Code: 'TF',
      alpha3Code: 'ATF',
      numericCode: '260',
    },
   {
      name: 'Gabão',
      alpha2Code: 'GA',
      alpha3Code: 'GAB',
      numericCode: '266',
    },
   {
      name: 'Gâmbia',
      alpha2Code: 'GM',
      alpha3Code: 'GMB',
      numericCode: '270',
    },
   {
      name: 'Georgia',
      alpha2Code: 'GE',
      alpha3Code: 'GEO',
      numericCode: '268',
    },
   {
      name: 'Georgia',
      alpha2Code: 'GE',
      alpha3Code: 'GEO',
      numericCode: '268',
    },
   {
      name: 'Alemanha',
      alpha2Code: 'DE',
      alpha3Code: 'DEU',
      numericCode: '276',
    },
   {
      name: 'Gana',
      alpha2Code: 'GH',
      alpha3Code: 'GHA',
      numericCode: '288',
    },
   {
      name: 'Gibraltar',
      alpha2Code: 'GI',
      alpha3Code: 'GIB',
      numericCode: '292',
    },
   {
      name: 'Grécia',
      alpha2Code: 'GR',
      alpha3Code: 'GRC',
      numericCode: '032',
    },
   {
      name: 'Groenlândia',
      alpha2Code: 'GL',
      alpha3Code: 'GRL',
      numericCode: '304',
    },
   {
      name: 'Grenada',
      alpha2Code: 'GD',
      alpha3Code: 'GRD',
      numericCode: '308',
    },
   {
      name: 'Guadalupe',
      alpha2Code: 'GP',
      alpha3Code: 'GLP',
      numericCode: '312',
    },
   {
      name: 'Guam',
      alpha2Code: 'GU',
      alpha3Code: 'GUM',
      numericCode: '316',
    },
   {
      name: 'Guatemala',
      alpha2Code: 'GT',
      alpha3Code: 'GTM',
      numericCode: '320',
    },
   {
      name: 'Guernsey',
      alpha2Code: 'GG',
      alpha3Code: 'GGY',
      numericCode: '831',
    },
   {
      name: 'Guiné',
      alpha2Code: 'GN',
      alpha3Code: 'GIN',
      numericCode: '324',
    },
   {
      name: 'Guinea-bissau',
      alpha2Code: 'GW',
      alpha3Code: 'GNB',
      numericCode: '624',
    },
   {
      name: 'Guiana',
      alpha2Code: 'GY',
      alpha3Code: 'GUY',
      numericCode: '328',
    },
   {
      name: 'Haiti',
      alpha2Code: 'HT',
      alpha3Code: 'HTI',
      numericCode: '332',
    },
   {
      name: 'Ilha Heard e Ilhas McDonald',
      alpha2Code: 'HM',
      alpha3Code: 'HMD',
      numericCode: '334',
    },
   {
      name: 'Santa Sé',
      alpha2Code: 'VA',
      alpha3Code: 'VAT',
      numericCode: '336',
    },
   {
      name: 'Honduras',
      alpha2Code: 'HN',
      alpha3Code: 'HND',
      numericCode: '340',
    },
   {
      name: 'Hong Kong',
      alpha2Code: 'HK',
      alpha3Code: 'HKG',
      numericCode: '344',
    },
   {
      name: 'Hungria',
      alpha2Code: 'HU',
      alpha3Code: 'HUN',
      numericCode: '348',
    },
   {
      name: 'Islândia',
      alpha2Code: 'IS',
      alpha3Code: 'ISL',
      numericCode: '352',
    },
   {
      name: 'Índia',
      alpha2Code: 'IN',
      alpha3Code: 'IND',
      numericCode: '356',
    },
   {
      name: 'Irã',
      alpha2Code: 'IR',
      alpha3Code: 'IRN',
      numericCode: '364',
    },
   {
      name: 'Iraque',
      alpha2Code: 'IQ',
      alpha3Code: 'IRQ',
      numericCode: '368',
    },
   {
      name: 'Irlanda',
      alpha2Code: 'IE',
      alpha3Code: 'IRL',
      numericCode: '372',
    },
   {
      name: 'Ilha de Man',
      alpha2Code: 'IM',
      alpha3Code: 'IMN',
      numericCode: '833',
    },
   {
      name: 'Israel',
      alpha2Code: 'IL',
      alpha3Code: 'ISR',
      numericCode: '376',
    },
   {
      name: 'Itália',
      alpha2Code: 'IT',
      alpha3Code: 'ITA',
      numericCode: '380',
    },
   {
      name: 'Jamaica',
      alpha2Code: 'JM',
      alpha3Code: 'JAM',
      numericCode: '388',
    },
   {
      name: 'Japão',
      alpha2Code: 'JP',
      alpha3Code: 'JPN',
      numericCode: '392',
    },
   {
      name: 'Jersey',
      alpha2Code: 'JE',
      alpha3Code: 'JEY',
      numericCode: '832',
    },
   {
      name: 'Jordânia',
      alpha2Code: 'JO',
      alpha3Code: 'JOR',
      numericCode: '400',
    },
   {
      name: 'Cazaquistão',
      alpha2Code: 'KZ',
      alpha3Code: 'KAZ',
      numericCode: '398',
    },
   {
      name: 'Quênia',
      alpha2Code: 'KE',
      alpha3Code: 'KEN',
      numericCode: '404',
    },
   {
      name: 'Kiribati',
      alpha2Code: 'KI',
      alpha3Code: 'KIR',
      numericCode: '296',
    },
   {
      name: 'Coreia',
      alpha2Code: 'KP',
      alpha3Code: 'PRK',
      numericCode: '408',
    },
   {
      name: 'Kuwait',
      alpha2Code: 'KW',
      alpha3Code: 'KWT',
      numericCode: '414',
    },
   {
      name: 'Quirguistão',
      alpha2Code: 'KG',
      alpha3Code: 'KGZ',
      numericCode: '417',
    },
   {
      name: 'República Democrática Popular do Laos',
      alpha2Code: 'LA',
      alpha3Code: 'LAO',
      numericCode: '418',
    },
   {
      name: 'Letônia',
      alpha2Code: 'LV',
      alpha3Code: 'LVA',
      numericCode: '428',
    },
   {
      name: 'Líbano',
      alpha2Code: 'LB',
      alpha3Code: 'LBN',
      numericCode: '422',
    },
   {
      name: 'Lesoto',
      alpha2Code: 'LS',
      alpha3Code: 'LSO',
      numericCode: '426',
    },
   {
      name: 'Libéria',
      alpha2Code: 'LR',
      alpha3Code: 'LBR',
      numericCode: '430',
    },
   {
      name: 'Líbia',
      alpha2Code: 'LY',
      alpha3Code: 'LBY',
      numericCode: '434',
    },
   {
      name: 'Liechtenstein',
      alpha2Code: 'LI',
      alpha3Code: 'LIE',
      numericCode: '438',
    },
   {
      name: 'Lituânia',
      alpha2Code: 'LT',
      alpha3Code: 'LTU',
      numericCode: '440',
    },
   {
      name: 'Luxemburgo',
      alpha2Code: 'LU',
      alpha3Code: 'LUX',
      numericCode: '442',
    },
   {
      name: 'Macau',
      alpha2Code: 'MO',
      alpha3Code: 'MAC',
      numericCode: '446',
    },
   {
      name: 'Madagáscar',
      alpha2Code: 'MG',
      alpha3Code: 'MDG',
      numericCode: '450',
    },
  {
      name: 'Malawi',
      alpha2Code: 'MW',
      alpha3Code: 'MWI',
      numericCode: '454',
    },
  {
      name: 'Malásia',
      alpha2Code: 'MY',
      alpha3Code: 'MYS',
      numericCode: '458',
    },
  {
      name: 'Maldivas',
      alpha2Code: 'MV',
      alpha3Code: 'MDV',
      numericCode: '462',
    },
  {
      name: 'Mali',
      alpha2Code: 'ML',
      alpha3Code: 'MLI',
      numericCode: '466',
    },
  {
      name: 'Malta',
      alpha2Code: 'MT',
      alpha3Code: 'MLT',
      numericCode: '470',
    },
  {
      name: 'Ilhas Marshall',
      alpha2Code: 'MH',
      alpha3Code: 'MHL',
      numericCode: '584',
    },
  {
      name: 'Martinica',
      alpha2Code: 'MQ',
      alpha3Code: 'MTQ',
      numericCode: '474',
    },
  {
      name: 'Mauritânia',
      alpha2Code: 'MR',
      alpha3Code: 'MRT',
      numericCode: '478',
    },
  {
      name: 'Maurício',
      alpha2Code: 'MU',
      alpha3Code: 'MUS',
      numericCode: '480',
    },
  {
      name: 'Mayotte',
      alpha2Code: 'YT',
      alpha3Code: 'MYT',
      numericCode: '175',
    },
  {
      name: 'México',
      alpha2Code: 'MX',
      alpha3Code: 'MEX',
      numericCode: '484',
    },
  {
      name: 'Micronésia',
      alpha2Code: 'FM',
      alpha3Code: 'FSM',
      numericCode: '583',
    },
  {
      name: 'Moldávia',
      alpha2Code: 'MD',
      alpha3Code: 'MDA',
      numericCode: '498',
    },
  {
      name: 'Mônaco',
      alpha2Code: 'MC',
      alpha3Code: 'MCO',
      numericCode: '492',
    },
  {
      name: 'Mongólia',
      alpha2Code: 'MN',
      alpha3Code: 'MNG',
      numericCode: '496',
    },
  {
      name: 'Montenegro',
      alpha2Code: 'ME',
      alpha3Code: 'MNE',
      numericCode: '499',
    },
  {
      name: 'Montserrat',
      alpha2Code: 'MS',
      alpha3Code: 'MSR',
      numericCode: '500',
    },
  {
      name: 'Marrocos',
      alpha2Code: 'MA',
      alpha3Code: 'MAR',
      numericCode: '504',
    },
  {
      name: 'Moçambique',
      alpha2Code: 'MZ',
      alpha3Code: 'MOZ',
      numericCode: '508',
    },
  {
      name: 'Myanmar',
      alpha2Code: 'MM',
      alpha3Code: 'MMR',
      numericCode: '104',
    },
  {
      name: 'Namibia',
      alpha2Code: 'NA',
      alpha3Code: 'NAM',
      numericCode: '516',
    },
  {
      name: 'Nauru',
      alpha2Code: 'NR',
      alpha3Code: 'NRU',
      numericCode: '520',
    },
  {
      name: 'Nepal',
      alpha2Code: 'NP',
      alpha3Code: 'NPL',
      numericCode: '524',
    },
  {
      name: 'Holanda',
      alpha2Code: 'NL',
      alpha3Code: 'NLD',
      numericCode: '528',
    },
  {
      name: 'Nova Caledônia',
      alpha2Code: 'NC',
      alpha3Code: 'NCL',
      numericCode: '540',
    },
  {
      name: 'Nova Zelândia',
      alpha2Code: 'NZ',
      alpha3Code: 'NZL',
      numericCode: '554',
    },
  {
      name: 'Nicarágua',
      alpha2Code: 'NI',
      alpha3Code: 'NIC',
      numericCode: '558',
    },
  {
      name: 'Níger',
      alpha2Code: 'NE',
      alpha3Code: 'NER',
      numericCode: '562',
    },
  {
      name: 'Nigéria',
      alpha2Code: 'NG',
      alpha3Code: 'NGA',
      numericCode: '566',
    },
  {
      name: 'Niue',
      alpha2Code: 'NU',
      alpha3Code: 'NIU',
      numericCode: '570',
    },
  {
      name: 'Ilha Norfolk',
      alpha2Code: 'NF',
      alpha3Code: 'NFK',
      numericCode: '574',
    },
  {
      name: 'Ilha Norfolk',
      alpha2Code: 'NF',
      alpha3Code: 'NFK',
      numericCode: '574',
    },
  {
      name: 'Ilhas Marianas do Norte',
      alpha2Code: 'MP',
      alpha3Code: 'MNP',
      numericCode: '580',
    },
  {
      name: 'Noruega',
      alpha2Code: 'NO',
      alpha3Code: 'NOR',
      numericCode: '578',
    },
  {
      name: 'Omã',
      alpha2Code: 'OM',
      alpha3Code: 'OMN',
      numericCode: '512',
    },
  {
      name: 'Paquistão',
      alpha2Code: 'PK',
      alpha3Code: 'PAK',
      numericCode: '586',
    },
  {
      name: 'Palau',
      alpha2Code: 'PW',
      alpha3Code: 'PSE',
      numericCode: '585',
    },
  {
      name: 'Palestina',
      alpha2Code: 'PS',
      alpha3Code: 'PSE',
      numericCode: '275',
    },
  {
      name: 'Panamá',
      alpha2Code: 'PA',
      alpha3Code: 'PAN',
      numericCode: '591',
    },
  {
      name: 'Papua Nova Guiné',
      alpha2Code: 'PG',
      alpha3Code: 'PNG',
      numericCode: '598',
    },
  {
      name: 'Paraguai',
      alpha2Code: 'PY',
      alpha3Code: 'PRY',
      numericCode: '600',
    },
  {
      name: 'Peru',
      alpha2Code: 'PE',
      alpha3Code: 'PER',
      numericCode: '604',
    },
  {
      name: 'Filipinas',
      alpha2Code: 'PH',
      alpha3Code: 'PHL',
      numericCode: '608',
    },
  {
      name: 'Pitcairn',
      alpha2Code: 'PN',
      alpha3Code: 'PCN',
      numericCode: '612',
    },
  {
      name: 'Polônia',
      alpha2Code: 'PL',
      alpha3Code: 'POL',
      numericCode: '616',
    },
  {
      name: 'Portugal',
      alpha2Code: 'PT',
      alpha3Code: 'PRT',
      numericCode: '620',
    },
  {
      name: 'Porto Rico',
      alpha2Code: 'PR',
      alpha3Code: 'PRI',
      numericCode: '630',
    },
  {
      name: 'Catar',
      alpha2Code: 'QA',
      alpha3Code: 'QAT',
      numericCode: '634',
    },
  {
      name: 'Romênia',
      alpha2Code: 'RO',
      alpha3Code: 'ROU',
      numericCode: '642',
    },
  {
      name: 'República da Macedônia do Norte',
      alpha2Code: 'MK',
      alpha3Code: 'MKD',
      numericCode: '807',
    },
  {
      name: 'Russia',
      alpha2Code: 'RU',
      alpha3Code: 'RUS',
      numericCode: '643',
    },
  {
      name: 'Ruanda',
      alpha2Code: 'RW',
      alpha3Code: 'RWA',
      numericCode: '646',
    },
  {
      name: 'Reunião',
      alpha2Code: 'RE',
      alpha3Code: 'REU',
      numericCode: '638',
    },
  {
      name: 'São Bartolomeu',
      alpha2Code: 'BL',
      alpha3Code: 'BLM',
      numericCode: '652',
    },
  {
      name: 'Santa Helena, Ascensão e Tristão da Cunha',
      alpha2Code: 'SH',
      alpha3Code: 'SHN',
      numericCode: '654',
    },
  {
      name: 'São Cristóvão e Neves',
      alpha2Code: 'KN',
      alpha3Code: 'KNA',
      numericCode: '659',
    },
  {
      name: 'Argentina',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
  {
      name: 'Santa Lúcia',
      alpha2Code: 'LC',
      alpha3Code: 'LCA',
      numericCode: '662',
    },
  {
      name: 'Saint Martin (parte francesa)',
      alpha2Code: 'MF',
      alpha3Code: 'MAF',
      numericCode: '663',
    },
  {
      name: 'São Pedro e Miquelão',
      alpha2Code: 'PM',
      alpha3Code: 'SPM',
      numericCode: '666',
    },
  {
      name: 'São Vicente e Granadinas',
      alpha2Code: 'VC',
      alpha3Code: 'VCT',
      numericCode: '670',
    },
  {
      name: 'Samoa',
      alpha2Code: 'WS',
      alpha3Code: 'WSM',
      numericCode: '882',
    },
  {
      name: 'San Marino',
      alpha2Code: 'SM',
      alpha3Code: 'SMR',
      numericCode: '674',
    },
  {
      name: 'São Tomé e Príncipe',
      alpha2Code: 'ST',
      alpha3Code: 'STP',
      numericCode: '678',
    },
  {
      name: 'Arábia Saudita',
      alpha2Code: 'SA',
      alpha3Code: 'SAU',
      numericCode: '682',
    },
  {
      name: 'Senegal',
      alpha2Code: 'SN',
      alpha3Code: 'SEN',
      numericCode: '686',
    },
  {
      name: 'Sérvia',
      alpha2Code: 'RS',
      alpha3Code: 'SRB',
      numericCode: '688',
    },
  {
      name: 'Seychelles',
      alpha2Code: 'SC',
      alpha3Code: 'SYC',
      numericCode: '690',
    },
  {
      name: 'Serra Leoa',
      alpha2Code: 'SL',
      alpha3Code: 'SLE',
      numericCode: '694',
    },
  {
      name: 'Cingapura',
      alpha2Code: 'SG',
      alpha3Code: 'SGP',
      numericCode: '702',
    },
  {
      name: 'Eslováquia',
      alpha2Code: 'SK',
      alpha3Code: 'SVK',
      numericCode: '703',
    },
  {
      name: 'Eslovênia',
      alpha2Code: 'SI',
      alpha3Code: 'SVN',
      numericCode: '705',
    },
  {
      name: 'Ilhas Salomão',
      alpha2Code: 'SB',
      alpha3Code: 'SLB',
      numericCode: '90',
    },
  {
      name: 'Somália',
      alpha2Code: 'SO',
      alpha3Code: 'SOM',
      numericCode: '706',
    },
  {
      name: 'África do Sul',
      alpha2Code: 'ZA',
      alpha3Code: 'ZAF',
      numericCode: '032',
    },
  {
      name: 'Argentina',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '710',
    },
  {
      name: 'Argentina',
      alpha2Code: 'AR',
      alpha3Code: 'ARG',
      numericCode: '032',
    },
  {
      name: 'Geórgia do Sul e Ilhas Sandwich do Sul',
      alpha2Code: 'GS',
      alpha3Code: 'SGS',
      numericCode: '239',
    },
  {
      name: 'Sudão do Sul',
      alpha2Code: 'SS',
      alpha3Code: 'SSD',
      numericCode: '728',
    },
  {
      name: 'Espanha',
      alpha2Code: 'ES',
      alpha3Code: 'ESP',
      numericCode: '724',
    },
  {
      name: 'Sri Lanka',
      alpha2Code: 'LK',
      alpha3Code: 'LKA',
      numericCode: '144',
    },
  {
      name: 'Sudão',
      alpha2Code: 'SD',
      alpha3Code: 'SDN',
      numericCode: '729',
    },
  {
      name: 'Suriname',
      alpha2Code: 'SR',
      alpha3Code: 'SUR',
      numericCode: '740',
    },
  {
      name: 'Svalbard e Jan Mayen',
      alpha2Code: 'SJ',
      alpha3Code: 'SJM',
      numericCode: '744',
    },
  {
      name: 'Suécia',
      alpha2Code: 'SE',
      alpha3Code: 'SWE',
      numericCode: '752',
    },
  {
      name: 'Suíça',
      alpha2Code: 'CH',
      alpha3Code: 'CHE',
      numericCode: '756',
    },
  {
      name: 'Síria',
      alpha2Code: 'SY',
      alpha3Code: 'SYR',
      numericCode: '760',
    },
  {
      name: 'Taiwan',
      alpha2Code: 'TW',
      alpha3Code: 'TWN',
      numericCode: '158',
    },
  {
      name: 'Tajiquistão',
      alpha2Code: 'TJ',
      alpha3Code: 'TJK',
      numericCode: '762',
    },
  {
      name: 'Tanzânia, República Unida da',
      alpha2Code: 'TZ',
      alpha3Code: 'TZA',
      numericCode: '834',
    },
  {
      name: 'Tailândia',
      alpha2Code: 'TH',
      alpha3Code: 'THA',
      numericCode: '764',
    },
  {
      name: 'Timor-Leste',
      alpha2Code: 'TL',
      alpha3Code: 'TLS',
      numericCode: '626',
    },
  {
      name: 'Ir',
      alpha2Code: 'TG',
      alpha3Code: 'TGO',
      numericCode: '768',
    },
  {
      name: 'Tokelau',
      alpha2Code: 'TK',
      alpha3Code: 'TKL',
      numericCode: '772',
    },
  {
      name: 'Tonga',
      alpha2Code: 'TO',
      alpha3Code: 'TON',
      numericCode: '776',
    },
  {
      name: 'Trinidad e Tobago',
      alpha2Code: 'TT',
      alpha3Code: 'TTO',
      numericCode: '780',
    },
  {
      name: 'Tunísia',
      alpha2Code: 'TN',
      alpha3Code: 'TUN',
      numericCode: '788',
    },
  {
      name: 'Peru',
      alpha2Code: 'TR',
      alpha3Code: 'TUR',
      numericCode: '792',
    },
  {
      name: 'Turcomenistão',
      alpha2Code: 'TM',
      alpha3Code: 'TKM',
      numericCode: '795',
    },
  {
      name: 'Ilhas Turks e Caicos',
      alpha2Code: 'TC',
      alpha3Code: 'TCA',
      numericCode: '796',
    },
  {
      name: 'Tuvalu',
      alpha2Code: 'TV',
      alpha3Code: 'TUV',
      numericCode: '798',
    },
  {
      name: 'Uganda',
      alpha2Code: 'UG',
      alpha3Code: 'UGA',
      numericCode: '800',
    },
  {
      name: 'Ucrânia',
      alpha2Code: 'UA',
      alpha3Code: 'UKR',
      numericCode: '804',
    },
  {
      name: 'Emirados Árabes Unidos',
      alpha2Code: 'AE',
      alpha3Code: 'ARE',
      numericCode: '784',
    },
  {
      name: 'Reino Unido da Grã-Bretanha',
      alpha2Code: 'GB',
      alpha3Code: 'GBR',
      numericCode: '826',
    },
  {
      name: 'Ilhas Menores Distantes dos Estados Unidos',
      alpha2Code: 'UM',
      alpha3Code: 'UMI',
      numericCode: '581',
    },
  {
      name: 'Estados Unidos da América',
      alpha2Code: 'US',
      alpha3Code: 'USA',
      numericCode: '840',
    },
  {
      name: 'Uruguai',
      alpha2Code: 'UY',
      alpha3Code: 'URY',
      numericCode: '858',
    },
  {
      name: 'Uzbequistão',
      alpha2Code: 'UZ',
      alpha3Code: 'UZB',
      numericCode: '860',
    },
  {
      name: 'Vanuatu',
      alpha2Code: 'VU',
      alpha3Code: 'VUT',
      numericCode: '548',
    },
  {
      name: 'Venezuela',
      alpha2Code: 'VE',
      alpha3Code: 'VEN',
      numericCode: '862',
    },
  {
      name: 'Viet Nam',
      alpha2Code: 'VN',
      alpha3Code: 'VNM',
      numericCode: '704',
    },
  {
      name: 'Ilhas Virgens (britânicas)',
      alpha2Code: 'VG',
      alpha3Code: 'VGB',
      numericCode: '092',
    },
  {
      name: 'Ilhas Virgens (EUA)',
      alpha2Code: 'VI',
      alpha3Code: 'VIR',
      numericCode: '850',
    },
  {
      name: 'Wallis e Futuna',
      alpha2Code: 'WF',
      alpha3Code: 'WLF',
      numericCode: '876',
    },
  {
      name: 'Saara Ocidental',
      alpha2Code: 'EH',
      alpha3Code: 'ESH',
      numericCode: '732',
    },
  {
      name: 'Iémen',
      alpha2Code: 'YE',
      alpha3Code: 'YEM',
      numericCode: '887',
    },
  {
      name: 'Zâmbia',
      alpha2Code: 'ZM',
      alpha3Code: 'ZMB',
      numericCode: '894',
    },
  {
      name: 'Zimbábue',
      alpha2Code: 'ZW',
      alpha3Code: 'ZWE',
      numericCode: '716',
    },
  {
      name: 'Ilhas Aland',
      alpha2Code: 'AX',
      alpha3Code: 'ALA',
      numericCode: '248',
    } ,
  
  ];
}
