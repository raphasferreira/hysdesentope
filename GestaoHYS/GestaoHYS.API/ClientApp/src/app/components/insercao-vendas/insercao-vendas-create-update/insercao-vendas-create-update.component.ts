import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, Input, OnInit } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Invoice } from 'src/app/_models/Invoice';

import { CommomService } from 'src/app/services/commom.service';
import { environment } from "src/environments/environment";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';

import { EventEmitterService } from 'src/app/services/event.service';
import { fadeInUp400ms } from '../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../@vex/animations/stagger.animation';
import icClose from '@iconify/icons-ic/twotone-close';

import { InvoiceTypes } from 'src/app/_models/InvoiceTypes';
import { Series } from 'src/app/_models/Series';
import { Cliente } from 'src/app/_models/Cliente';
import { PaymentTerms } from 'src/app/_models/PaymentTerms';
import { PaymentMethods } from 'src/app/_models/PaymentMethods';
import icAdd from '@iconify/icons-ic/twotone-add';
import { DocumentLines } from 'src/app/_models/DocumentLines';
import { ArtigoVenda } from 'src/app/_models/ArtigoVenda';
import { Warehouses } from 'src/app/_models/Warehouses';
import { BaseUnit } from 'src/app/_models/BaseUnit';
import { ItemTaxSchemas } from 'src/app/_models/ItemTaxSchemas';
import { ItemWithholdingTaxSchemas } from 'src/app/_models/ItemWithholdingTaxSchemas';
import icDelete from '@iconify/icons-ic/twotone-delete';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';


@Component({
  selector: 'vex-insercao-vendas-create-update',
  templateUrl: './insercao-vendas-create-update.component.html',
  styleUrls: [
     './insercao-vendas-create-update.component.scss'
    ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})

export class InsercaoVendasCreateUpdateComponent implements OnInit {
  registro: any = {
    ativo: true
  };
  static id = 100;
 

  
  listOfSeries: Array<Series> = new Array<Series>();
  myControlSerie = new FormControl();
  filteredOptionsSeries: Observable<Array<Series>>;


  selectedOpt: string;
  mode: 'create' | 'update' = 'create';

  icClose = icClose;
  requisicao: boolean = false;
  icAdd = icAdd;
  icDelete = icDelete;

  faturaModel: Invoice = new Invoice();
  
  listOfInvoiceTypes: Array<InvoiceTypes>  = new Array<InvoiceTypes>();
  myControlInvoiceTypes = new FormControl();
  filteredOptionsInvoiceTypes: Observable<Array<InvoiceTypes>>;

  listOfClientes:Array<Cliente> = new Array<Cliente>();
  myControlCliente = new FormControl();
  filteredOptionsCliente: Observable<Array<Cliente>>;
  
  listOfPaymentTerms: Array<PaymentTerms> = new Array<PaymentTerms>();
  myControlPaymentTerms = new FormControl();
  filteredOptionsPaymentTerms: Observable<Array<PaymentTerms>>;

  listOfPaymentMethod: Array<PaymentMethods>= new Array<PaymentMethods>();
  myControlPaymentMethods = new FormControl();
  filteredOptionsPaymentMethods: Observable<Array<PaymentMethods>>;

  listOfArtigoVenda: Array<ArtigoVenda>= new Array<ArtigoVenda>();
  myControlArtigoVenda = new FormControl();
  filteredOptionsArtigoVenda: Observable<Array<ArtigoVenda>>;

  listOfWarehouses: Array<Warehouses>= new Array<Warehouses>();
  myControlWarehouses = new FormControl();
  filteredOptionsWarehouses: Observable<Array<Warehouses>>;

  listOfUnidades: Array<BaseUnit>= new Array<BaseUnit>();
  myControlUnidades = new FormControl();
  filteredOptionsUnidades: Observable<Array<BaseUnit>>;

  listOfItemTaxSchemas: Array<ItemTaxSchemas>= new Array<ItemTaxSchemas>();
  myControlItemTaxSchemas = new FormControl();
  filteredOptionsItemTaxSchemas: Observable<Array<ItemTaxSchemas>>;

  listOfItemWithholdingTaxSchemas: Array<ItemWithholdingTaxSchemas>= new Array<ItemWithholdingTaxSchemas>();
  myControlItemWithholdingTaxSchemas = new FormControl();
  filteredOptionsItemWithholdingTaxSchemas: Observable<Array<ItemWithholdingTaxSchemas>>;
  
  cssClasses: ['font-medium'];

  isRetornoInvoiceTypes: boolean = false;
  isRetornoSeries: boolean = false;
  isRetornoCliente: boolean = false;
  isRetornoPaymentTerms: boolean = false;
  isRetornoPaymentMethod: boolean = false;
  isRetornoArtigoVenda: boolean = false;
  isRetornoWarehouses: boolean = false;
  isRetornoUnit: boolean = false;
  isRetornoItemTaxSchemas: boolean = false;
  isRetornoItemWithholdingTaxSchemas: boolean = false;


  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
    private dialogRef: MatDialogRef<InsercaoVendasCreateUpdateComponent>,
    private snackBar: MatSnackBar,
    private commomService: CommomService,
    private cd: ChangeDetectorRef) {
  }

  ngOnInit() {

    if (this.defaults) {
      this.mode = 'update';
      this.faturaModel = this.defaults;
    } else {
      this.defaults = new Invoice();
      this.faturaModel = new Invoice();
    }
    this.requisicao = true;


    if (this.mode === 'update') {

    }
    this.loadInvoiceTypes();
    this.loadSeries();
    this.loadCliente();
    this.loadPaymentTerms();
    this.loadPaymentMethods();
    this.loadArtigoVenda();
    this.loadWarehouses();
    this.loadBaseUnit();
    this.loadItemTaxSchemas();
    this.loadItemWithholdingTaxSchemas();


    this.filteredOptionsSeries = this.myControlSerie.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
    
    this.filteredOptionsInvoiceTypes = this.myControlInvoiceTypes.valueChanges.pipe(
      startWith(''),
      map(value => this._filterInvoiceTypes(value))
    );

    this.filteredOptionsCliente = this.myControlCliente.valueChanges.pipe(
      startWith(''),
      map(value => this._filterCliente(value))
    );

    this.filteredOptionsPaymentTerms = this.myControlPaymentTerms.valueChanges.pipe(
      startWith(''),
      map(value => this._filterPaymentTerms(value))
    );

    this.filteredOptionsPaymentMethods = this.myControlPaymentMethods.valueChanges.pipe(
      startWith(''),
      map(value => this._filterPaymentMethods(value))
    );


    this.filteredOptionsArtigoVenda = this.myControlArtigoVenda.valueChanges.pipe(
      startWith(''),
      map(value => this._filterArtigoVenda(value))
    );

    this.filteredOptionsWarehouses = this.myControlWarehouses.valueChanges.pipe(
      startWith(''),
      map(value => this._filterWarehouses(value))
    );

    this.filteredOptionsUnidades = this.myControlUnidades.valueChanges.pipe(
      startWith(''),
      map(value => this._filterBaseUnit(value))
    );

    this.filteredOptionsItemTaxSchemas = this.myControlItemTaxSchemas.valueChanges.pipe(
      startWith(''),
      map(value => this._filterItemTaxSchemas(value))
    );

    this.filteredOptionsItemWithholdingTaxSchemas = this.myControlItemWithholdingTaxSchemas.valueChanges.pipe(
      startWith(''),
      map(value => this._filterItemWithholdingTaxSchemas(value))
    );
  }

  private _filterInvoiceTypes(value: string) : InvoiceTypes[] {
    const filterValue = value.toLowerCase();
    return this.listOfInvoiceTypes.filter(option => option.typeKey.toLowerCase().includes(filterValue));
    
  }

  private _filter(value: string) : Series[] {
    const filterValue = value.toLowerCase();
    return this.listOfSeries.filter(option => option.serieKey.toLowerCase().includes(filterValue));
  }

  private _filterCliente(value: string) : Cliente[] {
    const filterValue = value.toLowerCase();
    return this.listOfClientes.filter(option => option.partyKey.toLowerCase().includes(filterValue));
  }

  private _filterPaymentTerms(value: string) : PaymentTerms[] {
    const filterValue = value.toLowerCase();
    return this.listOfPaymentTerms.filter(option => option.paymentTermKey.toLowerCase().includes(filterValue));
  }

  private _filterPaymentMethods(value: string) : PaymentMethods[] {
    const filterValue = value.toLowerCase();
    return this.listOfPaymentMethod.filter(option => option.paymentMethodsKey.toLowerCase().includes(filterValue));
  }

  private _filterArtigoVenda(value: string) : ArtigoVenda[] {
    const filterValue = value.toLowerCase();
    return this.listOfArtigoVenda.filter(option => option.ItemKey.toLowerCase().includes(filterValue));
  }

  

  // private _filterPaymentMethods(value: string) : PaymentMethods[] {
  //   const filterValue = value.toLowerCase();
  //   return this.listOfPaymentMethod.filter(option => option.paymentMethodsKey.toLowerCase().includes(filterValue));
  // }

  // private _filterPaymentMethods(value: string) : PaymentMethods[] {
  //   const filterValue = value.toLowerCase();
  //   return this.listOfPaymentMethod.filter(option => option.paymentMethodsKey.toLowerCase().includes(filterValue));
  // }

  // private _filterPaymentMethods(value: string) : PaymentMethods[] {
  //   const filterValue = value.toLowerCase();
  //   return this.listOfPaymentMethod.filter(option => option.paymentMethodsKey.toLowerCase().includes(filterValue));
  // }

  // private _filterPaymentMethods(value: string) : PaymentMethods[] {
  //   const filterValue = value.toLowerCase();
  //   return this.listOfPaymentMethod.filter(option => option.paymentMethodsKey.toLowerCase().includes(filterValue));
  // }

  loadInvoiceTypes() {
    this.commomService.get(environment.invoiceTypes).subscribe(response => {
      this.listOfInvoiceTypes = response.body;
      

      if(this.faturaModel.documentType != null){
        const invoiceType = this.listOfInvoiceTypes.find(p => p.typeKey === this.faturaModel.documentType);
        this.faturaModel.documentType = invoiceType.typeKey;
        this.faturaModel.documentTypeDescription = invoiceType.description;
        this.faturaModel.documentTypeId = invoiceType.id;
      }

      this.isRetornoInvoiceTypes = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadSeries() {
    this.commomService.get(environment.series).subscribe(response => {
      this.listOfSeries = response.body;

      if(this.faturaModel.serie != null){
        const serie = this.listOfSeries.find(p => p.serieKey === this.faturaModel.serie);
        this.faturaModel.serie = serie.serieKey;
        this.faturaModel.serieDescription = serie.description;
        this.faturaModel.serieId = serie.id;
      }

      this.isRetornoSeries = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      

    });
  }

  loadCliente() {
    this.commomService.get(environment.clientes).subscribe(response => {
      this.listOfClientes = response.body;
      

      if(this.faturaModel.buyerCustomerParty != null){
        const retorno = this.listOfClientes.find(p => p.partyKey === this.faturaModel.buyerCustomerParty);
        this.faturaModel.buyerCustomerParty = retorno.partyKey;
        this.faturaModel.buyerCustomerPartyName = retorno.name;
        this.faturaModel.buyerCustomerPartyId = retorno.idReferencia;
      }

      this.isRetornoCliente = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadPaymentTerms() {
    this.commomService.get(environment.paymentTerms).subscribe(response => {
      this.listOfPaymentTerms = response.body;
      

      if(this.faturaModel.paymentTerm != null){
        const retorno = this.listOfPaymentTerms.find(p => p.paymentTermKey === this.faturaModel.paymentTerm);
        this.faturaModel.paymentTerm = retorno.paymentTermKey;
        this.faturaModel.paymentTermDescription = retorno.description;
        this.faturaModel.paymentTermId = retorno.id;
      }

      this.isRetornoPaymentTerms = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadPaymentMethods() {
    this.commomService.get(environment.paymentMethods).subscribe(response => {
      this.listOfPaymentMethod = response.body;
      

      if(this.faturaModel.paymentMethod != null){
        const retorno = this.listOfPaymentMethod.find(p => p.paymentMethodsKey === this.faturaModel.paymentMethod);
        this.faturaModel.paymentMethod = retorno.paymentMethodsKey;
        this.faturaModel.paymentMethodDescription = retorno.description;
        this.faturaModel.paymentMethodId = retorno.id;
      }

      this.isRetornoPaymentTerms = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadArtigoVenda() {
    this.commomService.get(environment.artigoVendas).subscribe(response => {
      this.listOfArtigoVenda = response.body;

      this.isRetornoArtigoVenda = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadWarehouses() {
    this.commomService.get(environment.warehouses).subscribe(response => {
      this.listOfWarehouses = response.body;

      this.isRetornoWarehouses = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadBaseUnit() {
    this.commomService.get(environment.unit).subscribe(response => {
      this.listOfUnidades = response.body;
      
      this.isRetornoUnit = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadItemTaxSchemas() {
    this.commomService.get(environment.itemTaxSchemas).subscribe(response => {
      this.listOfItemTaxSchemas = response.body;

      this.isRetornoItemTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  loadItemWithholdingTaxSchemas(){
    this.commomService.get(environment.itemWithholdingTaxSchemas).subscribe(response => {
      this.listOfItemWithholdingTaxSchemas = response.body;

      this.isRetornoItemWithholdingTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
        document.getElementById("documentFocus").focus();
      }
      
    });
  }

  verificaRetornoRequisicoes() {
    return this.isRetornoInvoiceTypes && this.isRetornoSeries && this.isRetornoCliente 
    && this.isRetornoPaymentTerms && this.isRetornoArtigoVenda && this.isRetornoWarehouses
    && this.isRetornoUnit && this.isRetornoItemTaxSchemas && this.isRetornoItemWithholdingTaxSchemas;
  }

  remove(id: any) {
    this.faturaModel.documentLines.splice(id, 1);
  }

  changeArtigoVenda(event, itemArtigo){
    let artigoSelecionado = this.listOfArtigoVenda.find(a => a.ItemKey == event.value);
    itemArtigo.unit = artigoSelecionado.unit;
  }

  add() {
    if (this.faturaModel.documentLines != null && this.faturaModel.documentLines.length > 0) {
      const artigo = new DocumentLines();
      this.faturaModel.documentLines.push(artigo);
    }
    else{
      const artigo = new DocumentLines();
      this.faturaModel.documentLines = new Array<DocumentLines>();
      this.faturaModel.documentLines.push(artigo);
    }
  }

  changeValue(id: number, property: string, event: any) {
    // this.editField = event.target.textContent;
  }
  


  save() {
    if (this.mode === 'create') {
      this.createInsercaoVendas();
    } else if (this.mode === 'update') {
      this.updateInsercaoVendas();
    }
  }

  createInsercaoVendas() {

    if(this.faturaModel.documentType == null){
      this.snackBar.open("Tipo de Documento é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.serie == null){
      this.snackBar.open("Serie é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.documentDate == null){
      this.snackBar.open("Data do Documento é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.buyerCustomerParty == null){
      this.snackBar.open("Cliente é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.paymentTerm == null){
      this.snackBar.open("Condição de Pagamento é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.dueDate == null){
      this.snackBar.open("Data de vencimento é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.paymentMethod == null){
      this.snackBar.open("Método de Pagamento é obrigátorio.", 'Close', { duration: 10000 });
      return;
    }

    if(this.faturaModel.documentLines == null || this.faturaModel.documentLines.length < 1){
      this.snackBar.open("O documento deve ter pelo menos uma linha de ´Produto e Serviços.", 'Close', { duration: 10000 });
      return;
    }

    let falhaItens = false;
    this.faturaModel.documentLines.forEach(element => {
      if(element.salesItem == null){
          this.snackBar.open("Artigo é obrigátorio.", 'Close', { duration: 10000 });
          falhaItens = true;
          return;
      }

      if(element.warehouse == null){
        this.snackBar.open("Armazém do artigo - "+ element.salesItem + " é obrigátorio.", 'Close', { duration: 10000 });
        falhaItens = true;
        return;
      }

      if(element.quantity == null){
        this.snackBar.open("Quantidade do artigo - "+ element.salesItem + "  é obrigátorio.", 'Close', { duration: 10000 });
        falhaItens = true;
        return;
      }

      if(element.unit == null){
        this.snackBar.open("Unidade do artigo - "+ element.salesItem + "  é obrigátorio.", 'Close', { duration: 10000 });
        falhaItens = true;
        return;
      }

      if(element.unitPrice == null){
        this.snackBar.open("Preço Unitário do artigo - "+ element.salesItem + "  é obrigátorio.", 'Close', { duration: 10000 });
        falhaItens = true;
        return;
      }

      if(element.itemTaxSchema == null){
        this.snackBar.open("Tipo de imposto do artigo - "+ element.salesItem + "  é obrigátorio.", 'Close', { duration: 10000 });
        falhaItens = true;
        return;
      }
    }); 

    if(falhaItens){
      return;
    }

    this.requisicao = true;
   
    this.commomService.post(environment.invoice, this.faturaModel)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.faturaModel);
        this.snackBar.open(MessagesSnackBar.CRIAR_INVOICE_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarInsercaoVendas').emit();
      },
        (error) => {
          this.requisicao = false;
          this.dialogRef.close(this.faturaModel);
          console.log(error);
          this.snackBar.open(error.error, 'Close', { duration: 10000 });
          EventEmitterService.get('buscarInsercaoVendas').emit();

        });


  }

  updateInsercaoVendas() {

    this.requisicao = true;
    this.commomService.put(environment.invoice, this.defaults)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.defaults);
        this.snackBar.open(MessagesSnackBar.EDITAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarInsercaoVendass').emit();
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


}



