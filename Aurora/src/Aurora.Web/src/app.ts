import auth = require("auth-service");
import userAuth = require('areas/user/static-view-models/logout');
import {Router, RouterConfiguration} from 'aurelia-router'
import {inject} from 'aurelia-framework';

@inject(auth.AuthService, userAuth.LogoutStaticViewModel)
export class App {

  router: Router;
  authService: auth.IAuthService;
  host = 'http://localhost:49849/api';
  
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
        { route: 'user', name: 'user', moduleId: 'areas/user/config/user-router', nav: true, title: 'User' },
        { route: 'admin', name: 'admin', moduleId: 'areas/admin/config/admin-router', nav: true, title: 'Admin' },
        { route: 'project', name: 'project', moduleId: 'areas/project/config/project-router', nav: true, title: 'Project' }
    ]);

    this.router = router;
  }
}
