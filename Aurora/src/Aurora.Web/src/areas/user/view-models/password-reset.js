var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../services/user-service', '../../../data', 'aurelia-framework', 'aurelia-router'], function (require, exports, userServices, data, aurelia_framework_1, aurelia_router_1) {
    var PasswordResetViewModel = (function () {
        function PasswordResetViewModel(userService, router) {
            this.router = router;
            this.userService = userService;
        }
        PasswordResetViewModel.prototype.activate = function (params) {
            this.userResetPasswordDto = params;
        };
        PasswordResetViewModel.prototype.sendPasswordResetEmail = function () {
            this.userService.sendPasswordResetEmail(this.userEmail).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    Materialize.toast('An email has been sent to you', 4000, 'btn');
            });
        };
        PasswordResetViewModel.prototype.resetUserPassword = function () {
            var _this = this;
            this.userService.resetUserPassword(this.userResetPasswordDto).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed) {
                    _this.router.navigate('#/user/login');
                    Materialize.toast('Operation succeed. Login now !', 4000, 'btn');
                }
                else {
                    for (var _i = 0, _a = result.errors; _i < _a.length; _i++) {
                        var error = _a[_i];
                        Materialize.toast(error, 4000, 'btn orange');
                    }
                }
            });
        };
        PasswordResetViewModel = __decorate([
            aurelia_framework_1.inject(userServices.UserService, aurelia_router_1.Router), 
            __metadata('design:paramtypes', [userServices.UserService, aurelia_router_1.Router])
        ], PasswordResetViewModel);
        return PasswordResetViewModel;
    })();
    exports.PasswordResetViewModel = PasswordResetViewModel;
});
//# sourceMappingURL=password-reset.js.map