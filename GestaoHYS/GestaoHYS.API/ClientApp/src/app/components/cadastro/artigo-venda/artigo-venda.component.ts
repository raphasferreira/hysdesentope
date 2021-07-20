import { Component, OnInit } from '@angular/core';
import icPersonAdd from '@iconify/icons-ic/twotone-person-add';
import icCloudDownload from '@iconify/icons-ic/twotone-cloud-download';
import icFilterList from '@iconify/icons-ic/twotone-filter-list';
import icContacts from '@iconify/icons-ic/twotone-contacts';
import icSearch from '@iconify/icons-ic/twotone-search';
import icStar from '@iconify/icons-ic/twotone-star';
import icMenu from '@iconify/icons-ic/twotone-menu';
import { trackById } from 'src/@vex/utils/track-by';
import { Contact } from 'src/static-data/contact';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { scaleIn400ms } from 'src/@vex/animations/scale-in.animation';
import { fadeInRight400ms } from 'src/@vex/animations/fade-in-right.animation';
import { stagger40ms } from 'src/@vex/animations/stagger.animation';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { scaleFadeIn400ms } from 'src/@vex/animations/scale-fade-in.animation';
import { MatDialog } from '@angular/material/dialog';
import { ArtigoVenda } from 'src/app/_models/ArtigoVenda';
import { Observable, of, ReplaySubject } from 'rxjs';
import icAdd from '@iconify/icons-ic/twotone-add';
import { ArtigoVendaCreateUpdateComponent } from './artigo-venda-create-update/artigo-venda-create-update.component';

@Component({
  selector: 'vex-artigo-venda',
  templateUrl: './artigo-venda.component.html',
  styleUrls: ['./artigo-venda.component.scss'],
  animations: [
    stagger40ms,
    scaleIn400ms,
    fadeInRight400ms,
    fadeInUp400ms,
    scaleFadeIn400ms,
  ]
})
export class ArtigoVendaComponent implements OnInit {

  subject$: ReplaySubject<ArtigoVenda[]> = new ReplaySubject<ArtigoVenda[]>(1);

  labelBotao:string='Criar Artigo Venda';

  icAdd = icAdd;
  icSearch = icSearch;
  icPersonAdd = icPersonAdd;
  icCloudDownload = icCloudDownload;
  icFilterList = icFilterList;
  icContacts = icContacts;
  icStar = icStar;
  icMenu = icMenu;
  trackById = trackById;
  searchCtrl = new FormControl();
  artigoVendas: ArtigoVenda[];
  
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  
  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openContact(id?: Contact['id']) {
  

    this.trocarTela();
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Criar Artigo Venda'?'Voltar Lista':'Criar Artigo Venda';
   
  }

  toggleStar(id: Contact['id']) {
    // const contact = this.tableData.find(c => c.id === id);

    // if (contact) {
    //   contact.starred = !contact.starred;
    // }
  }

  createArtigoVenda() {
    this.dialog.open(ArtigoVendaCreateUpdateComponent).afterClosed().subscribe((artigoVenda: ArtigoVenda) => {
      /**
       * ArtigoVenda is the updated customer (if the user pressed Save - otherwise it's null)
       */
      if (artigoVenda) {
        /**
         * Here we are updating our local array.
         * You would probably make an HTTP request here.
         */
        this.artigoVendas.unshift(artigoVenda);
        this.subject$.next(this.artigoVendas);
      }
    });
  }

 

}
