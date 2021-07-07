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

  requisicao: boolean = false;
  isRetornoCountries: boolean = false;
  isRetornoCurrency: boolean = false;
  isRetornoCultures: boolean = false;

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
      postalZone: [this.defaults.postalZone || null, []]
    });

    this.requisicao = true;
    this.loadCountries();
    this.loadCurrencies();
    this.loadCultures();
   
  }


  loadCountries() {
    this.commomService.get(environment.countries).subscribe(response => {
      this.listOfCountries = response.body;
      

      if(this.defaults.countryId != null){
          this.defaults.pais = this.listOfCountries.find(p => p.id === this.defaults.countryId);
          this.form.controls['pais'].setValue(this.defaults.pais);
      }
      this.isRetornoCountries = true;
      if(this.isRetornoCountries && this.isRetornoCurrency && this.isRetornoCultures){
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
      if(this.isRetornoCountries && this.isRetornoCurrency && this.isRetornoCultures){
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
      if(this.isRetornoCountries && this.isRetornoCurrency && this.isRetornoCultures){
        this.requisicao = false;
      }
      
    });
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

  createCliente() {
    const cliente = this.form.value;
    this.setPaisToProperty(cliente);
    this.setMoedaToProperty(cliente);
    this.setCulturaToProperty(cliente);

    this.commomService.post(environment.clientes, cliente)
      .subscribe(response => {
        this.dialogRef.close(cliente);
        this.snackBar.open(MessagesSnackBar.CRIAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarClientes').emit();
      },
        (error) => {
       
          this.snackBar.open(error.error, 'Close', { duration: 10000 });
          
        });


  }

  updateCliente() {
   
  
    this.montaCliente();
    console.log("update");
    this.setPaisToProperty(this.defaults);
    console.log("setPaisToProperty");
    this.setMoedaToProperty(this.defaults);
    console.log("setMoedaToProperty");
    this.setCulturaToProperty(this.defaults);
    console.log("setCulturaToProperty");

    this.commomService.put(environment.clientes, this.defaults)
      .subscribe(response => {
        console.log(response);
        this.dialogRef.close(this.defaults);
        this.snackBar.open(MessagesSnackBar.EDITAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarClientes').emit();
      },
        (error) => {
          console.log(error);
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
    console.log("montaCliente");
    console.log(this.form.controls['partyKey'].value);
    console.log(this.defaults.partyKey);
  
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
  }
}



