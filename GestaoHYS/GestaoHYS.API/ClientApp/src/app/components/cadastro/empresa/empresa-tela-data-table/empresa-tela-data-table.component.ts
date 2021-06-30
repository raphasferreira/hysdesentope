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
import { Empresa } from 'src/app/_models/Empresa';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommomService } from 'src/app/services/commom.service';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import { environment } from 'src/environments/environment';
import { FormControl } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { debounceTime } from 'rxjs/operators';
import icClose from '@iconify/icons-ic/twotone-close';
import { EventEmitterService } from 'src/app/services/event.service';


@Component({
  selector: 'vex-empresa-tela-data-table',
  templateUrl: './empresa-tela-data-table.component.html',
  styleUrls: ['./empresa-tela-data-table.component.scss'],
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
export class EmpresaTelaDataTableComponent<T> implements OnInit, OnChanges, AfterViewInit {

  @Input() data: T[];
  @Input() columns: TableColumn<T>[];
  @Input() pageSize = 20;
  @Input() pageSizeOptions = [10, 20, 50];
  @Input() searchStr: string;

  @Output() toggleStar = new EventEmitter<Contact['id']>();
  @Output() openContact = new EventEmitter<Contact['id']>();

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
    "Nome",
    "NIPC",
    "RazaoSocial",
    "Contato",
    "Email",
    "Acoes"
  ];

dataSource: MatTableDataSource<Empresa>;
listTable: Empresa[] = [];
requisicao: boolean = false;

  constructor(private commomService: CommomService,
              private snackBar: MatSnackBar,
              private dialog: MatDialog) { }

  ngOnInit(){
    EventEmitterService.get('buscarEmpresas').subscribe(()=>this.mostrarEmpresas());
    this.mostrarEmpresas()
  }
  
  result: string;

  openDialog(empresaSelecionado, editar) {
    localStorage.setItem("empresaSelecionada", JSON.stringify(empresaSelecionado))
    if(editar){
      this.dialog.open(DialogWithTableComponent, {
        disableClose: false,
        width: '1000px'
      }).afterClosed().subscribe(result => {
        this.result = result;
        console.log(result);
        
      });
    }else{
      this.dialog.open(DialogDeleteComponent, {
        disableClose: false,
        width: '400px'
      }).afterClosed().subscribe(result => {
        this.result = result;
        if(result == 'yes')this.mostrarEmpresas()
      });
    }
  }

  mostrarEmpresas(){
    this.requisicao = true;
    this.listTable = [];
    this.commomService.get(`${environment.empresas}`)
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
          <div>Editar Empresa</div>
          <button type="button" mat-icon-button (click)="close('No answer')" tabindex="-1">
              <mat-icon [icIcon]="icClose"></mat-icon>
          </button>
      </div>

      <mat-dialog-content>
          <vex-empresa-tela-edit></vex-empresa-tela-edit>
      </mat-dialog-content>


      <mat-dialog-actions align="end">
          <button (click)="close('No')" mat-raised-button color="warn">Cancelar</button>
          <button (click)="salvarEmpresa()" mat-raised-button color="primary">Salvar</button>
      </mat-dialog-actions>
  `
})
export class DialogWithTableComponent implements OnInit{

  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  empresaSelecionada = new Empresa();
  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<DialogWithTableComponent>) {
  }
  
  ngOnInit(): void {
    this.empresaSelecionada = JSON.parse(localStorage.getItem('empresaSelecionada')) as Empresa;
    console.log(this.empresaSelecionada);
    
  }

  salvarEmpresa(){
    EventEmitterService.get('EmpresaAlterada').emit();
    this.close('yes');
    // let body: any = this.empresaSelecionada;
    // this.commomService.post(`${environment.empresas}`, body)
    // .subscribe(() => {
    //   this.snackBar.open(MessagesSnackBar.EDITAR_EMPRESA_SUCESSO, 'Close', { duration: 4000 });

    // },
    // (error) => {
    //   console.log(error.message);
    //   this.snackBar.open(MessagesSnackBar.CRIAR_EMPRESA_ERRO, 'Close', { duration: 4000 });
    // });
  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(ContactsEditComponent, {
    //   data: id || null,
    //   width: '600px'
    // });

  }

  close(answer: string) {
    this.dialogRef.close(answer);
    localStorage.removeItem('empresaSelecionada');
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
          <button (click)="deletarEmpresa()" mat-raised-button color="primary">Sim</button>
      </mat-dialog-actions>
  `
})
export class DialogDeleteComponent implements OnInit{

  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );

  empresaSelecionada = new Empresa();
  requisicao: boolean = false;

  constructor(private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<DialogWithTableComponent>) {
  }
  
  ngOnInit(): void {
    this.empresaSelecionada = JSON.parse(localStorage.getItem('empresaSelecionada')) as Empresa;
    console.log(this.empresaSelecionada);
    
  }

  deletarEmpresa(){
    this.requisicao = true;
    let body: any = this.empresaSelecionada;
    this.commomService.delete(`${environment.empresas}/${this.empresaSelecionada.id}`)
    .subscribe(()=> {
      this.snackBar.open(MessagesSnackBar.DELETAR_EMPRESA_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarEmpresas').emit();
      this.requisicao = false;
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.DELETAR_EMPRESA_ERRO, 'Close', { duration: 4000 });
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
    localStorage.removeItem('empresaSelecionada');
  }
}



