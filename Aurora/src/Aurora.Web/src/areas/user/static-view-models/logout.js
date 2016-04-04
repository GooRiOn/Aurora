var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../../../auth-service', '../services/user-service', 'aurelia-framework'], function (require, exports, auth, userServices, aurelia_framework_1) {
    var LogoutStaticViewModel = (function () {
        function LogoutStaticViewModel(authService, userService) {
            this.authService = authService;
            this.userService = userService;
        }
        LogoutStaticViewModel.prototype.logout = function () {
            var _this = this;
            this.userService.logout().then(function (result) {
                _this.authService.clearAccessToken();
                _this.authService.setUser(null);
            });
        };
        LogoutStaticViewModel = __decorate([
            aurelia_framework_1.inject(auth.AuthService, userServices.UserService), 
            __metadata('design:paramtypes', [auth.AuthService, userServices.UserService])
        ], LogoutStaticViewModel);
        return LogoutStaticViewModel;
    })();
    exports.LogoutStaticViewModel = LogoutStaticViewModel;
});
//# sourceMappingURL=logout.js.map