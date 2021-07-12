import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import icClose from '@iconify/icons-ic/twotone-close';
import icPrint from '@iconify/icons-ic/twotone-print';
import icDownload from '@iconify/icons-ic/twotone-cloud-download';
import icDelete from '@iconify/icons-ic/twotone-delete';
import icPhone from '@iconify/icons-ic/twotone-phone';
import icPerson from '@iconify/icons-ic/twotone-person';
import icMyLocation from '@iconify/icons-ic/twotone-my-location';
import icLocationCity from '@iconify/icons-ic/twotone-location-city';
import icEditLocation from '@iconify/icons-ic/twotone-edit-location';
import { Cliente } from 'src/app/_models/Cliente';
import icAssigment from '@iconify/icons-ic/twotone-assignment';
import { CommomService } from 'src/app/services/commom.service';
import { environment } from "src/environments/environment";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import icVisibility from '@iconify/icons-ic/twotone-visibility';
import icVisibilityOff from '@iconify/icons-ic/twotone-visibility-off';
import icMail from '@iconify/icons-ic/twotone-mail';
import { ErrorStateMatcher } from '@angular/material/core';
import { takeUntil } from 'rxjs/operators';
import { EventEmitterService } from 'src/app/services/event.service';
import { fadeInUp400ms } from '../../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../../@vex/animations/stagger.animation';
import { Countries } from 'src/app/_models/Countries';
import { Currencies } from 'src/app/_models/Currencies';
import { Cultures } from 'src/app/_models/Cultures';
import { CustomerGroups } from 'src/app/_models/CustomerGroup';
import { PaymentMethods } from 'src/app/_models/PaymentMethods';
import { PaymentTerms } from 'src/app/_models/PaymentTerms';
import { DeliveryTerms } from 'src/app/_models/DeliveryTerms';
import { PartyTaxSchemas } from 'src/app/_models/PartyTaxSchemas';
import { PartyWithholdingTaxSchemas } from 'src/app/_models/PartyWithholdingTaxSchemas';
import { PriceLists } from 'src/app/_models/PriceLists';


export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

@Component({
  selector: 'vex-cliente-create-update',
  templateUrl: './cliente-create-update.component.html',
  styleUrls: ['./cliente-create-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class ClienteCreateUpdateComponent implements OnInit {

  static id = 100;

  form: FormGroup;
  matcher = new MyErrorStateMatcher();

  mode: 'create' | 'update' = 'create';

  icMoreVert = icMoreVert;
  icClose = icClose;
  icAssigment = icAssigment
  icPrint = icPrint;
  icDownload = icDownload;
  icDelete = icDelete;
  icMail = icMail;
  icPerson = icPerson;
  icMyLocation = icMyLocation;
  icLocationCity = icLocationCity;
  icEditLocation = icEditLocation;
  icPhone = icPhone;
  inputType = 'password';
  visible = false;

  icVisibility = icVisibility;
  icVisibilityOff = icVisibilityOff;

  listOfCountries = new Array<Countries>();
  listOfCurrencies = new Array<Currencies>();
  listOfCultures = new Array<Cultures>();
  listOfCustomerGroup = new Array<CustomerGroups>();
  listOfPaymentMethods = new Array<PaymentMethods>();
  listOfPaymentTerms = new Array<PaymentTerms>();
  listOfDeliveryTerms = new Array<DeliveryTerms>();
  listOfPartyTaxSchemas = new Array<PartyTaxSchemas>();
  listOfPartyWithholdingTaxSchemas = new Array<PartyWithholdingTaxSchemas>();
  listOfPriceLists = new Array<PriceLists>();

  requisicao: boolean = false;
  isRetornoCountries: boolean = false;
  isRetornoCurrency: boolean = false;
  isRetornoCultures: boolean = false;
  isRetornoCustomerGroup: boolean = false;
  isRetornoPaymentMethods: boolean = false;
  isRetornoPaymentTerms: boolean = false;
  isRetornoDeliveryTerms: boolean = false;
  isRetornoPartyTaxSchemas: boolean = false;
  isRetornoPartyWithholdingTaxSchemas: boolean = false;
  isRetornoPriceLists: boolean = false;

  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
    private dialogRef: MatDialogRef<ClienteCreateUpdateComponent>,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private commomService: CommomService,
    private cd: ChangeDetectorRef) {
  }

  ngOnInit() {

    if (this.defaults) {
      this.mode = 'update';
    } else {
      this.defaults = {} as Cliente;
    }


    this.form = this.fb.group({
      partyKey: [this.defaults.partyKey || null, [Validators.required]],
      name: [this.defaults.name || null, [Validators.required]],
      companyTaxID: [this.defaults.companyTaxID || null, []],
      countryId: [this.defaults.countryId || null, []],
      country: [this.defaults.country || null, []],
      countryDescription: [this.defaults.countryDescription || null, []],
      pais: [this.defaults.pais || null, [Validators.required]],
      currencyId: [this.defaults.currencyId || null],
      searchTerm: [this.defaults.searchTerm || null],
      pepperoni: false,
      isPerson: [this.defaults.isPerson || false],
      streetName: [this.defaults.streetName || null, []],
      buildingNumber: [this.defaults.buildingNumber || null, []],
      telephone: [this.defaults.telephone || null, []],
      electronicMail: [this.defaults.electronicMail || null, []],
      cultureId: [this.defaults.cultureId || null, []],
      mobile: [this.defaults.mobile || null, []],
      websiteUrl: [this.defaults.websiteUrl || null, []],
      isIntegration: [this.defaults.isIntegration || false, [Validators.required]],
      moeda: [this.defaults.moeda || null, [Validators.required]],
      cultura: [this.defaults.cultura || null, []],
      cityName: [this.defaults.cityName || null, []],
      postalZone: [this.defaults.postalZone || null, []],
      customerGroup: [this.defaults.customerGroup || null, []],
      customerGroupId: [this.defaults.customerGroupId || null, []],
      customerGroupDescription: [this.defaults.customerGroupDescription || null, []],
      grupoCliente: [this.defaults.grupoCliente || null, []],
      
      metodoPagamento: [this.defaults.metodoPagamento || null, []],
      paymentMethodId: [this.defaults.paymentMethodId || null, []],
      condicaoPagamento: [this.defaults.condicaoPagamento || null, []],
      paymentTermId: [this.defaults.paymentTermId || null, []],
      deliveryTermId: [this.defaults.deliveryTermId || null, []],
      condicaoEnvio: [this.defaults.condicaoEnvio || null, []],
      settlementDiscountPercent: [this.defaults.settlementDiscountPercent || 0, [Validators.max(100), Validators.min(0)]],
      regimeImposto: [this.defaults.regimeImposto || null, []],
      partyTaxSchemaId: [this.defaults.partyTaxSchemaId || null, []],
      tipoRetencao: [this.defaults.tipoRetencao || null, []],
      partyWithholdingTaxSchemaId: [this.defaults.partyWithholdingTaxSchemaId || null, []],
      listaPreco: [this.defaults.listaPreco || null, []],
      priceListId: [this.defaults.priceListId || null, []],
      ErrosIntegracao: [this.defaults.ErrosIntegracao || null, []],
      oneTimeCustomer: [this.defaults.oneTimeCustomer || false, []],
      endCustomer: [this.defaults.endCustomer || false, []],
      locked: [this.defaults.locked || false, []]
    });

    this.requisicao = true;
    this.loadCountries();
    this.loadCurrencies();
    this.loadCultures();
    this.loadCustomerGroup();
    this.loadPaymentMethod();
    this.loadPaymentTerms();
    this.loadDeliveryTerms();
    this.loadPartyTaxSchemas();
    this.loadPartyWithholdingTaxSchemas();
    this.loadPriceLists();

    if(this.mode === 'update'){
      this.form.get('partyKey').disable({ onlySelf: true });
    }
  }


  loadCountries() {
    this.commomService.get(environment.countries).subscribe(response => {
      this.listOfCountries = response.body;
      

      if(this.defaults.countryId != null){
          this.defaults.pais = this.listOfCountries.find(p => p.id === this.defaults.countryId);
          this.form.controls['pais'].setValue(this.defaults.pais);
      }
      this.isRetornoCountries = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadCurrencies() {
    this.commomService.get(environment.currencies).subscribe(response => {
      this.listOfCurrencies = response.body;

      if(this.defaults.currencyId != null) {
        this.defaults.moeda = this.listOfCurrencies.find(p => p.id === this.defaults.currencyId);
        this.form.controls['moeda'].setValue(this.defaults.moeda);
      }

      this.isRetornoCurrency = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadCultures() {
    this.commomService.get(environment.cultures).subscribe(response => {
      this.listOfCultures = response.body;

      if(this.defaults.cultureId != null) {
        this.defaults.cultura = this.listOfCultures.find(p => p.id === this.defaults.cultureId);
        this.form.controls['cultura'].setValue(this.defaults.cultura);
      }

      this.isRetornoCultures = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }


  loadCustomerGroup() {
    this.commomService.get(environment.customerGroup).subscribe(response => {
      this.listOfCustomerGroup = response.body;


      if(this.defaults.customerGroupId != null) {
        this.defaults.grupoCliente = this.listOfCustomerGroup.find(p => p.id === this.defaults.customerGroupId);
        this.form.controls['grupoCliente'].setValue(this.defaults.grupoCliente);
      }

      this.isRetornoCustomerGroup = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadPaymentMethod() {
    this.commomService.get(environment.paymentMethods).subscribe(response => {
      this.listOfPaymentMethods = response.body;

      if(this.defaults.paymentMethodId != null) {
        this.defaults.metodoPagamento = this.listOfPaymentMethods.find(p => p.id === this.defaults.paymentMethodId);
        this.form.controls['metodoPagamento'].setValue(this.defaults.metodoPagamento);
      }

      this.isRetornoPaymentMethods = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadPaymentTerms() {
    this.commomService.get(environment.paymentTerms).subscribe(response => {
      this.listOfPaymentTerms = response.body;

      if(this.defaults.paymentTermId != null) {
        this.defaults.condicaoPagamento = this.listOfPaymentTerms.find(p => p.id === this.defaults.paymentTermId);
        this.form.controls['condicaoPagamento'].setValue(this.defaults.condicaoPagamento);
      }

      this.isRetornoPaymentTerms = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadDeliveryTerms() {
    this.commomService.get(environment.deliveryTerms).subscribe(response => {
      this.listOfDeliveryTerms = response.body;

      if(this.defaults.deliveryTermId != null) {
        this.defaults.condicaoEnvio = this.listOfDeliveryTerms.find(p => p.id === this.defaults.deliveryTermId);
        this.form.controls['condicaoEnvio'].setValue(this.defaults.condicaoEnvio);
      }

      this.isRetornoDeliveryTerms = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadPartyTaxSchemas() {
    this.commomService.get(environment.partyTaxSchemas).subscribe(response => {
      this.listOfPartyTaxSchemas = response.body;

      if(this.defaults.partyTaxSchemaId != null) {
        this.defaults.regimeImposto = this.listOfPartyTaxSchemas.find(p => p.id === this.defaults.partyTaxSchemaId);
        this.form.controls['regimeImposto'].setValue(this.defaults.regimeImposto);
      }

      this.isRetornoPartyTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadPartyWithholdingTaxSchemas(){
    this.commomService.get(environment.partyWithholdingTaxSchemas).subscribe(response => {
      this.listOfPartyWithholdingTaxSchemas = response.body;

      if(this.defaults.partyWithholdingTaxSchemaId != null) {
        this.defaults.tipoRetencao = this.listOfPartyWithholdingTaxSchemas.find(p => p.id === this.defaults.partyWithholdingTaxSchemaId);
        this.form.controls['tipoRetencao'].setValue(this.defaults.tipoRetencao);
      }

      this.isRetornoPartyWithholdingTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadPriceLists(){
    this.commomService.get(environment.priceLists).subscribe(response => {
      this.listOfPriceLists = response.body;

      console.log(this.defaults.priceListId);
      if(this.defaults.priceListId != null) {
        this.defaults.listaPreco = this.listOfPriceLists.find(p => p.id === this.defaults.priceListId);
        this.form.controls['listaPreco'].setValue(this.defaults.listaPreco);
      }

      this.isRetornoPriceLists = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }


  verificaRetornoRequisicoes(){
    return     this.isRetornoCountries && this.isRetornoCurrency && this.isRetornoCultures && this.isRetornoCustomerGroup 
            && this.isRetornoPaymentMethods && this.isRetornoPaymentTerms && this.isRetornoDeliveryTerms && this.isRetornoPartyTaxSchemas
            && this.isRetornoPartyWithholdingTaxSchemas && this.isRetornoPriceLists;
  }


  save() {
    if (this.mode === 'create') {
      this.createCliente();
    } else if (this.mode === 'update') {
      this.updateCliente();
    }
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

  setPaisToProperty(cliente: Cliente){
    if(cliente.pais != null){
      cliente.country = cliente.pais.countryKey;
      cliente.countryDescription = cliente.pais.name;
      cliente.countryId = cliente.pais.id;
    }
    
  }

  setMoedaToProperty(cliente: Cliente){
    if(cliente.moeda != null){
      cliente.currency = cliente.moeda.currencyKey;
      cliente.currencyDescription = cliente.moeda.description;
      cliente.currencyId = cliente.moeda.id;
    }
    
  }

  setCulturaToProperty(cliente: Cliente){
    if(cliente.cultura != null){
      cliente.culture = cliente.cultura.cultureKey;
      cliente.cultureDescription = cliente.cultura.name;
      cliente.cultureId = cliente.cultura.id;
    }
  }

  setGrupoClienteToProperty(cliente: Cliente){
    if(cliente.grupoCliente != null){
      cliente.customerGroup = cliente.grupoCliente.customerGroupKey;
      cliente.customerGroupDescription = cliente.grupoCliente.description;
      cliente.customerGroupId = cliente.grupoCliente.id;
    }
  }

  setMetodoPagamentoToProperty(cliente: Cliente){
    if(cliente.metodoPagamento != null){
      cliente.paymentMethod = cliente.metodoPagamento.paymentMethodsKey;
      cliente.paymentMethodDescription = cliente.metodoPagamento.description;
      cliente.paymentMethodId = cliente.metodoPagamento.id;
    }
  }

  setCondicaoPagamentoToProperty(cliente: Cliente){
    if(cliente.condicaoPagamento != null) {
      cliente.paymentTerm = cliente.condicaoPagamento.paymentTermKey;
      cliente.paymentTermDescription = cliente.condicaoPagamento.description;
      cliente.paymentTermId = cliente.condicaoPagamento.id;
    }
  }

  setCondicaoEnvioToProperty(cliente: Cliente){
    if(cliente.condicaoEnvio != null) {
      cliente.deliveryTerm = cliente.condicaoEnvio.deliveryTermKey;
      cliente.deliveryTermDescription = cliente.condicaoEnvio.description;
      cliente.deliveryTermId = cliente.condicaoEnvio.id;
    }
  }

  setRegimeImpostoToProperty(cliente: Cliente){
    console.log("cliente.regimeImposto");
    console.log(cliente.regimeImposto);
    if(cliente.regimeImposto != null) {
      cliente.partyTaxSchema = cliente.regimeImposto.taxCodeGroupKey;
      cliente.partyTaxSchemaDescription = cliente.regimeImposto.description;
      cliente.partyTaxSchemaId = cliente.regimeImposto.id;
    }
  }

  setTipoRetencaoToProperty(cliente: Cliente){
    if(cliente.tipoRetencao != null) {
      cliente.partyWithholdingTaxSchema = cliente.tipoRetencao.partyWithholdingTaxSchemaKey;
      cliente.partyWithholdingTaxSchemaDescription = cliente.tipoRetencao.description;
      cliente.partyWithholdingTaxSchemaId = cliente.tipoRetencao.id;
    }
  }
  
  setListaPrecoToProperty(cliente: Cliente){
    if(cliente.listaPreço != null) {
      cliente.priceList = cliente.listaPreço.priceListKey;
      cliente.priceListDescription = cliente.listaPreço.description;
      cliente.priceListId = cliente.listaPreço.id;
    }
  }


  geraObjeto(cliente : Cliente){
    this.setPaisToProperty(cliente);
    this.setMoedaToProperty(cliente);
    this.setCulturaToProperty(cliente);
    this.setGrupoClienteToProperty(cliente);
    this.setMetodoPagamentoToProperty(cliente);
    this.setCondicaoPagamentoToProperty(cliente);
    this.setCondicaoEnvioToProperty(cliente);
    this.setRegimeImpostoToProperty(cliente);
    this.setTipoRetencaoToProperty(cliente);
    this.setListaPrecoToProperty(cliente);
  }


  createCliente() {
    const cliente = this.form.value;
    this.setPaisToProperty(cliente);
    this.setMoedaToProperty(cliente);
    this.setCulturaToProperty(cliente);
    this.setGrupoClienteToProperty(cliente);
    this.setMetodoPagamentoToProperty(cliente);
    this.setCondicaoPagamentoToProperty(cliente);
    this.setCondicaoEnvioToProperty(cliente);
    this.setRegimeImpostoToProperty(cliente);
    this.setTipoRetencaoToProperty(cliente);
    this.setListaPrecoToProperty(cliente);
    
    this.requisicao = true;
    this.commomService.post(environment.clientes, cliente)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(cliente);
        this.snackBar.open(MessagesSnackBar.CRIAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarClientes').emit();
      },
        (error) => {
          this.requisicao = false;
          this.dialogRef.close(cliente);
          this.snackBar.open(error.error, 'Close', { duration: 10000 });
          EventEmitterService.get('buscarClientes').emit();
          
        });


  }

  updateCliente() {
   
  
    this.montaCliente();
    this.geraObjeto(this.defaults)

    console.log("cliente");
    console.log(this.defaults);

    this.requisicao = true;
    this.commomService.put(environment.clientes, this.defaults)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.defaults);
        this.snackBar.open(MessagesSnackBar.EDITAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarClientes').emit();
      },
        (error) => {
          this.requisicao = false;
          this.snackBar.open(MessagesSnackBar.EDITAR_USUARIO_ERRO, 'Close', { duration: 4000 });
          this.dialogRef.close(this.defaults);
        });

  }

  isCreateMode() {
    return this.mode === 'create';
  }

  isUpdateMode() {
    return this.mode === 'update';
  }

  montaCliente() {

    this.defaults.partyKey= this.form.controls['partyKey'].value;
    this.defaults.name= this.form.controls['name'].value;
    this.defaults.companyTaxID= this.form.controls['companyTaxID'].value;
    this.defaults.countryId= this.form.controls['countryId'].value;
    this.defaults.country= this.form.controls['country'].value;
    this.defaults.countryDescription= this.form.controls['countryDescription'].value;
    this.defaults.pais= this.form.controls['pais'].value;
    this.defaults.currencyId= this.form.controls['currencyId'].value;
    this.defaults.searchTerm= this.form.controls['searchTerm'].value;
    this.defaults.pepperoni= false,
    this.defaults.isPerson= this.form.controls['isPerson'].value;
    this.defaults.streetName= this.form.controls['streetName'].value;
    this.defaults.buildingNumber= this.form.controls['buildingNumber'].value;
    this.defaults.telephone= this.form.controls['telephone'].value;
    this.defaults.electronicMail= this.form.controls['electronicMail'].value;
    this.defaults.cultureId= this.form.controls['cultureId'].value;
    this.defaults.mobile= this.form.controls['mobile'].value;
    this.defaults.websiteUrl= this.form.controls['websiteUrl'].value;
    this.defaults.isIntegration= this.form.controls['isIntegration'].value;
    this.defaults.moeda= this.form.controls['moeda'].value;
    this.defaults.cultura= this.form.controls['cultura'].value;   
    this.defaults.postalZone= this.form.controls['postalZone'].value;   
    this.defaults.cityName= this.form.controls['cityName'].value; 
    this.defaults.settlementDiscountPercent = this.form.controls['settlementDiscountPercent'].value;
    this.defaults.locked = this.form.controls['locked'].value;
    this.defaults.oneTimeCustomer = this.form.controls['oneTimeCustomer'].value;
    this.defaults.endCustomer = this.form.controls['endCustomer'].value;
    this.defaults.grupoCliente = this.form.controls['grupoCliente'].value;
    this.defaults.metodoPagamento = this.form.controls['metodoPagamento'].value;
    this.defaults.condicaoPagamento = this.form.controls['condicaoPagamento'].value;
    this.defaults.condicaoEnvio = this.form.controls['condicaoEnvio'].value;
    this.defaults.tipoRetencao = this.form.controls['tipoRetencao'].value;
    this.defaults.regimeImposto = this.form.controls['regimeImposto'].value;
    this.defaults.listaPreco = this.form.controls['listaPreco'].value;
    


  }
}



