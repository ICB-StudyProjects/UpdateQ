import { Routes } from '@angular/router';

import { HomePageComponent } from '../home/home-page/home-page.component';
import { InfoNodeCreateComponent } from '../infonodes/create/info-node-create.component';
import { InfoNodeEditComponent } from '../infonodes/edit/info-node-edit.component';
import { InfoNodeDeleteComponent } from '../infonodes/delete/info-node-delete.component';
import { ChartContainer } from '../dashboard/chart/chart.container';
import { SigninOidcComponent } from '../shared/signin-oidc.component';
import { BlaComponent } from '../dashboard/bla/bla.component';

export const ROUTES: Routes = [
  { path: 'dashboard/:id', component: ChartContainer },
  { path: 'bla', component: BlaComponent },
  { path: 'node/create', component: InfoNodeCreateComponent },
  { path: 'node/edit/:id', component: InfoNodeEditComponent },
  { path: 'node/delete/:id', component: InfoNodeDeleteComponent },
  { path: 'signin-oidc', component: SigninOidcComponent },
  { path: '', component: HomePageComponent, pathMatch: 'full' }
];
