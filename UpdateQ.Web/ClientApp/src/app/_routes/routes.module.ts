import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PanelModule, ChartModule } from 'primeng/primeng';

import { RouteGuardService } from './route-guard.service';
import { ROUTES } from './routes';
import { InfoNodeModule } from '../infonodes/info-nodes.module';
import { HomePageComponent } from '../home/home-page/home-page.component';
import { ChartComponent } from '../dashboard/chart/chart.component';
import { ChartContainer } from '../dashboard/chart/chart.container';
import { SigninOidcComponent } from '../shared/signin-oidc.component';
import { OpenIdConnectService } from '../_core/open-id-connect.service';
import { BlaComponent } from '../dashboard/bla/bla.component';
import { SignalRService } from '../_core/signalr.service';

@NgModule({
  declarations: [
    HomePageComponent,
    ChartComponent,
    ChartContainer,
    SigninOidcComponent,
    BlaComponent
  ],
  imports: [
    RouterModule.forRoot(ROUTES),
    InfoNodeModule,
      // PrimeNg modules
      PanelModule, ChartModule,
  ],
  providers: [
    OpenIdConnectService,
    RouteGuardService,
    SignalRService
  ],
  exports: [ RouterModule ]
})
export class RoutesModule { }
