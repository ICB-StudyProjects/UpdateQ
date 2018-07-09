import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { PanelModule, ChartModule } from 'primeng/primeng';

import { AppComponent } from './app.component';
import { Configuration } from './app.constants';
import { FooterComponent } from './template/footer/footer.component';
import { HeaderComponent } from './template/header/header.component';
import { InfoNodeModule } from './infonodes/info-nodes.module';
import { RoutesModule } from './_routes/routes.module';
import { OpenIdConnectService } from './_core/open-id-connect.service';
// import { OpenIdConnectService } from './_core/open-id-connect.service';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    // Ng modules
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    // App Modules
    InfoNodeModule,
    RoutesModule
  ],
  providers: [
    Configuration,
    OpenIdConnectService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
