import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GestaoFinanceiraRoutingModule } from './gestao-financeira-routing.module';
import { NotasCreditoComponent } from './notas-credito/notas-credito.component';


@NgModule({
  declarations: [NotasCreditoComponent],
  imports: [
    CommonModule,
    GestaoFinanceiraRoutingModule
  ]
})
export class GestaoFinanceiraModule { }
