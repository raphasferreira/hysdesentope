import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomLayoutComponent } from './custom-layout/custom-layout.component';
import { VexRoutes } from 'src/@vex/interfaces/vex-route.interface';

import { LoginFinalComponent } from './pages/login-final/login-final.component';
import { InsercaoVendasComponent } from './components/insercao-vendas/insercao-vendas.component';

import { ParceirosTelaComponent } from './components/cadastro/parceiro/parceiros-tela.component';
import { EmpresaTelaComponent } from './components/cadastro/empresa/empresa-tela.component';
import { ClienteTelaComponent } from './components/cadastro/cliente/cliente-tela.component';
// import { ParceiroComponent } from './components/cadastro/parceiro/parceiro.component';


const routes: VexRoutes = [
  {
    path: '',
    component: CustomLayoutComponent,
    children: [
      { path: 'gestaohis/insercao-vendas', component: InsercaoVendasComponent },
      // { path: 'gestaohis/cadastro/parceiro', component: ParceiroComponent },
      // { path: 'gestaohis/cadastro/empresa', component: EmpresasComponent },
      { path: 'gestaohis/cadastro/parceiro', component: ParceirosTelaComponent },
      { path: 'gestaohis/cadastro/cliente/all', component: ClienteTelaComponent },
      { path: 'gestaohis/cadastro/empresa', component: EmpresaTelaComponent },
     
    ],
  },
  { path: 'login', component: LoginFinalComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {

    // preloadingStrategy: PreloadAllModules,
    scrollPositionRestoration: 'enabled',
    relativeLinkResolution: 'corrected',
    anchorScrolling: 'enabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
