import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {

  private userManager: UserManager = new UserManager(environment.openIdConnectSettings);
  private currentUser: User;

  get user(): User {
    return this.currentUser;
  }

  get userAvailable(): boolean {
    return this.currentUser != null;
  }

  constructor() {
    this.userManager.clearStaleState();

    this.userManager.events.addUserLoaded(user => {
      if (!environment.production) {
        console.log('User loaded.', user);
      }
      this.currentUser = user;
    });
   }

  triggerSignIn() {
    this.userManager.signinRedirect().then(() => {
      if (!environment.production) {
        console.log('Redirected to sighin trigger.');
      }
    });
  }

  handleCallBack() {
    this.userManager.signinRedirectCallback().then(user => {
      if (!environment.production) {
        console.log('Callback after signin handled.', user);
      }
    });
  }
}
