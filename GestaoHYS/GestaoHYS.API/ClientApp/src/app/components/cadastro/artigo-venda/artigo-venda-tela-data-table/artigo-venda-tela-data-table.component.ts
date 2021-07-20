import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import icStar from '@iconify/icons-ic/twotone-star';
import icStarBorder from '@iconify/icons-ic/twotone-star-border';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import icEdit from '@iconify/icons-ic/twotone-edit';
import icDeleteForever from '@iconify/icons-ic/twotone-delete-forever';
import { MatTableDataSource } from '@angular/material/table';
import { ArtigoVenda } from 'src/app/_models/ArtigoVenda';
import { CommomService } from 'src/app/services/commom.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldDefaultOptions, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { scaleFadeIn400ms } from 'src/@vex/animations/scale-fade-in.animation';
import { stagger20ms } from 'src/@vex/animations/stagger.animation';
import { environment } from "src/environments/environment";
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import { Contact } from 'src/static-data/contact';
import { EventEmitterService } from 'src/app/services/event.service';
import { ReplaySubject } from 'rxjs';
import { ArtigoVendaCreateUpdateComponent } from '../artigo-venda-create-update/artigo-venda-create-update.component';


@Component({
  selector: 'vex-artigo-venda-tela-data-table',
  templateUrl: './artigo-venda-tela-data-table.component.html',
  styleUrls: ['./artigo-venda-tela-data-table.component.scss'],
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

export class ArtigoVendaTelaDataTableComponent<T> implements OnInit, OnChanges, AfterViewInit {
  subject$: ReplaySubject<ArtigoVenda[]> = new ReplaySubject<ArtigoVenda[]>(1);
  
  @Input() data: T[];
  @Input() columns: TableColumn<T>[];
  @Input() pageSize = 20;
  @Input() pageSizeOptions = [10, 20, 50];
  @Input() searchStr: string;
  
  visibleColumns: Array<keyof T | string>;
  // dataSource = new MatTableDataSource<T>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  icMoreVert = icMoreVert;
  icStar = icStar;
  icStarBorder = icStarBorder;
  icDeleteForever = icDeleteForever;
  icEdit = icEdit;

  displayedColumns: string[] = [
    "Artigo",
    "Descricao",
    "Marca",
    "Modelo",
    "Familia",
    "Unidade",
    "Integrar",
    "Acoes"
  ];

  @Output() toggleStar = new EventEmitter<Contact['id']>();

  dataSource: MatTableDataSource<ArtigoVenda>;
  listTable: ArtigoVenda[] = [];
  requisicao: boolean = false;

  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    EventEmitterService.get('buscarArtigoVendas').subscribe(()=>this.mostrarArtigoVendas());
    this.mostrarArtigoVendas();
  }

  ngOnChanges(changes: SimpleChanges): void {
    
  }

  ngAfterViewInit() {
  }

  openDialog(empresaSelecionado, editar) {
    
  }

  mostrarArtigoVendas(){
    this.requisicao = true
    this.listTable = [];
    this.commomService.get(environment.artigoVendas)
    .subscribe(response => {
      if(response.body){
        this.listTable = response.body;  
      }
      else{
        this.listTable = new Array<ArtigoVenda>();
      }
      this.dataSource = new MatTableDataSource(this.listTable)   
      this.dataSource.paginator = this.paginator; 
      this.dataSource.sort = this.sort; 
      this.requisicao = false;
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.BUSCAR_ARTIGOVENDA_ERRO, 'Close', { duration: 4000 });
    });
  }

  emitToggleStar(event: Event, id: Contact['id']) {
    event.stopPropagation();
    this.toggleStar.emit(id);
  }

  updateArtigoVenda(cliente) {
    console.log(cliente);
    this.dialog.open(ArtigoVendaCreateUpdateComponent, {
      data: cliente
    });
  }

  // deleteArtigoVenda(cliente) {

  //   this.dialog.open(ArtigoVendaDeleteComponent, {
  //     data: cliente
  //   });
  // }
}
