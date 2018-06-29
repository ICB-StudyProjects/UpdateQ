import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { SlideMenuModule,
   PanelMenuModule } from 'primeng/primeng';


import { InfoNodeCreateComponent } from './create/info-node-create.component';
import { InfoNodeDeleteComponent } from './delete/info-node-delete.component';
import { InfoNodeEditComponent } from './edit/info-node-edit.component';
import { InfoNodeListComponent } from './list/info-node-list.component';
import { infoNodesService } from './info-nodes.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    // PrimeNg Modules
    SlideMenuModule, PanelMenuModule, 
  ],
  declarations: [
    InfoNodeListComponent,
    InfoNodeCreateComponent,
    InfoNodeEditComponent,
    InfoNodeDeleteComponent
  ],
  providers: [
    infoNodesService
  ],
  exports: [
    InfoNodeListComponent,
    InfoNodeCreateComponent,
    InfoNodeEditComponent,
    InfoNodeDeleteComponent
  ]
})
export class InfoNodeModule { }
