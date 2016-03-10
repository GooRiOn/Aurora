import {Router, RouterConfiguration} from 'aurelia-router'

export class UserRouter {
    router: Router;
    heading = 'User';

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: ['','register'], name: 'register', moduleId: '../view-models/register', nav: true, title: 'Register' },
        ]);

        this.router = router;
    }
}
