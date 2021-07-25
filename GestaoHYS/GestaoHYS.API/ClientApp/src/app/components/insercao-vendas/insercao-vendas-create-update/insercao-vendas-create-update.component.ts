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


  mode: 'create' | 'update' = 'create';

  icClose = icClose;
  requisicao: boolean = false;
  icAdd = icAdd;

  faturaModel: Invoice;
  listOfInvoiceTypes: Array<InvoiceTypes>;
  listOfSeries: Array<Series>;
  listOfClientes: Array<Cliente>;
  listOfPaymentTerms: Array<PaymentTerms>;
  listOfPaymentMethod: Array<PaymentMethods>;
  listOfArtigoVenda: Array<ArtigoVenda>;
  listOfWarehouses: Array<Warehouses>;
  listOfUnidades: Array<BaseUnit>;
  listOfItemTaxSchemas: Array<ItemTaxSchemas>;
  listOfItemWithholdingTaxSchemas: Array<ItemWithholdingTaxSchemas>;
  
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
  }

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
      }
      
    });
  }

  loadArtigoVenda() {
    this.commomService.get(environment.artigoVendas).subscribe(response => {
      this.listOfArtigoVenda = response.body;

      this.isRetornoArtigoVenda = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadWarehouses() {
    this.commomService.get(environment.warehouses).subscribe(response => {
      this.listOfWarehouses = response.body;

      this.isRetornoWarehouses = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadBaseUnit() {
    this.commomService.get(environment.unit).subscribe(response => {
      this.listOfUnidades = response.body;
      
      this.isRetornoUnit = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadItemTaxSchemas() {
    this.commomService.get(environment.itemTaxSchemas).subscribe(response => {
      this.listOfItemTaxSchemas = response.body;

      this.isRetornoItemTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadItemWithholdingTaxSchemas(){
    this.commomService.get(environment.itemWithholdingTaxSchemas).subscribe(response => {
      this.listOfItemWithholdingTaxSchemas = response.body;

      this.isRetornoItemWithholdingTaxSchemas = true; 
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  verificaRetornoRequisicoes() {
    return this.isRetornoInvoiceTypes && this.isRetornoSeries && this.isRetornoCliente 
    && this.isRetornoPaymentTerms && this.isRetornoArtigoVenda && this.isRetornoWarehouses
    && this.isRetornoUnit && this.isRetornoItemTaxSchemas && this.isRetornoItemWithholdingTaxSchemas;
  }

  updateList(id: number, property: string, event: any) {
    // const editField = event.target.textContent;
    // this.personList[id][property] = editField;
  }

  remove(id: any) {
    // this.awaitingPersonList.push(this.personList[id]);
    // this.personList.splice(id, 1);
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

    this.requisicao = true;
   
    this.commomService.post(environment.invoice, this.faturaModel)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.faturaModel);
        this.snackBar.open(MessagesSnackBar.CRIAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarInsercaoVendass').emit();
      },
        (error) => {
          this.requisicao = false;
          this.dialogRef.close(this.faturaModel);
          this.snackBar.open(error.error, 'Close', { duration: 10000 });
          EventEmitterService.get('buscarInsercaoVendass').emit();

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



