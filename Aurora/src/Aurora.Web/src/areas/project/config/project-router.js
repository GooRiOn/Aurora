define(["require", "exports"], function (require, exports) {
    "use strict";
    var ProjectRouter = (function () {
        function ProjectRouter() {
            this.heading = 'Project';
        }
        ProjectRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: ['', 'dashboard'], name: 'dashboard', moduleId: '../view-models/project-dashboard', nav: true, title: 'Dashboard' },
                { route: 'create', name: 'create', moduleId: '../view-models/project-create', nav: true, title: 'Create' },
                { route: 'join', name: 'join', moduleId: '../view-models/project-join', nav: true, title: 'Join' },
                { route: 'sprints', name: 'sprints', moduleId: '../view-models/project-sprints', nav: true, title: 'Sprints' },
                { route: 'backlog', name: 'backlog', moduleId: '../view-models/project-backlog', nav: true, title: 'Backlog' },
            ]);
            this.router = router;
        };
        return ProjectRouter;
    }());
    exports.ProjectRouter = ProjectRouter;
});
//# sourceMappingURL=project-router.js.map