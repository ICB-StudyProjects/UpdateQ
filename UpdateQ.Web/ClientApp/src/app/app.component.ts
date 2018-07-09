import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService } from './_core/open-id-connect.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor (private openIdConnectService: OpenIdConnectService) {
  }

  ngOnInit() {
    const path = window.location.pathname;

    if (path !== '/signin-oidc') {
      if (!this.openIdConnectService.userAvailable) {
        this.openIdConnectService.triggerSignIn();
      }
    }
  }
}
