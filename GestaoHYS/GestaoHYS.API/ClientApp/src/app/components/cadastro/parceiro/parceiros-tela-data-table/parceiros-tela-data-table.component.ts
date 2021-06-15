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
import { FormControl } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { debounceTime } from 'rxjs/operators';
import { CommomService } from 'src/app/services/commom.service';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import { environment } from 'src/environments/environment';
import icClose from '@iconify/icons-ic/twotone-close';
import { Parceiro } from 'src/app/_models/Parceiro';
import { EventEmitterService } from 'src/app/services/event.service';

@Component({
  selector: 'vex-parceiros-tela-data-table',
  templateUrl: './parceiros-tela-data-table.component.html',
  styleUrls: ['./parceiros-tela-data-table.component.scss'],
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
export class ParceirosTelaDataTableComponent<T> implements OnInit, OnChanges, AfterViewInit {

  @Input() data: T[];
  @Input() columns: TableColumn<T>[];
  @Input() pageSize = 20;
  @Input() pageSizeOptions = [10, 20, 50];
  @Input() searchStr: string;

  @Output() toggleStar = new EventEmitter<Contact['id']>();
  @Output() openContact = new EventEmitter<Contact['id']>();

  visibleColumns: Array<keyof T | string>;
  // dataSource = new MatTableDataSource<T>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  icMoreVert = icMoreVert;
  icStar = icStar;
  icStarBorder = icStarBorder;
  icDeleteForever = icDeleteForever;
  icEdit = icEdit;

  displayedColumns: string[] = [
    "Nome",
    "NIF",
    "Pais",
    "Celular",
    "Acoes"
  ];

  dataSource: MatTableDataSource<Parceiro>;
  listTable: Parceiro[] = [];
  requisicao: Boolean = false;

  constructor(private commomService: CommomService,
              private snackBar: MatSnackBar,
              private dialog: MatDialog) { }

  ngOnInit(){
    EventEmitterService.get('buscarParceiros').subscribe(()=>this.mostrarParceiros());
    this.mostrarParceiros()
  }
  
  result: string;

  openDialog(pareiroSelecionado, editar) {
    localStorage.setItem("parceiroSelecionado", JSON.stringify(pareiroSelecionado))
    if(editar){
      this.dialog.open(DialogWithTableComponent, {
        disableClose: false,
        width: '1000px'
      }).afterClosed().subscribe(result => {
        this.result = result;
      });
    }else{
      this.dialog.open(DialogDeleteComponent, {
        disableClose: false,
        width: '400px'
      }).afterClosed().subscribe(result => {
        this.result = result;
        if(result == 'yes')this.mostrarParceiros()
      });
    }
  }

  mostrarParceiros(){
    this.requisicao = true
    this.listTable = [];
    this.commomService.get(`${environment.parceiros}`)
    .subscribe(response => {
      this.listTable = response.body;  
      this.dataSource = new MatTableDataSource(this.listTable)   
      this.dataSource.paginator = this.paginator; 
      this.dataSource.sort = this.sort; 
      this.requisicao = false;
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.CRIAR_PARCEIRO_ERRO, 'Close', { duration: 4000 });
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    // if (changes.columns) {
    //   this.visibleColumns = this.columns.map(column => column.property);
    // }

    // if (changes.data) {
    //   this.dataSource.data = this.data;
    // }

    // if (changes.searchStr) {
    //   this.dataSource.filter = (this.searchStr || '').trim().toLowerCase();
    // }
  }

  emitToggleStar(event: Event, id: Contact['id']) {
    event.stopPropagation();
    this.toggleStar.emit(id);
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }
}

@Component({
  selector: 'vex-components-overview-demo-dialog',
  template: `
      <div mat-dialog-title fxLayout="row" fxLayoutAlign="space-between center">
          <div>Editar Parceiro</div>
          <button type="button" mat-icon-button (click)="close('No answer')" tabindex="-1">
              <mat-icon [icIcon]="icClose"></mat-icon>
          </button>
      </div>

      <mat-dialog-content>
          <vex-parceiros-tela-edit></vex-parceiros-tela-edit>
      </mat-dialog-content>


      <mat-dialog-actions align="end">
          <button (click)="close('No')" mat-raised-button color="warn">Cancelar</button>
          <button (click)="salvarParceiro()" mat-raised-button color="primary">Salvar</button>
      </mat-dialog-actions>
  `
})
export class DialogWithTableComponent implements OnInit{

  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );

  // parceirosTelaEditComponent:ParceirosTelaEditComponent
  parceiroSelecionado = new Parceiro();
  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<DialogWithTableComponent>,
    private snackbar: MatSnackBar) {
  }
  
  ngOnInit(): void {
    this.parceiroSelecionado = JSON.parse(localStorage.getItem('parceiroSelecionado')) as Parceiro;
  }
  // this.iniciarFormVazio();

  salvarParceiro(){
    EventEmitterService.get('ParceiroAlterado').emit();
    this.close('yes');
  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(ContactsEditComponent, {
    //   data: id || null,
    //   width: '600px'
    // });

  }

  close(answer: string) {
    this.dialogRef.close(answer);
    localStorage.removeItem('parceiroSelecionado');
  }
}

@Component({
  selector: 'vex-confirma-exclusao-dialog',
  template: `
      <div mat-dialog-title fxLayout="row" fxLayoutAlign="space-between center">
          <div>Deletar Parceiro</div>
          <button type="button" mat-icon-button (click)="close('No answer')" tabindex="-1">
              <mat-icon [icIcon]="icClose"></mat-icon>
          </button>
      </div>

      <mat-dialog-content>
        <div class="alert alert-danger" role="alert">
          Tem Certeza que Deseja Deletar este Parceiro?
        </div>
      </mat-dialog-content>


      <mat-dialog-actions align="end">
          <button (click)="close('No')" mat-raised-button color="warn">Cancelar</button>
          <button (click)="deletarParceiro()" mat-raised-button color="primary">Sim</button>
      </mat-dialog-actions>
  `
})
export class DialogDeleteComponent implements OnInit{

  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  pareiroSelecionado = new Parceiro();
  requisicao: Boolean = false;

  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<DialogWithTableComponent>) {
  }
  
  ngOnInit(): void {
    this.pareiroSelecionado = JSON.parse(localStorage.getItem('parceiroSelecionado')) as Parceiro;
    
  }

  deletarParceiro(){
    this.requisicao = true
    this.commomService.delete(`${environment.parceiros}/${this.pareiroSelecionado.id}`)
    .subscribe(response => {
      this.snackBar.open(MessagesSnackBar.DELETAR_PARCEIRO_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarParceiros').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.DELETAR_PARCEIRO_ERRO, 'Close', { duration: 4000 });
    });
    this.close('yes');
  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(ContactsEditComponent, {
    //   data: id || null,
    //   width: '600px'
    // });

  }

  close(answer: string) {
    this.dialogRef.close(answer);
    localStorage.removeItem('pareiroSelecionado');
  }
}



