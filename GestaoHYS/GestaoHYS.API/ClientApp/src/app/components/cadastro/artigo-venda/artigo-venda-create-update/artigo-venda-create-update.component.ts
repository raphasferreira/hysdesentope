import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, Input, OnInit } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ArtigoVenda } from 'src/app/_models/ArtigoVenda';

import { CommomService } from 'src/app/services/commom.service';
import { environment } from "src/environments/environment";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';

import { EventEmitterService } from 'src/app/services/event.service';
import { fadeInUp400ms } from '../../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../../@vex/animations/stagger.animation';
import icClose from '@iconify/icons-ic/twotone-close';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import { Customer } from 'src/app/components/relatorio/aio-table/interfaces/customer.model';
import { BaseUnit } from 'src/app/_models/BaseUnit';
import { ItemType } from 'src/app/_models/ItemType';
import { Assortments } from 'src/app/_models/Assortments';
import { Brand } from 'src/app/_models/Brand';
import { BrandModel } from 'src/app/_models/BrandModel';
import { IncomeAccount } from 'src/app/_models/IncomeAccount';
import { ItemTaxSchemas } from 'src/app/_models/ItemTaxSchemas';
import { ItemWithholdingTaxSchemas } from 'src/app/_models/ItemWithholdingTaxSchemas';




@Component({
  selector: 'vex-artigo-venda-create-update',
  templateUrl: './artigo-venda-create-update.component.html',
  styleUrls: [
     './artigo-venda-create-update.component.scss'
    ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class ArtigoVendaCreateUpdateComponent implements OnInit {
  registro: any = {
    ativo: true
  };
  static id = 100;


  mode: 'create' | 'update' = 'create';

  icClose = icClose;
  requisicao: boolean = false;

  artigoVendaModel: ArtigoVenda;
  listOfUnidades: Array<BaseUnit>;
  listOfItemTypes: Array<ItemType>;
  listOfAssortments: Array<Assortments>;
  listOfBrands: Array<Brand>;
  listOfBrandModels: Array<BrandModel>;
  listOfIncomeAccount: Array<IncomeAccount>;
  listOfItemTaxSchemas: Array<ItemTaxSchemas>;
  listOfItemWithholdingTaxSchemas: Array<ItemWithholdingTaxSchemas>;


  isRetornoUnit: boolean = false;
  isRetornoAssortments:  boolean = false;
  isRetornoBrands:  boolean = false;
  isRetornoBrandModels:  boolean = false;

  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
    private dialogRef: MatDialogRef<ArtigoVendaCreateUpdateComponent>,
    private snackBar: MatSnackBar,
    private commomService: CommomService,
    private cd: ChangeDetectorRef) {
  }

  ngOnInit() {

    if (this.defaults) {
      this.mode = 'update';
      this.artigoVendaModel = this.defaults;
    } else {
      this.defaults = new ArtigoVenda();
      this.artigoVendaModel = new ArtigoVenda();
    }
    this.requisicao = true;


    if (this.mode === 'update') {

    }
    this.loadBaseUnit();
    this.loadItemTypes();
    this.loadAssortments();
    this.loadBrand();
    this.loadBrandModel();
  }

  loadBaseUnit() {
    this.commomService.get(environment.unit).subscribe(response => {
      this.listOfUnidades = response.body;
      

      if(this.artigoVendaModel.baseunitId != null){
        const unidade = this.listOfUnidades.find(p => p.id === this.artigoVendaModel.baseunitId);
        this.artigoVendaModel.baseUnit = unidade.unitKey;
        this.artigoVendaModel.baseunitDescription = unidade.description;
        this.artigoVendaModel.baseunitId = unidade.id;
      }

      if(this.artigoVendaModel.unitId != null){
        const unidade = this.listOfUnidades.find(p => p.id === this.artigoVendaModel.unitId);
        this.artigoVendaModel.unit = unidade.unitKey;
        this.artigoVendaModel.unitDescription = unidade.description;
        this.artigoVendaModel.unitId = unidade.id;
      }

      this.isRetornoUnit = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadAssortments() {
    this.commomService.get(environment.assortments).subscribe(response => {
      this.listOfAssortments = response.body;
      

      if(this.artigoVendaModel.assortmentId != null){
        const assortments = this.listOfAssortments.find(p => p.id === this.artigoVendaModel.assortmentId);
        this.artigoVendaModel.assortment = assortments.assortmentKey;
        this.artigoVendaModel.assortmentDescription = assortments.description;
        this.artigoVendaModel.assortmentId = assortments.id;
      }


      this.isRetornoAssortments = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadBrand() {
    this.commomService.get(environment.brands).subscribe(response => {
      this.listOfBrands = response.body;
      

      if(this.artigoVendaModel.brandId != null){
        const brand = this.listOfBrands.find(p => p.id === this.artigoVendaModel.brandId);
        this.artigoVendaModel.brand = brand.brandKey;
        this.artigoVendaModel.brandDescription = brand.description;
        this.artigoVendaModel.brandId = brand.id;
      }


      this.isRetornoBrands = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadBrandModel() {
    this.commomService.get(environment.brandModels).subscribe(response => {
      this.listOfBrandModels = response.body;
      

      if(this.artigoVendaModel.brandModelId != null){
        const brandModels = this.listOfBrandModels.find(p => p.id === this.artigoVendaModel.brandModelId);
        this.artigoVendaModel.brandModel = brandModels.modelKey;
        this.artigoVendaModel.brandModelDescription = brandModels.description;
        this.artigoVendaModel.brandModelId = brandModels.id;
      }


      this.isRetornoBrandModels = true;
      if(this.verificaRetornoRequisicoes()){
        this.requisicao = false;
      }
      
    });
  }

  loadItemTypes() {
    const artigo = new ItemType(1, "Artigo");
    const servico = new ItemType(2, "Servi??o");
    this.listOfItemTypes = new Array<ItemType>();
    this.listOfItemTypes.push(artigo);
    this.listOfItemTypes.push(servico);

  }
 
  verificaRetornoRequisicoes() {
    return this.isRetornoUnit && this.isRetornoAssortments && this.isRetornoBrandModels;
  }


  save() {
    if (this.mode === 'create') {
      this.createArtigoVenda();
    } else if (this.mode === 'update') {
      this.updateArtigoVenda();
    }
  }

  createArtigoVenda() {

    this.requisicao = true;
   
    this.commomService.post(environment.artigoVendas, this.artigoVendaModel)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.artigoVendaModel);
        this.snackBar.open(MessagesSnackBar.CRIAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarArtigoVendas').emit();
      },
        (error) => {
          this.requisicao = false;
          this.dialogRef.close(this.artigoVendaModel);
          this.snackBar.open(error.error, 'Close', { duration: 10000 });
          EventEmitterService.get('buscarArtigoVendas').emit();

        });


  }

  updateArtigoVenda() {

    this.requisicao = true;
    this.commomService.put(environment.artigoVendas, this.defaults)
      .subscribe(response => {
        this.requisicao = false;
        this.dialogRef.close(this.defaults);
        this.snackBar.open(MessagesSnackBar.EDITAR_USUARIO_SUCESSO, 'Close', { duration: 6000 })
        EventEmitterService.get('buscarArtigoVendas').emit();
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



