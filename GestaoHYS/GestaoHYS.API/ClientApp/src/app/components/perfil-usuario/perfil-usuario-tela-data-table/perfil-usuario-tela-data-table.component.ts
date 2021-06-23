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
import { PerfilUsuario } from 'src/app/_models/PerfilUsuario';
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
import { PerfilUsuarioCreateUpdateComponent } from '../perfil-usuario-create-update/perfil-usuario-create-update.component';
import { PerfilUsuarioDeleteComponent } from '../perfil-usuario-delete/perfil-usuario-delete.component';
import { EventEmitterService } from 'src/app/services/event.service';

@Component({
  selector: 'vex-perfil-usuario-tela-data-table',
  templateUrl: './perfil-usuario-tela-data-table.component.html',
  styleUrls: ['./perfil-usuario-tela-data-table.component.scss'],
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

export class PerfilUsuarioTelaDataTableComponent<T> implements OnInit, OnChanges, AfterViewInit {

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
    "descricao",
    "Acoes"
  ];

  @Output() toggleStar = new EventEmitter<Contact['id']>();

  dataSource: MatTableDataSource<PerfilUsuario>;
  listTable: PerfilUsuario[] = [];
  requisicao: boolean = false;

  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    EventEmitterService.get('buscarPerfilUsuarios').subscribe(()=>this.mostrarPerfilUsuarios());
    this.mostrarPerfilUsuarios();
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

  ngAfterViewInit() {
  }

  openDialog(empresaSelecionado, editar) {

  }

  mostrarPerfilUsuarios() {
    this.requisicao = true
    this.listTable = [];
    this.commomService.get(environment.perfilUsuario)
      .subscribe(response => {
        this.listTable = response.body;
        this.dataSource = new MatTableDataSource(this.listTable)
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.requisicao = false;
      },
        (error) => {
          console.log(error.message);
          this.snackBar.open(MessagesSnackBar.CRIAR_PERFIL_USUARIO_ERRO, 'Close', { duration: 4000 });
        });
  }

  emitToggleStar(event: Event, id: Contact['id']) {
    event.stopPropagation();
    this.toggleStar.emit(id);
  }

  updatePerfilUsuario(usuario) {

    this.dialog.open(PerfilUsuarioCreateUpdateComponent, {
      data: usuario
    });
  }

  deletePerfilUsuario(usuario) {

    this.dialog.open(PerfilUsuarioDeleteComponent, {
      data: usuario
    });
  }
}
