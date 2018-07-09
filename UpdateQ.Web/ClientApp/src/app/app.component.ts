import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

import { OpenIdConnectService } from './_core/open-id-connect.service';
import { SignalRService } from './_core/signalr.service';

import { SensorDto } from './infonodes/models/sensor-dto.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  private _hubConnection: HubConnection

  constructor(private openIdConnectService: OpenIdConnectService,
    private signalRService: SignalRService) {
  }

  ngOnInit() {
    this.signalRService.registerHub();

    // OpenId Connect
    const path = window.location.pathname;

    if (path !== '/signin-oidc') {
     if (!this.openIdConnectService.userAvailable) {
       this.openIdConnectService.triggerSignIn();
     }
    }
  }
}
