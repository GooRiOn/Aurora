var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../../../data-service', '../../../auth-service', 'aurelia-fetch-client', 'aurelia-framework'], function (require, exports, app, auth, aurelia_fetch_client_1, aurelia_framework_1) {
    var UserService = (function (_super) {
        __extends(UserService, _super);
        function UserService(http, authService) {
            _super.call(this, http, authService);
        }
        UserService.prototype.register = function (userRegisterDto) {
            return _super.prototype.post.call(this, 'Accounts/Register', userRegisterDto, false);
        };
        UserService.prototype.login = function (userLoginDto) {
            return _super.prototype.post.call(this, 'Accounts/Login', userLoginDto, false);
        };
        UserService.prototype.getUserSelfInfo = function () {
            return _super.prototype.get.call(this, 'Accounts/SelfInfo', true);
        };
        UserService.prototype.logout = function () {
            return _super.prototype.post.call(this, 'Accounts/SignOut', null, true);
        };
        UserService.prototype.sendPasswordResetEmail = function (userEmail) {
            var url = "Accounts/Password/Reset/" + userEmail + "/Email/Send";
            return _super.prototype.post.call(this, url, null, false);
        };
        UserService.prototype.resetUserPassword = function (userPasswordResetDto) {
            return _super.prototype.post.call(this, 'Accounts/Password/Reset', userPasswordResetDto, false);
        };
        UserService = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient, auth.AuthService), 
            __metadata('design:paramtypes', [aurelia_fetch_client_1.HttpClient, auth.AuthService])
        ], UserService);
        return UserService;
    })(app.DataService);
    exports.UserService = UserService;
});
//# sourceMappingURL=user-service.js.map