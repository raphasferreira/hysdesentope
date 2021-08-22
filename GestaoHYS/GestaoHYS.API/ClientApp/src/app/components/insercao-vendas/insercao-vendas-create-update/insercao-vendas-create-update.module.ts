import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import { IconModule } from '@visurel/iconify-angular';
import { MatDividerModule } from '@angular/material/divider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InsercaoVendasCreateUpdateComponent } from './insercao-vendas-create-update.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import { MY_DATE_FORMATS } from 'src/app/services/date-format';
import {MatAutocompleteModule} from '@angular/material/autocomplete';

@NgModule({
  imports: [
    CommonModule,
    FlexLayoutModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatRadioModule,
    MatSelectModule,
    MatMenuModule,
    IconModule,
    FormsModule,
    MatDividerModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatProgressBarModule,
    MatTabsModule,
    MatDatepickerModule,
    MatAutocompleteModule
  ],
  declarations: [InsercaoVendasCreateUpdateComponent],
  entryComponents: [InsercaoVendasCreateUpdateComponent],
  exports: [InsercaoVendasCreateUpdateComponent],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }
  ],
})
export class InsercaoVendasCreateUpdateModule {
}
