var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", "../../../auth-service", "../services/user-service", "../models/user-models", "../../../data", 'aurelia-framework', 'aurelia-router'], function (require, exports, auth, userServices, models, data, aurelia_framework_1, aurelia_router_1) {
    var LoginViewModel = (function () {
        function LoginViewModel(userService, authService, router) {
            this.router = router;
            this.userService = userService;
            this.authService = authService;
            this.userLoginDto = new models.UserLoginDto();
        }
        LoginViewModel.prototype.login = function () {
            var _this = this;
            this.userService.login(this.userLoginDto).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed) {
                    var token = result.content;
                    _this.authService.setAccessToken(token, !_this.userLoginDto.rememberMe);
                    _this.getUserSelfInfo().then(function () {
                        Materialize.toast("welcome " + _this.authService.user.userName, 4000, 'btn');
                        _this.router.navigate('#/');
                    });
                }
                else {
                    for (var _i = 0, _a = result.errors; _i < _a.length; _i++) {
                        var error = _a[_i];
                        Materialize.toast(error, 4000, 'btn orange');
                    }
                }
            });
        };
        LoginViewModel.prototype.getUserSelfInfo = function () {
            var _this = this;
            return this.userService.getUserSelfInfo().then(function (result) {
                var user = { userName: result.content.userName, roles: result.content.roles };
                _this.authService.setUser(user);
            });
        };
        LoginViewModel.prototype.changeRememberMeState = function () {
            this.userLoginDto.rememberMe = !this.userLoginDto.rememberMe;
            Materialize.toast(this.userLoginDto.rememberMe.toString(), 4000);
        };
        LoginViewModel = __decorate([
            aurelia_framework_1.inject(userServices.UserService, auth.AuthService, aurelia_router_1.Router), 
            __metadata('design:paramtypes', [userServices.UserService, auth.AuthService, aurelia_router_1.Router])
        ], LoginViewModel);
        return LoginViewModel;
    })();
    exports.LoginViewModel = LoginViewModel;
});
//# sourceMappingURL=login.js.map