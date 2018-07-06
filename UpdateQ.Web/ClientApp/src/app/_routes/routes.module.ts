import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RouteGuardService } from './route-guard.service';
import { ROUTES } from './routes';
import { InfoNodeModule } from '../infonodes/info-nodes.module';
import { HomePageComponent } from '../home/home-page/home-page.component';
import { ChartComponent } from '../dashboard/chart/chart.component';
import { PanelModule, ChartModule } from 'primeng/primeng';
import { ChartContainer } from '../dashboard/chart/chart.container';

@NgModule({
  declarations: [
    HomePageComponent,
    ChartComponent,
    ChartContainer
  ],
  imports: [
    RouterModule.forRoot(ROUTES),
    InfoNodeModule,
      // PrimeNg modules
      PanelModule, ChartModule,
  ],
  providers: [
    RouteGuardService
  ],
  exports: [ RouterModule ]
}) 
export class RoutesModule { }
