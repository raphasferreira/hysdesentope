import { Component, Inject, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import icClose from '@iconify/icons-ic/twotone-close';
import { debounceTime } from "rxjs/operators";
import { CommomService } from "src/app/services/commom.service";
import { ArtigoVenda } from "src/app/_models/ArtigoVenda";
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { environment } from "src/environments/environment";
import { MessagesSnackBar } from "src/app/_constants/messagesSnackBar";
import { EventEmitterService } from "src/app/services/event.service";
import { Contact } from "src/static-data/contact";

@Component({
  selector: 'vex-artigo-venda-delete',
  templateUrl: './artigo-venda-delete.component.html',
  styleUrls: ['./artigo-venda-delete.component.scss']
})
export class ArtigoVendaDeleteComponent implements OnInit {

 
  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  artigoVendaSelecionado : any;
  requisicao: Boolean = false;

  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
  private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<ArtigoVendaDeleteComponent>) {
  }
  
  ngOnInit(): void {
    this.artigoVendaSelecionado = this.defaults as ArtigoVenda;
    
  }

  deletarArtigoVenda(){
    this.requisicao = true
    this.commomService.delete(`${environment.artigoVendas}/${this.artigoVendaSelecionado.idBaseLocal}`)
    .subscribe(response => {
      this.snackBar.open(MessagesSnackBar.DELETAR_ARTIGOVENDA_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarArtigoVendas').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.DELETAR_ARTIGOVENDA_ERRO, 'Close', { duration: 4000 });
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
