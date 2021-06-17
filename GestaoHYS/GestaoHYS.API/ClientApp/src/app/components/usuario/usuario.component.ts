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

@Component({
  selector: 'vex-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {

  labelBotao:string='Criar Usuario';

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
    this.labelBotao = this.labelBotao=='Criar Usuario'?'Voltar Lista':'Criar Usuario';
   
  }

  toggleStar(id: Contact['id']) {
    // const contact = this.tableData.find(c => c.id === id);

    // if (contact) {
    //   contact.starred = !contact.starred;
    // }
  }

}
