import { Routes } from '@angular/router';

import { HomePageComponent } from '../home/home-page/home-page.component';
import { InfoNodeCreateComponent } from '../infonodes/create/info-node-create.component';
import { InfoNodeEditComponent } from '../infonodes/edit/info-node-edit.component';
import { InfoNodeDeleteComponent } from '../infonodes/delete/info-node-delete.component';
import { ChartContainer } from '../dashboard/chart/chart.container';

export const ROUTES: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'dashboard/:id', component: ChartContainer },
  { path: 'node/create', component: InfoNodeCreateComponent },
  { path: 'node/edit/:id', component: InfoNodeEditComponent },
  { path: 'node/delete/:id', component: InfoNodeDeleteComponent }
];
