define(["require", "exports"], function (require, exports) {
    "use strict";
    var ProjectRouter = (function () {
        function ProjectRouter() {
            this.heading = 'Project';
        }
        ProjectRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: ['', 'overview'], name: 'overview', moduleId: '../view-models/project-overview', nav: true, title: 'Overview' },
                { route: 'create', name: 'create', moduleId: '../view-models/project-create', nav: true, title: 'Create' },
                { route: 'join', name: 'join', moduleId: '../view-models/project-join', nav: true, title: 'Join' }
            ]);
            this.router = router;
        };
        return ProjectRouter;
    }());
    exports.ProjectRouter = ProjectRouter;
});
//# sourceMappingURL=project-router.js.map