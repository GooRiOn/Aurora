import {Router, RouterConfiguration} from 'aurelia-router'

export class UserRouter {
    router: Router;
    heading = 'User';

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: ['', 'register'], name: 'register', moduleId: '../view-models/register', nav: true, title: 'Register' },
            { route: 'login', name: 'login', moduleId: '../view-models/login', nav: true, title: 'Login' },
        ]);

        this.router = router;
    }
}
