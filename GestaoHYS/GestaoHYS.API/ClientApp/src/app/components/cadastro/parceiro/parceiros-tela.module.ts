import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParceirosTelaComponent } from './parceiros-tela.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { IconModule } from '@visurel/iconify-angular';
import { ScrollbarModule } from 'src/@vex/components/scrollbar/scrollbar.module';
import { ContainerModule } from 'src/@vex/directives/container/container.module';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTabsModule } from '@angular/material/tabs';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { BreadcrumbsModule } from 'src/@vex/components/breadcrumbs/breadcrumbs.module';
import { SecondaryToolbarModule } from 'src/@vex/components/secondary-toolbar/secondary-toolbar.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatStepperModule } from '@angular/material/stepper';
import { MatExpansionModule } from '@angular/material/expansion';
import { HighlightModule } from 'src/@vex/components/highlight/highlight.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ParceirosTelaEditComponent } from './parceiros-tela-edit/parceiros-tela-edit.component';
import { DialogDeleteComponent, DialogWithTableComponent, ParceirosTelaDataTableComponent } from './parceiros-tela-data-table/parceiros-tela-data-table.component';
import { MatSelectCountryModule } from '@angular-material-extensions/select-country';
import {HttpClientModule} from '@angular/common/http';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@NgModule({
  declarations: [ParceirosTelaComponent, ParceirosTelaDataTableComponent, ParceirosTelaEditComponent, DialogWithTableComponent, DialogDeleteComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    HttpClientModule,
    MatSelectCountryModule,
    IconModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCheckboxModule,
    MatIconModule,
    MatFormFieldModule,
    MatProgressBarModule,
    MatMenuModule,
    MatRippleModule,
    MatDialogModule,
    ScrollbarModule,
    ReactiveFormsModule,
    ContainerModule,
    MatSidenavModule,
    MatTabsModule,
    MatTooltipModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatAutocompleteModule,
    MatSliderModule,
    MatRadioModule,
    MatSlideToggleModule,
    SecondaryToolbarModule,
    BreadcrumbsModule,
    MatSnackBarModule,
    MatStepperModule,
    MatExpansionModule,
    HighlightModule
  ]
})
export class ParceirosTelaModule { }
