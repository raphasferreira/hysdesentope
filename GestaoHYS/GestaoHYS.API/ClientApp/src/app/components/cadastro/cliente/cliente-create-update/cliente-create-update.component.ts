import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import icMoreVert from '@iconify/icons-ic/twotone-more-vert';
import icClose from '@iconify/icons-ic/twotone-close';
import icPrint from '@iconify/icons-ic/twotone-print';
import icDownload from '@iconify/icons-ic/twotone-cloud-download';
import icDelete from '@iconify/icons-ic/twotone-delete';
import icPhone from '@iconify/icons-ic/twotone-phone';
import icPerson from '@iconify/icons-ic/twotone-person';
import icMyLocation from '@iconify/icons-ic/twotone-my-location';
import icLocationCity from '@iconify/icons-ic/twotone-location-city';
import icEditLocation from '@iconify/icons-ic/twotone-edit-location';
import { Cliente } from 'src/app/_models/Cliente';
import icAssigment from '@iconify/icons-ic/twotone-assignment';
import { CommomService } from 'src/app/services/commom.service';
import { environment } from "src/environments/environment";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MessagesSnackBar } from 'src/app/_constants/messagesSnackBar';
import icVisibility from '@iconify/icons-ic/twotone-visibility';
import icVisibilityOff from '@iconify/icons-ic/twotone-visibility-off';
import icMail from '@iconify/icons-ic/twotone-mail';
import { ErrorStateMatcher } from '@angular/material/core';
import { takeUntil } from 'rxjs/operators';
import { EventEmitterService } from 'src/app/services/event.service';
import icContactSupport from '@iconify/icons-ic/twotone-contact-support';
import { fadeInUp400ms } from '../../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../../@vex/animations/stagger.animation';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

@Component({
  selector: 'vex-cliente-create-update',
  templateUrl: './cliente-create-update.component.html',
  styleUrls: ['./cliente-create-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class ClienteCreateUpdateComponent implements OnInit {

  static id = 100;

  form: FormGroup;
  matcher = new MyErrorStateMatcher();

  mode: 'create' | 'update' = 'create';

  icContactSupport = icContactSupport;
  icMoreVert = icMoreVert;
  icClose = icClose;
  icAssigment = icAssigment
  icPrint = icPrint;
  icDownload = icDownload;
  icDelete = icDelete;
  icMail = icMail;
  icPerson = icPerson;
  icMyLocation = icMyLocation;
  icLocationCity = icLocationCity;
  icEditLocation = icEditLocation;
  icPhone = icPhone;
  inputType = 'password';
  visible = false;

  icVisibility = icVisibility;
  icVisibilityOff = icVisibilityOff;
  selectCtrl: FormControl = new FormControl();
  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
              private dialogRef: MatDialogRef<ClienteCreateUpdateComponent>,
              private fb: FormBuilder,
              private snackBar: MatSnackBar,
              private commomService: CommomService,
              private cd: ChangeDetectorRef) {
  }

  ngOnInit() {
    
    if (this.defaults) {
      this.mode = 'update';

      this.form = this.fb.group({
        partyKey: [ClienteCreateUpdateComponent.id++],
        name: [this.defaults.name || '', [Validators.required]],
        companyTaxID: [this.defaults.companyTaxID || '', [Validators.required]],
        country: [this.defaults.country || '', [Validators.required]],
        currency: [this.defaults.currency || '', [Validators.required]],
        searchTerm: [this.defaults.currency || ''],
        isPerson: [this.defaults.isPerson || ''],
        streetName: [this.defaults.streetName || '', [Validators.required]],
        buildingNumber:[this.defaults.buildingNumber || '', [Validators.required]],
        telephone:[this.defaults.telephone || '', [Validators.required]],
        electronicMail:[this.defaults.electronicMail || '', [Validators.required]],
        culture:[this.defaults.culture || '', [Validators.required]],
        mobile:[this.defaults.mobile || '', [Validators.required]],
        websiteUrl:[this.defaults.websiteUrl || '', [Validators.required]]
      });
    } else {
      this.defaults = {} as Cliente;
      
      this.form = this.fb.group({
        partyKey: [ClienteCreateUpdateComponent.id++],
        name: [this.defaults.name || '', [Validators.required]],
        companyTaxID: [this.defaults.companyTaxID || '', [Validators.required]],
        country: [this.defaults.country || '', [Validators.required]],
        currency: [this.defaults.currency || '', [Validators.required]],
        searchTerm: [this.defaults.searchTerm || ''],
        isPerson: [this.defaults.isPerson || ''],
        streetName: [this.defaults.streetName || '', [Validators.required]],
        buildingNumber:[this.defaults.buildingNumber || '', [Validators.required]],
        telephone:[this.defaults.telephone || '', [Validators.required]],
        electronicMail:[this.defaults.electronicMail || '', [Validators.required]],
        culture:[this.defaults.culture || '', [Validators.required]],
        mobile:[this.defaults.mobile || '', [Validators.required]],
        websiteUrl:[this.defaults.websiteUrl || '', [Validators.required]]
      });
 
    }

  }


  save() {
    if (this.mode === 'create') {
      this.createCliente();
    } else if (this.mode === 'update') {
      this.updateCliente();
    }
  }

  toggleVisibility() {
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

  createCliente() {
    const cliente = this.form.value;
   
    this.commomService.post(environment.clientes, cliente)
    .subscribe(response => {
      this.dialogRef.close(cliente);
      this.snackBar.open(MessagesSnackBar.CRIAR_CLIENTE_SUCESSO, 'Close', { duration: 6000 })
      EventEmitterService.get('buscarClientes').emit();
    },
    (error) => {
      this.snackBar.open(MessagesSnackBar.CRIAR_CLIENTE_ERRO, 'Close', { duration: 4000 });
      this.dialogRef.close(cliente);
    });
    
    
  }

  updateCliente() {
    const cliente = this.form.value;
    cliente.id = this.defaults.id;

    this.commomService.put(environment.clientes, cliente)
    .subscribe(response => {
      console.log(response);
      this.dialogRef.close(cliente);
      this.snackBar.open(MessagesSnackBar.EDITAR_CLIENTE_SUCESSO, 'Close', { duration: 6000 })
      EventEmitterService.get('buscarClientes').emit();
    },
    (error) => {
      console.log(error);
      this.snackBar.open(MessagesSnackBar.EDITAR_CLIENTE_ERRO, 'Close', { duration: 4000 });
      this.dialogRef.close(cliente);
    });
    
  }

  isCreateMode() {
    return this.mode === 'create';
  }

  isUpdateMode() {
    return this.mode === 'update';
  }
}
