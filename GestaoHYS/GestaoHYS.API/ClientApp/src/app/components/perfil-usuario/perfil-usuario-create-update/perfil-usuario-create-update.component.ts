import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
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
import { PerfilUsuario } from 'src/app/_models/PerfilUsuario';
import { EventEmitterService } from 'src/app/services/event.service';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

@Component({
  selector: 'vex-perfil-usuario-create-update',
  templateUrl: './perfil-usuario-create-update.component.html',
  styleUrls: ['./perfil-usuario-create-update.component.scss']
})
export class PerfilUsuarioCreateUpdateComponent implements OnInit {

  static id = 100;

  form: FormGroup;
  matcher = new MyErrorStateMatcher();

  mode: 'create' | 'update' = 'create';

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


  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
              private dialogRef: MatDialogRef<PerfilUsuarioCreateUpdateComponent>,
              private fb: FormBuilder,
              private snackBar: MatSnackBar,
              private commomService: CommomService,
              private cd: ChangeDetectorRef) {
  }

  ngOnInit() {
    
    if (this.defaults) {
      console.log("1");
      this.mode = 'update';
      
      this.form = this.fb.group({
        id: [PerfilUsuarioCreateUpdateComponent.id++],
        descricao: [this.defaults.descricao || '', [Validators.required]],
      });
    } else {
      
      this.defaults = {} as PerfilUsuario;
     
      this.form = this.fb.group({
        id: [PerfilUsuarioCreateUpdateComponent.id++],
        descricao: [this.defaults.descricao || '', [Validators.required]],
      });
    }
  }

  save() {
    if (this.mode === 'create') {
      this.createPerfilUsuario();
    } else if (this.mode === 'update') {
      this.updatePerfilUsuario();
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

  createPerfilUsuario() {
    const perfil = this.form.value;
   
    this.commomService.post(environment.perfilUsuario, perfil)
    .subscribe(response => {
      this.dialogRef.close(perfil);
      this.snackBar.open(MessagesSnackBar.CRIAR_PERFIL_USUARIO_SUCESSO, 'Close', { duration: 6000 })
      EventEmitterService.get('buscarPerfilUsuarios').emit();
    },
    (error) => {
      this.snackBar.open(MessagesSnackBar.CRIAR_PERFIL_USUARIO_ERRO, 'Close', { duration: 4000 });
      this.dialogRef.close(perfil);
    });
    
    
  }

  updatePerfilUsuario() {
    const perfil = this.form.value;
    perfil.id = this.defaults.id;
    
    this.commomService.put(environment.perfilUsuario, perfil)
    .subscribe(response => {
      console.log(response);
      this.dialogRef.close(perfil);
      this.snackBar.open(MessagesSnackBar.EDITAR_PERFIL_USUARIO_SUCESSO, 'Close', { duration: 6000 })
      EventEmitterService.get('buscarPerfilUsuarios').emit();
    },
    (error) => {
      console.log(error);
      this.snackBar.open(MessagesSnackBar.EDITAR_PERFIL_USUARIO_ERRO, 'Close', { duration: 4000 });
      this.dialogRef.close(perfil);
    });
    
  }

  isCreateMode() {
    return this.mode === 'create';
  }

  isUpdateMode() {
    return this.mode === 'update';
  }
}
