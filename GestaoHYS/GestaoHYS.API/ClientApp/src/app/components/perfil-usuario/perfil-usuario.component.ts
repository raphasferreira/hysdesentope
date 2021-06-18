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
import { stagger40ms } from 'src/@vex/animations/stagger.animation';
import { scaleIn400ms } from 'src/@vex/animations/scale-in.animation';
import { fadeInRight400ms } from 'src/@vex/animations/fade-in-right.animation';
import { fadeInUp400ms } from 'src/@vex/animations/fade-in-up.animation';
import { scaleFadeIn400ms } from 'src/@vex/animations/scale-fade-in.animation';

@Component({
  selector: 'vex-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.scss'],
  animations: [
    stagger40ms,
    scaleIn400ms,
    fadeInRight400ms,
    fadeInUp400ms,
    scaleFadeIn400ms,
  ]
})
export class PerfilUsuarioComponent implements OnInit {

  labelBotao:string='Criar Perfil de Usuário';

  icSearch = icSearch;
  icPersonAdd = icPersonAdd;
  icCloudDownload = icCloudDownload;
  icFilterList = icFilterList;
  icContacts = icContacts;
  icStar = icStar;
  icMenu = icMenu;
  trackById = trackById;
  searchCtrl = new FormControl();
  
  searchStr$ = this.searchCtrl.valueChanges.pipe(
    debounceTime(10)
  );
  
  constructor() { }

  ngOnInit(): void {
  }

  openContact(id?: Contact['id']) {
  

    this.trocarTela();
  }

  trocarTela(){
    this.labelBotao = this.labelBotao=='Criar Perfil de Usuário'?'Voltar Lista':'Criar Perfil de Usuário';
   
  }

  toggleStar(id: Contact['id']) {
    // const contact = this.tableData.find(c => c.id === id);

    // if (contact) {
    //   contact.starred = !contact.starred;
    // }
  }

}
