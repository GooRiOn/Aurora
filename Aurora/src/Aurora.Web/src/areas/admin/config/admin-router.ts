import {Router, RouterConfiguration} from 'aurelia-router'

export class AdminRouter {
    router: Router;
    heading = 'Admin';

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: ['', 'users-manage'], name: 'users-manage', moduleId: '../view-models/users-manage', nav: true, title: 'UsersManage' },
        ]);
         
        this.router = router;
    }
}
