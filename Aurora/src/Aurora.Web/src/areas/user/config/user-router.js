define(["require", "exports"], function (require, exports) {
    var UserRouter = (function () {
        function UserRouter() {
            this.heading = 'User';
        }
        UserRouter.prototype.configureRouter = function (config, router) {
            config.map([
                { route: ['', 'register'], name: 'register', moduleId: '../view-models/register', nav: true, title: 'Register' },
                { route: 'login', name: 'login', moduleId: '../view-models/login', nav: true, title: 'Login' },
                { route: 'password-reset', name: 'password-reset', moduleId: '../view-models/password-reset', nav: true, title: 'Password reset' },
            ]);
            this.router = router;
        };
        return UserRouter;
    })();
    exports.UserRouter = UserRouter;
});
//# sourceMappingURL=user-router.js.map