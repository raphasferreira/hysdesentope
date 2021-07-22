import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import icVisibility from '@iconify/icons-ic/twotone-visibility';
import icVisibilityOff from '@iconify/icons-ic/twotone-visibility-off';
import icSmartphone from '@iconify/icons-ic/twotone-smartphone';
import icPerson from '@iconify/icons-ic/twotone-person';
import icArrowDropDown from '@iconify/icons-ic/twotone-arrow-drop-down';
import icMenu from '@iconify/icons-ic/twotone-menu';
import icCamera from '@iconify/icons-ic/twotone-camera';
import icPhone from '@iconify/icons-ic/twotone-phone';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { debounceTime, map, startWith } from 'rxjs/operators';
import { fadeInUp400ms } from '../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../@vex/animations/stagger.animation';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { clienteAPIData } from 'src/static-data/clientesAPI';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import format_list_bulleted from '@iconify/icons-ic/format-list-bulleted'
import icEdit from '@iconify/icons-ic/twotone-edit';
import icClose from '@iconify/icons-ic/twotone-close';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Contact } from 'src/static-data/contact';
import { InvoiceTypes } from 'src/app/_models/InvoiceTypes';

export interface CountryState {
  name: string;
  population: string;
  flag: string;
}

@Component({
  selector: 'vex-insercao-vendas-edit',
  templateUrl: './insercao-vendas-edit.component.html',
  styleUrls: ['./insercao-vendas-edit.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class InsercaoVendasEditComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  labelBotao:string='Adiconar Cliente';
  searchCtrl = new FormControl();

  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  @Input() boolGeralCliente: boolean;
  selectCtrl: FormControl = new FormControl();
  inputType = 'password';
  visible = false;

  icPhone = icPhone;
  icCamera = icCamera;
  icMenu = icMenu;
  icArrowDropDown = icArrowDropDown;
  icSmartphone = icSmartphone;
  icPerson = icPerson;
  icVisibility = icVisibility;
  icVisibilityOff = icVisibilityOff;
  icMoreVert = icMoreVert;
  format_list_bulleted =format_list_bulleted;
  icEdit = icEdit;

  listOfInvoiceTypes = new Array<InvoiceTypes>();
  stateCtrl = new FormControl();
 

  

  constructor(private cd: ChangeDetectorRef,private fb: FormBuilder,
    private snackbar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
   
  }

  togglePassword() {
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

  
  submit() {
    this.snackbar.open('Hooray! You successfully created your account.', null, {
      duration: 5000
    });
  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(MailComposeComponent, {
    //   width: '70%',
      
    // });

    //this.trocarTela();
  }

  tableData = clienteAPIData;


  toggleStar(id: Contact['id']) {
    const contact = this.tableData.find(c => c.id === id);

    if (contact) {
      contact.starred = !contact.starred;
    }
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Adiconar Cliente'?'Voltar Lista':'Adiconar Cliente';
   
  }

  result: string;

  openDialog() {
    this.dialog.open(DialogWithTableComponent, {
      disableClose: false,
      width: '800px'
    }).afterClosed().subscribe(result => {
      this.result = result;
    });
  }
}



@Component({
  selector: 'vex-components-overview-demo-dialog',
  template: `
      <div mat-dialog-title fxLayout="row" fxLayoutAlign="space-between center">
          <div>Question</div>
          <button type="button" mat-icon-button (click)="close('No answer')" tabindex="-1">
              <mat-icon [icIcon]="icClose"></mat-icon>
          </button>
      </div>

      <mat-dialog-content>
                            <vex-insercao-vendas-data-table (openContact)=" openContact($event)"
                                (toggleStar)="toggleStar($event)" [columns]="tableColumns" [data]="tableData"
                                [searchStr]="searchStr$ | async">
                            </vex-insercao-vendas-data-table>

      </mat-dialog-content>


      <mat-dialog-actions align="end">
          <button mat-button (click)="close('No')">NO</button>
          <button mat-button color="primary" (click)="close('Yes')">YES</button>
      </mat-dialog-actions>
  `
})
export class DialogWithTableComponent {

  icClose = icClose;

  constructor(private dialogRef: MatDialogRef<DialogWithTableComponent>) {
  }

  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );

  tableColumns: TableColumn<any>[] = [
    {
      label: 'Entidade',
      property: 'entidade',
      type: 'text',
      cssClasses: ['font-medium']
    },
    {
      label: 'Nome',
      property: 'name',
      type: 'text',
      cssClasses: ['font-medium']
    },
    {
      label: 'NIF',
      property: 'companyTaxID',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Termo de Pesquisa',
      property: 'termoPesquisa',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'País',
      property: 'pais',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Telefone',
      property: 'phone',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'EMAIL',
      property: 'electronicMail',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Grupo',
      property: 'grupo',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: '',
      property: 'menu',
      type: 'button',
      cssClasses: ['text-secondary', 'w-10']
    },
  ];



  openContact(id?: Contact['id']) {
    // this.dialog.open(ContactsEditComponent, {
    //   data: id || null,
    //   width: '600px'
    // });

  }

  tableData = clienteAPIData;


  toggleStar(id: Contact['id']) {
    const contact = this.tableData.find(c => c.id === id);

    if (contact) {
      contact.starred = !contact.starred;
    }
  }


  close(answer: string) {
    this.dialogRef.close(answer);
  }
}

