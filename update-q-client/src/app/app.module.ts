import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { InfoNodeListComponent } from './infonodes/components/list/infonode-list.component';
import { infoNodesService } from './infonodes/infonodes.service';
import { Configuration } from './app.constants';
import { SlideMenuModule, PanelMenuModule } from 'primeng/primeng';
import { FooterComponent } from './template/footer/footer.component';
import { HeaderComponent } from './template/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    InfoNodeListComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    // PrimeNg modules
    SlideMenuModule, PanelMenuModule
  ],
  providers: [
    Configuration,
    infoNodesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
