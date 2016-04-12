import {Router, RouterConfiguration} from 'aurelia-router'

export class ProjectRouter {
    router: Router;
    heading = 'Project';

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: ['', 'overview'], name: 'overview', moduleId: '../view-models/project-overview', nav: true, title: 'Overview' },
            { route: 'create', name: 'create', moduleId: '../view-models/project-create', nav: true, title: 'Create' },
            { route: 'join', name: 'join', moduleId: '../view-models/project-join', nav: true, title: 'Join' }
          ]);

        this.router = router;
    }
}