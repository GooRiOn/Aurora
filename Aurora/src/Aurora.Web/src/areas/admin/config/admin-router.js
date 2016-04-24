define(["require", "exports"], function (require, exports) {
    "use strict";
    var AdminRouter = (function () {
        function AdminRouter() {
            this.heading = 'Admin';
        }
        AdminRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: ['', 'users-manage'], name: 'users-manage', moduleId: '../view-models/users-manage', nav: true, title: 'UsersManage' },
            ]);
            this.router = router;
        };
        return AdminRouter;
    }());
    exports.AdminRouter = AdminRouter;
});
//# sourceMappingURL=admin-router.js.map