import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import icStar from '@iconify/icons-ic/twotone-star';
import icStarBorder from '@iconify/icons-ic/twotone-star-border';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import icEdit from '@iconify/icons-ic/twotone-edit';
import icDeleteForever from '@iconify/icons-ic/twotone-delete-forever';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldDefaultOptions } from '@angular/material/form-field';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { scaleFadeIn400ms } from 'src/@vex/animations/scale-fade-in.animation';
import { stagger20ms } from 'src/@vex/animations/stagger.animation';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import { Contact } from 'src/static-data/contact';
import { CommomService } from 'src/app/services/commom.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { EventEmitterService } from 'src/app/services/event.service';
import { environment } from 'src/environments/environment';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import { FormControl } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import icSearch from '@iconify/icons-ic/twotone-search';
import { Titulos } from 'src/app/_models/Titulos';
import { TitulosPagamentosComponent } from '../titulos-pagamentos/titulos-pagamentos.component';

@UntilDestroy()
@Component({
  selector: 'vex-titulos-data-table',
  templateUrl: './titulos-data-table.component.html',
  styleUrls: ['./titulos-data-table.component.scss'],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: {
        appearance: 'standard'
      } as MatFormFieldDefaultOptions
    }
  ],
  animations: [
    stagger20ms,
    fadeInUp400ms,
    scaleFadeIn400ms
  ]
  
})
export class TitulosDataTableComponent<T> implements OnInit, OnChanges, AfterViewInit {

  @Input() data: T[];
  @Input() columns: TableColumn<T>[];
  @Input() pageSize = 20;
  @Input() pageSizeOptions = [10, 20, 50];
  @Input() searchStr: string;

  @Output() toggleStar = new EventEmitter<Contact['id']>();
  @Output() openContact = new EventEmitter<Contact['id']>();

  visibleColumns: Array<keyof T | string>;
  dataSource: MatTableDataSource<Titulos>;
  listTable: Titulos[] = [];
  requisicao: boolean = false;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  icMoreVert = icMoreVert;
  icStar = icStar;
  icStarBorder = icStarBorder;
  icDeleteForever = icDeleteForever;
  icEdit = icEdit;
  icSearch = icSearch;

  displayedColumns: string[] = [
    "Data",
    "Vencimento",
    "Valor",
    "Referencia",
    "Status",
    "Acoes"
  ];
  searchCtrl = new FormControl();

  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog) { }

  ngOnInit() {
    EventEmitterService.get('buscarTitulos').subscribe(()=>this.mostrarTitulos());
    this.mostrarTitulos();

    this.searchCtrl.valueChanges.pipe(
      untilDestroyed(this)
    ).subscribe(value => this.onFilterChange(value));
  }

  filterTitulos(value){
    if(this.listTable){
      if(value != 0){
        let listafiltrada = this.listTable.filter(t => t.statusTitulo == value);
        this.dataSource = new MatTableDataSource(listafiltrada)   
        this.dataSource.paginator = this.paginator; 
        this.dataSource.sort = this.sort;
      }
      else{
        this.dataSource = new MatTableDataSource(this.listTable)   
        this.dataSource.paginator = this.paginator; 
        this.dataSource.sort = this.sort;
      }
      
    }
  }

  mostrarTitulos(){
    this.requisicao = true
    this.listTable = [];
    this.commomService.get(environment.titulos)
    .subscribe(response => {
      console.log("TITULOS")
      console.log(response.body)
      if(response.body){
        this.listTable = response.body;  
      }
      else{
        this.listTable = new Array<Titulos>();
      }
      this.dataSource = new MatTableDataSource(this.listTable)   
      this.dataSource.paginator = this.paginator; 
      this.dataSource.sort = this.sort; 
      this.requisicao = false;
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.BUSCAR_TITULOS_ERRO, 'Close', { duration: 4000 });
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    
  }

  emitToggleStar(event: Event, id: Contact['id']) {
    event.stopPropagation();
    this.toggleStar.emit(id);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  realizarPagamento(titulo) {

    this.dialog.open(TitulosPagamentosComponent, {
      data: titulo
    });
  }

  onFilterChange(value: string) {
    if (!this.dataSource) {
      return;
    }
    value = value.trim();
    value = value.toLowerCase();
    this.dataSource.filter = value;
  }
}

