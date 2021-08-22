import { Component, Inject, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import icClose from '@iconify/icons-ic/twotone-close';
import { debounceTime } from "rxjs/operators";
import { CommomService } from "src/app/services/commom.service";
import { Invoice } from "src/app/_models/Invoice";
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { environment } from "src/environments/environment";
import { MessagesSnackBar } from "src/app/_constants/messagesSnackBar";
import { EventEmitterService } from "src/app/services/event.service";
import { Contact } from "src/static-data/contact";
import { Titulos } from "src/app/_models/Titulos";

@Component({
  selector: 'vex-titulos-pagamentos',
  templateUrl: './titulos-pagamentos.component.html',
  styleUrls: ['./titulos-pagamentos.component.scss']
})
export class TitulosPagamentosComponent implements OnInit {

 
  icClose = icClose;
  
  searchCtrl = new FormControl();
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  tituloSelecionado : any;
  requisicao: Boolean = false;

  constructor(@Inject(MAT_DIALOG_DATA) public defaults: any,
  private commomService: CommomService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<TitulosPagamentosComponent>) {
  }
  
  ngOnInit(): void {
    this.tituloSelecionado = this.defaults as Titulos;
    
  }

  realizarPagamento(){
    this.requisicao = true
    this.commomService.put(environment.titulos, this.tituloSelecionado)
    .subscribe(response => {
      this.snackBar.open(MessagesSnackBar.BAIXA_TITULO_SUCESSO, 'Close', { duration: 4000 });
      EventEmitterService.get('buscarTitulos').emit();
    },
    (error) => {
      console.log(error.message);
      this.snackBar.open(MessagesSnackBar.BAIXA_TITULO_ERRO, 'Close', { duration: 4000 });
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
