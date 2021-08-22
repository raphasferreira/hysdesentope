import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VexRoutes } from 'src/@vex/interfaces/vex-route.interface';
import { NotasCreditoComponent } from './notas-credito/notas-credito.component';
import { TitulosComponent } from './titulos/titulos.component';

const routes: VexRoutes = [
  {
    path: '',
    children: [
      {
        path: 'notas-credito',
        component: NotasCreditoComponent,
      },
      {
        path: 'titulos',
        component: TitulosComponent,
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GestaoFinanceiraRoutingModule { }
