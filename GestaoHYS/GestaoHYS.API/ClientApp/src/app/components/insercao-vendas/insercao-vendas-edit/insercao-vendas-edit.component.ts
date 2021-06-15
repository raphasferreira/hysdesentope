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


  stateCtrl = new FormControl();
  states: CountryState[] = [
    {
      name: 'Arkansas',
      population: '2.978M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Arkansas.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg'
    },
    {
      name: 'California',
      population: '39.14M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_California.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/0/01/Flag_of_California.svg'
    },
    {
      name: 'Florida',
      population: '20.27M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Florida.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg'
    },
    {
      name: 'Texas',
      population: '27.47M',
      // https://commons.wikimedia.org/wiki/File:Flag_of_Texas.svg
      flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg'
    }
  ];
  filteredStates$ = this.stateCtrl.valueChanges.pipe(
    startWith(''),
    map(state => state ? this.filterStates(state) : this.states.slice())
  );


  accountFormGroup: FormGroup;
  passwordFormGroup: FormGroup;
  confirmFormGroup: FormGroup;

  verticalAccountFormGroup: FormGroup;
  verticalPasswordFormGroup: FormGroup;
  verticalConfirmFormGroup: FormGroup;

  phonePrefixOptions = ['+1', '+27', '+44', '+49', '+61', '+91'];

  passwordInputType = 'password';


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


  constructor(private cd: ChangeDetectorRef,private fb: FormBuilder,
    private snackbar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    /**
     * Horizontal Stepper
     * @type {FormGroup}
     */
    this.accountFormGroup = this.fb.group({
      username: [null, Validators.required],
      name: [null, Validators.required],
      email: [null, Validators.required],
      phonePrefix: [this.phonePrefixOptions[3]],
      phone: [],
    });

    this.passwordFormGroup = this.fb.group({
      password: [
        null,
        Validators.compose(
          [
            Validators.required,
            Validators.minLength(6)
          ]
        )
      ],
      passwordConfirm: [null, Validators.required]
    });

    this.confirmFormGroup = this.fb.group({
      terms: [null, Validators.requiredTrue]
    });

    /**
     * Vertical Stepper
     * @type {FormGroup}
     */
    this.verticalAccountFormGroup = this.fb.group({
      username: [null, Validators.required],
      name: [null, Validators.required],
      email: [null, Validators.required],
      phonePrefix: [this.phonePrefixOptions[3]],
      phone: [],
    });

    this.verticalPasswordFormGroup = this.fb.group({
      password: [
        null,
        Validators.compose(
          [
            Validators.required,
            Validators.minLength(6)
          ]
        )
      ],
      passwordConfirm: [null, Validators.required]
    });

    this.verticalConfirmFormGroup = this.fb.group({
      terms: [null, Validators.requiredTrue]
    });
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

  filterStates(name: string) {
    return this.states.filter(state => state.name.toLowerCase().indexOf(name.toLowerCase()) === 0);
  }

  
  showPassword() {
    this.passwordInputType = 'text';
    this.cd.markForCheck();
  }

  hidePassword() {
    this.passwordInputType = 'password';
    this.cd.markForCheck();
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

