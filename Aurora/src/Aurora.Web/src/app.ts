import {Router, RouterConfiguration} from 'aurelia-router'
import {inject} from 'aurelia-framework';
import auth = require("auth-service");
import userAuth = require('areas/user/static-view-models/logout');

@inject(auth.AuthService, userAuth.LogoutStaticViewModel)
export class App {

  router: Router;
  authService: auth.IAuthService;
  
  constructor(authService: auth.AuthService, private logoutStaticViewModel : userAuth.LogoutStaticViewModel)
  {
      this.authService = authService;
  }

  logout()
  {
      this.logoutStaticViewModel.logout();
  }

  configureRouter(config: RouterConfiguration, router: Router) {
    config.title = 'Aurelia';
    config.map([
        { route: ['', 'welcome'], name: 'welcome', moduleId: 'welcome', nav: true, title: 'Welcome' },
        { route: 'user', name: 'user', moduleId: 'areas/user/config/user-router', nav: true, title: 'User' }
    ]);

    this.router = router;
  }
}
