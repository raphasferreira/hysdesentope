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
import { contactsData } from 'src/static-data/contacts';
import { Contact } from 'src/static-data/contact';

@Component({
  selector: 'vex-cliente-tela',
  templateUrl: './cliente-tela.component.html',
  //styleUrls: ['./cliente-tela.component.scss']
  animations: [
    stagger40ms,
    scaleIn400ms,
    fadeInRight400ms,
    fadeInUp400ms,
    scaleFadeIn400ms,
  ]
})
export class ClienteTelaComponent implements OnInit {

  labelBotao:string='Criar Cliente';

  searchCtrl = new FormControl();

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

  links: Link[] = [
    {
      label: 'Todos',
      route: '../insercao-vendas/all'
    }
  ];

  activeCategory: 'frequently' | 'starred' | 'all' | 'family' | 'friends' | 'colleagues' | 'business' = 'all';
  tableData = clienteAPIData;
  tableColumns: TableColumn<any>[] = [
    {
      label: 'Nome',
      property: 'nome',
      type: 'text',
      cssClasses: ['font-medium']
    },
    {
      label: 'NIF',
      property: 'companyTaxID',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Termo de Pesquisa',
      property: 'termoPesquisa',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'País',
      property: 'dsPais',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Celular',
      property: 'celular',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'EMAIL',
      property: 'email',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: 'Grupo',
      property: 'grupo',
      type: 'text',
      cssClasses: ['text-secondary']
    },
    {
      label: '',
      property: 'menu',
      type: 'button',
      cssClasses: ['text-secondary', 'w-10']
    },
  ];

  constructor(private dialog: MatDialog,private route: ActivatedRoute) { }

  ngOnInit() {

  }

  openContact(id?: Contact['id']) {
    // this.dialog.open(ContactsEditComponent, {
    //   data: id || null,
    //   width: '600px'
    // });

    this.trocarTela();
  }

  toggleStar(id: Contact['id']) {
    const contact = this.tableData.find(c => c.id === id);

    if (contact) {
      contact.starred = !contact.starred;
    }
  }

  setData(data: Contact[]) {
    this.tableData = data;
    this.menuOpen = false;
  }

  openMenu() {
    this.menuOpen = true;
  }

  contacts = contactsData;
  filteredContacts$ = this.route.paramMap.pipe(
    map(paramMap => paramMap.get('activeCategory')),
    map(activeCategory => {
      console.log('teste');   
      switch (activeCategory) {
        case 'all': {
          return contactsData;
        }

        case 'starred': {
          return contactsData.filter(c => c.starred);
        }

        default: {
          return [];
        }
      }
    })
  );

  trocarTela(){
    localStorage.removeItem('clienteSelecionado');
    this.labelBotao = this.labelBotao=='Criar Cliente'?'Voltar Lista':'Criar Cliente';
   
  }
  boolGeralCliente = true;
  tocarEditeCliente(e){
    console.log(e);
    console.log(this.boolGeralCliente);
    this.boolGeralCliente = this.boolGeralCliente?false:true;
  }

}
