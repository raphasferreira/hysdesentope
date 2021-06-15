import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VexRoutes } from 'src/@vex/interfaces/vex-route.interface';
import { AioTableComponent } from './aio-table/aio-table.component';
import { ComissoesComponent } from './comissoes/comissoes.component';
import { VendasComponent } from './vendas/vendas.component';

const routes: VexRoutes = [
  {
    path: '',
    children: [
      {
        path: 'vendas',
        component: VendasComponent,
        data: {
          toolbarShadowEnabled: true
        }
      },
      {
        path: 'comissoes',
        component: AioTableComponent,
        data: {
          toolbarShadowEnabled: true
        }
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelatorioRoutingModule { }
