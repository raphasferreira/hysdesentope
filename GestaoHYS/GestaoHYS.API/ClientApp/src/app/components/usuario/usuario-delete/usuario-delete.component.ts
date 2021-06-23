import { Component, Inject, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import icClose from '@iconify/icons-ic/twotone-close';
import { debounceTime } from "rxjs/operators";
import { CommomService } from "src/app/services/commom.service";
import { Usuario } from "src/app/_models/Usuario";
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { environment } from "src/environments/environment";
import { MessagesSnackBar } from "src/app/_constants/messagesSnackBar";
import { EventEmitterService } from "src/app/services/event.service";
import { Contact } from "src/static-data/contact";

@Component({
  selector: 'vex-usuario-delete',
  templateUrl: './usuario-delete.component.html',
  styleUrls: ['./usuario-delete.component.scss']
})
export class UsuarioDeleteComponent implements OnInit {

 
  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  usuarioSelecionado : any;
  requisicao: Boolean = false;

  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
  private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<UsuarioDeleteComponent>) {
  }
  
  ngOnInit(): void {
    this.usuarioSelecionado = this.defaults as Usuario;
    
  }

  deletarUsuario(){
    this.requisicao = true
    this.commomService.delete(`${environment.usuarios}/${this.usuarioSelecionado.id}`)
    .subscribe(response => {
      this.snackBar.open(MessagesSnackBar.DELETAR_USUARIO_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarUsuarios').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.DELETAR_USUARIO_ERRO, 'Close', { duration: 4000 });
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
  }
}
