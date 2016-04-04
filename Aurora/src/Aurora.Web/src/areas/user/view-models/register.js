var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../services/user-service', '../models/user-models', '../../../data', 'aurelia-framework', 'aurelia-router'], function (require, exports, userServices, models, data, aurelia_framework_1, aurelia_router_1) {
    var RegisterViewModel = (function () {
        function RegisterViewModel(userService, router) {
            this.router = router;
            this.userService = userService;
            this.userRegisterDto = new models.UserRegisterDto();
        }
        RegisterViewModel.prototype.register = function () {
            var _this = this;
            if (this.userRegisterDto.password !== this.userRegisterDto.confirmPassword) {
                Materialize.toast('Password and confirm password dont match', 4000, 'btn orange');
                return;
            }
            this.userService.register(this.userRegisterDto).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed) {
                    _this.router.navigate('#/user/login');
                    Materialize.toast('Registration completed. Login now !', 4000, 'btn');
                }
                else {
                    for (var _i = 0, _a = result.errors; _i < _a.length; _i++) {
                        var error = _a[_i];
                        Materialize.toast(error, 4000, 'btn orange');
                    }
                }
            });
        };
        RegisterViewModel = __decorate([
            aurelia_framework_1.inject(userServices.UserService, aurelia_router_1.Router), 
            __metadata('design:paramtypes', [userServices.UserService, aurelia_router_1.Router])
        ], RegisterViewModel);
        return RegisterViewModel;
    })();
    exports.RegisterViewModel = RegisterViewModel;
});
//# sourceMappingURL=register.js.map