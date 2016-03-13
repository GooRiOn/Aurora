var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', "../services/user-service", "../models/user-models"], function (require, exports, aurelia_framework_1, UserServices, UserModels) {
    var RegisterViewModel = (function () {
        function RegisterViewModel(userService) {
            this.userService = userService;
            this.userRegisterModel = new UserModels.UserRegisterModel();
        }
        RegisterViewModel.prototype.register = function () {
            this.userService.register(this.userRegisterModel).then(function (response) {
                var test = response;
            });
        };
        RegisterViewModel = __decorate([
            aurelia_framework_1.inject(UserServices.UserService), 
            __metadata('design:paramtypes', [UserServices.UserService])
        ], RegisterViewModel);
        return RegisterViewModel;
    })();
    exports.RegisterViewModel = RegisterViewModel;
});
//# sourceMappingURL=register.js.map