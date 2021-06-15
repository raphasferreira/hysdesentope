import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VexRoutes } from 'src/@vex/interfaces/vex-route.interface';

const routes: VexRoutes = [
  {
    path: '',
    children: [
      // {
      //   path: 'cliente',
      //   component: ClienteComponent,
      //   data: {
      //     scrollDisabled: true,
      //     toolbarShadowEnabled: false,
          
      //   },
      //   children:[
      //     {
      //       path: ':activeCategory',
      //       component: ClienteComponent,
      //       data: {
      //         scrollDisabled: true,
      //         toolbarShadowEnabled: false
      //       }
      //     }
      //   ]
      // },
      // {
      //   path: 'empresa',
      //   component: EmpresaComponent,
      //   data: {
      //     scrollDisabled: true,
      //     toolbarShadowEnabled: false,
          
      //   },
      //   children:[
      //     {
      //       path: ':activeCategory',
      //       component: EmpresaComponent,
      //       data: {
      //         scrollDisabled: true,
      //         toolbarShadowEnabled: false
      //       }
      //     }
      //   ]
      // },
      // {
      //   path: 'parceiro',
      //   component: ParceiroComponent,
      //   data: {
      //     scrollDisabled: true,
      //     toolbarShadowEnabled: false,
          
      //   },
      //   children:[
      //     {
      //       path: ':activeCategory',
      //       component: ParceiroComponent,
      //       data: {
      //         scrollDisabled: true,
      //         toolbarShadowEnabled: false
      //       }
      //     }
      //   ]
      // },
      // {
      //   path: 'tipo-servico',
      //   component: TipoServicoComponent,
      //   data: {
      //     scrollDisabled: true,
      //     toolbarShadowEnabled: false,
          
      //   },
      //   children:[
      //     {
      //       path: ':activeCategory',
      //       component: TipoServicoComponent,
      //       data: {
      //         scrollDisabled: true,
      //         toolbarShadowEnabled: false
      //       }
      //     }
      //   ]
      // }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadastroRoutingModule { }
