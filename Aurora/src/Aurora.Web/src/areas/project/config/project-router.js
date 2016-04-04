define(["require", "exports"], function (require, exports) {
    var ProjectRouter = (function () {
        function ProjectRouter() {
            this.heading = 'Project';
        }
        ProjectRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: ['', 'overview'], name: 'overview', moduleId: '../view-models/project-overview', nav: true, title: 'Overview' }
            ]);
            this.router = router;
        };
        return ProjectRouter;
    })();
    exports.ProjectRouter = ProjectRouter;
});
//# sourceMappingURL=project-router.js.map