define(["require", "exports", 'areas/user/view-models/login', "jquery", "Dogfalo/materialize"], function (require, exports, userAuth) {
    function configure(aurelia) {
        aurelia.use
            .standardConfiguration()
            .developmentLogging();
        aurelia.start().then(function () {
            aurelia.setRoot();
            var userLoginVM = aurelia.container.get(userAuth.LoginViewModel);
            userLoginVM.getUserSelfInfo();
        });
    }
    exports.configure = configure;
});
//# sourceMappingURL=main.js.map