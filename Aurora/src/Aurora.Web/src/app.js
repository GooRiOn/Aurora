var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', "auth-service", 'areas/user/static-view-models/logout'], function (require, exports, aurelia_framework_1, auth, userAuth) {
    var App = (function () {
        function App(authService, logoutStaticViewModel) {
            this.logoutStaticViewModel = logoutStaticViewModel;
            this.authService = authService;
        }
        App.prototype.logout = function () {
            this.logoutStaticViewModel.logout();
        };
        App.prototype.configureRouter = function (config, router) {
            config.title = 'Aurelia';
            config.map([
                { route: ['', 'welcome'], name: 'welcome', moduleId: 'welcome', nav: true, title: 'Welcome' },
                { route: 'user', name: 'user', moduleId: 'areas/user/config/user-router', nav: true, title: 'User' },
                { route: 'admin', name: 'admin', moduleId: 'areas/admin/config/admin-router', nav: true, title: 'Admin' }
            ]);
            this.router = router;
        };
        App = __decorate([
            aurelia_framework_1.inject(auth.AuthService, userAuth.LogoutStaticViewModel), 
            __metadata('design:paramtypes', [auth.AuthService, userAuth.LogoutStaticViewModel])
        ], App);
        return App;
    })();
    exports.App = App;
});
//# sourceMappingURL=app.js.map