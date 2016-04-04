import {Router, RouterConfiguration} from 'aurelia-router'

export class ProjectRouter {
    router: Router;
    heading = 'Project';

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: ['', 'overview'], name: 'overview', moduleId: '../view-models/project-overview', nav: true, title: 'Overview' },
            { route: 'create', name: 'create', moduleId: '../view-models/create-project', nav: true, title: 'Create' }
          ]);

        this.router = router;
    }
}