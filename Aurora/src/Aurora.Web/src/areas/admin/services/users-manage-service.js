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
    "use strict";
    var UsersManageService = (function (_super) {
        __extends(UsersManageService, _super);
        function UsersManageService(http, authService) {
            _super.call(this, http, authService);
        }
        UsersManageService.prototype.getUsers = function (pageNumber, pageSize) {
            var url = "Admin/Users/" + pageNumber + "/Page/" + pageSize + "/Size";
            return _super.prototype.get.call(this, url, true);
        };
        UsersManageService.prototype.lockUser = function (userId) {
            var url = "Admin/Users/" + userId + "/Lock";
            return _super.prototype.post.call(this, url, null, true);
        };
        UsersManageService.prototype.unlockUser = function (userId) {
            var url = "Admin/Users/" + userId + "/Unlock";
            return _super.prototype.post.call(this, url, null, true);
        };
        UsersManageService.prototype.deleteUser = function (userId) {
            var url = "Admin/Users/" + userId + "/Delete";
            return _super.prototype.post.call(this, url, null, true);
        };
        UsersManageService.prototype.resetUserPassword = function (userId, newPassword) {
            var url = "Admin/Users/" + userId + "/Password/" + newPassword + "/Reset";
            return _super.prototype.post.call(this, url, null, true);
        };
        UsersManageService = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient, auth.AuthService), 
            __metadata('design:paramtypes', [aurelia_fetch_client_1.HttpClient, auth.AuthService])
        ], UsersManageService);
        return UsersManageService;
    }(app.DataService));
    exports.UsersManageService = UsersManageService;
});
//# sourceMappingURL=users-manage-service.js.map