import { Component, OnInit } from '@angular/core';
import icContacts from '@iconify/icons-ic/twotone-contacts';
import icSearch from '@iconify/icons-ic/twotone-search';
import icStar from '@iconify/icons-ic/twotone-star';
import { FormControl } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import icMenu from '@iconify/icons-ic/twotone-menu';
import { scaleIn400ms } from 'src/@vex/animations/scale-in.animation';
import { fadeInRight400ms } from 'src/@vex/animations/fade-in-right.animation';
import { stagger40ms } from 'src/@vex/animations/stagger.animation';
import { TableColumn } from 'src/@vex/interfaces/table-column.interface';
import { Link } from 'src/@vex/interfaces/link.interface';
import icPersonAdd from '@iconify/icons-ic/twotone-person-add';
import icCloudDownload from '@iconify/icons-ic/twotone-cloud-download';
import icFilterList from '@iconify/icons-ic/twotone-filter-list';
import { trackById } from 'src/@vex/utils/track-by';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { scaleFadeIn400ms } from 'src/@vex/animations/scale-fade-in.animation';
import { ActivatedRoute } from '@angular/router';
import { clienteAPIData } from 'src/static-data/clientesAPI';
import { Contact } from 'src/static-data/contact';
import { InsercaoVendasCreateUpdateComponent } from './insercao-vendas-create-update/insercao-vendas-create-update.component';
import { Invoice } from 'src/app/_models/Invoice';
import icAdd from '@iconify/icons-ic/twotone-add';

@Component({
  selector: 'vex-insercao-vendas',
  templateUrl: './insercao-vendas.component.html',
  //styleUrls: ['./insercao-vendas.component.scss']
  animations: [
    stagger40ms,
    scaleIn400ms,
    fadeInRight400ms,
    fadeInUp400ms,
    scaleFadeIn400ms,
  ]
})
export class InsercaoVendasComponent implements OnInit {

  labelBotao:string='Criar Fatura';

  searchCtrl = new FormControl();
  icAdd = icAdd;
  icSearch = icSearch;
  icPersonAdd = icPersonAdd;
  icCloudDownload = icCloudDownload;
  icFilterList = icFilterList;
  icContacts = icContacts;
  icStar = icStar;
  icMenu = icMenu;
  trackById = trackById;

  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );

  menuOpen = false;

  constructor(private dialog: MatDialog,private route: ActivatedRoute) { }

  ngOnInit() {
  }

  
  createFatura() {
    this.dialog.open(InsercaoVendasCreateUpdateComponent).afterClosed().subscribe((venda: Invoice) => {
      /**
       * ArtigoVenda is the updated customer (if the user pressed Save - otherwise it's null)
       */
      if (venda) {
        /**
         * Here we are updating our local array.
         * You would probably make an HTTP request here.
         */
        
      }
    });
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
 

  openMenu() {
    this.menuOpen = true;
  }

  



}
