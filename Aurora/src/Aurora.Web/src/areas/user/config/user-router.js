define(["require", "exports"], function (require, exports) {
    var ChildRouter = (function () {
        function ChildRouter() {
        }
        ChildRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: 'register', name: 'register', moduleId: '../view-models/register', nav: true, title: 'Register' },
            ]);
            this.router = router;
        };
        return ChildRouter;
    })();
    exports.ChildRouter = ChildRouter;
});
//# sourceMappingURL=user-router.js.map