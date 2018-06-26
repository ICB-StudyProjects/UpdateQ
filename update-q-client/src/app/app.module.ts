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

@NgModule({
  declarations: [
    AppComponent,
    InfoNodeListComponent
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
