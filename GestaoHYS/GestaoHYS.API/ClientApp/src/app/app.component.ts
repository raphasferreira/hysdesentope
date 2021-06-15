import { Component, Inject, LOCALE_ID, Renderer2, OnInit } from '@angular/core';
import { ConfigService } from '../@vex/services/config.service';
import { Settings } from 'luxon';
import { DOCUMENT } from '@angular/common';
import { Platform } from '@angular/cdk/platform';
import { NavigationService } from '../@vex/services/navigation.service';
import icLayers from '@iconify/icons-ic/twotone-layers';
import icAssigment from '@iconify/icons-ic/twotone-assignment';
import icContactSupport from '@iconify/icons-ic/twotone-contact-support';
import icDateRange from '@iconify/icons-ic/twotone-date-range';
import icContacts from '@iconify/icons-ic/twotone-contacts';

import { LayoutService } from '../@vex/services/layout.service';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { SplashScreenService } from '../@vex/services/splash-screen.service';
import { Style, StyleService } from '../@vex/services/style.service';
import { ConfigName } from '../@vex/interfaces/config-name.model';
import { CommomService } from 'src/app/services/commom.service';


@Component({
  selector: 'vex-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'vex';

  constructor(private configService: ConfigService,
    private styleService: StyleService,
    private renderer: Renderer2,
    private platform: Platform,
    @Inject(DOCUMENT) private document: Document,
    @Inject(LOCALE_ID) private localeId: string,
    private layoutService: LayoutService,
    private route: ActivatedRoute,
    private navigationService: NavigationService,
    private splashScreenService: SplashScreenService,
    private commomService: CommomService,
    private router: Router) {
      Settings.defaultLocale = this.localeId;
      
      if (this.platform.BLINK) {
        this.renderer.addClass(this.document.body, 'is-blink');
      }
      
    /**
     * Customize the template to your needs with the ConfigService
     * Example:
     *  this.configService.updateConfig({
     *    sidenav: {
     *      title: 'Custom App',
     *      imageUrl: '//placehold.it/100x100',
     *      showCollapsePin: false
     *    },
     *    showConfigButton: false,
     *    footer: {
     *      visible: false
     *    }
     *  });
     */

    /**
     * Config Related Subscriptions
     * You can remove this if you don't need the functionality of being able to enable specific configs with queryParams
     * Example: example.com/?layout=apollo&style=default
     */
    this.route.queryParamMap.pipe(
      map(queryParamMap => queryParamMap.has('rtl') && coerceBooleanProperty(queryParamMap.get('rtl'))),
    ).subscribe(isRtl => {
      this.document.body.dir = isRtl ? 'rtl' : 'ltr';
      this.configService.updateConfig({
        rtl: isRtl
      });
    });

    this.route.queryParamMap.pipe(
      filter(queryParamMap => queryParamMap.has('layout'))
    ).subscribe(queryParamMap => this.configService.setConfig(queryParamMap.get('layout') as ConfigName));

    this.route.queryParamMap.pipe(
      filter(queryParamMap => queryParamMap.has('style'))
    ).subscribe(queryParamMap => this.styleService.setStyle(queryParamMap.get('style') as Style));
    this.navigationService.items = [
      {
        label: 'Dashboard',
        type: 'link',
        route: '/dashboard',
        icon: icLayers
      },
      {
        type: 'dropdown',
        label: 'Controle de usuários',
        gruop:'GestaoHis',
        children: [
          {
            type: 'link',
            label: 'All-In-One Table',
            route: '/gestaohis/apps/aio-table',
            icon: icAssigment,
            gruop:'GestaoHis'
          },
        ]
      },
      {
        type: 'link',
        label: 'Inserção de Vendas',
        route: '/gestaohis/insercao-vendas',
        icon: icLayers,
        gruop:'GestaoHis',
      },
       {
        type: 'dropdown',
        label: 'Gestão de Financeiro',
        gruop:'GestaoHis',
        children: [
          {
            type: 'link',
            label: 'Notas de crédito',
            route: '/gestaohis/gestao-financeira/notas-credito',
            icon: icAssigment,
            gruop:'GestaoHis',
          },
        ]
      },
      {
        type: 'dropdown',
        label: 'Cadastros',
        gruop:'GestaoHis',
        children: [
          {
            type: 'link',
            label: 'Artigos de Vendas',
            route: '/gestaohis/cadastro/tipo-servico',
            icon: icAssigment,
            gruop:'GestaoHis',
          },
          {
            type: 'link',
            label: 'Empresas',
            route: '/gestaohis/cadastro/empresa',
            icon: icAssigment,
            gruop:'GestaoHis',
          },
          {
            type: 'link',
            label: 'Clientes',
            route: '/gestaohis/cadastro/cliente/all',
            icon: icContacts,
            gruop:'GestaoHis',
          },
          {
            type: 'link',
            label: 'Parceiros',
            route: '/gestaohis/cadastro/parceiro',
            icon: icAssigment,
            gruop:'GestaoHis',
          }
        ]
      },
      {
        type: 'dropdown',
        label: 'Relatórios',
        gruop:'GestaoHis',
        children: [
          {
            type: 'link',
            label: 'Vendas',
            route: '/gestaohis/relatorio/vendas',
            icon: icAssigment,
            gruop:'GestaoHis',
          },
          {
            type: 'link',
            label: 'Comissões',
            route: '/gestaohis/relatorio/comissoes',
            icon: icAssigment,
            gruop:'GestaoHis',
          }
        ]
      },
    ];
  }
  ngOnInit(): void {
    let token = window.localStorage.getItem('token');
    if(!token){
      this.router.navigate(['/login']);
    }
  }
}
