import { BrowserModule } from '@angular/platform-browser';
import { Injector, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VexModule } from '../@vex/vex.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CustomLayoutModule } from './custom-layout/custom-layout.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatProgressBarModule } from '@angular/material/progress-bar';

import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatTableModule } from '@angular/material/table';

import { IconModule } from '@visurel/iconify-angular';

import { NgxMaskModule } from 'ngx-mask';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { GaugeModule, NgxChartsModule } from '@swimlane/ngx-charts';
import { NgxGaugeModule } from 'ngx-gauge';
import { LoginFinalComponent } from './pages/login-final/login-final.component';
import { MatSelectCountryModule } from '@angular-material-extensions/select-country';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { Router } from '@angular/router';
import { CommomService } from './services/commom.service';

export let InjectorInstance: Injector;

@NgModule({
  declarations: [
    AppComponent,
    LoginFinalComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    MatSelectCountryModule.forRoot('de'),
    GaugeModule,
    NgxGaugeModule,
    ReactiveFormsModule,
    MatProgressBarModule,
    MatCardModule,
    NgxChartsModule,
    MatSnackBarModule,
    ScrollingModule,
    MatDatepickerModule,
    MatNativeDateModule,
    IconModule,
    FlexLayoutModule,
    MatButtonModule,
    MatRadioModule,
    MatAutocompleteModule,
    MatTableModule,
    NgxMaskModule.forRoot(),
    MatCheckboxModule,
    MatInputModule,
    MatTabsModule,
    MatPaginatorModule,
    FormsModule,
    
    // Vex
    VexModule,
    CustomLayoutModule,
    MatSelectCountryModule
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule,
    {provide: HTTP_INTERCEPTORS,
      useFactory: function(router: Router) {
        return new AuthInterceptor(router);
      },
      multi: true,
      deps: [Router]}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {  constructor(private injector: Injector) 
  {
    InjectorInstance = this.injector;
  }}
