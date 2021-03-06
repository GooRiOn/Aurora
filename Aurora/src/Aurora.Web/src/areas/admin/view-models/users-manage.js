var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../services/users-manage-service', '../../../data', 'aurelia-framework'], function (require, exports, services, data, aurelia_framework_1) {
    "use strict";
    var UsersManageViewModel = (function () {
        function UsersManageViewModel(usesManageService) {
            this.pageNumber = 1;
            this.pageSize = 5;
            this.totalPages = 1;
            this.usesManageService = usesManageService;
        }
        UsersManageViewModel.prototype.activate = function () {
            this.getUsers();
        };
        UsersManageViewModel.prototype.getUsers = function () {
            var _this = this;
            this.usesManageService.getUsers(this.pageNumber, this.pageSize).then(function (result) {
                _this.users = result.content;
                _this.totalPages = result.totalPages;
            });
        };
        UsersManageViewModel.prototype.changeUserLockout = function (user) {
            var promise = this.usesManageService.lockUser(user.id);
            if (user.isLocked)
                promise = this.usesManageService.unlockUser(user.id);
            promise.then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    user.isLocked = !user.isLocked;
                else
                    Materialize.toast('An error has occured', 4000, 'red');
            });
        };
        UsersManageViewModel.prototype.unlockUser = function (user) {
            this.usesManageService.unlockUser(user.id).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    user.isLocked = false;
                else
                    Materialize.toast('An error has occured', 4000, 'red');
            });
        };
        UsersManageViewModel.prototype.deleteUser = function (user) {
            var self = this;
            var confirm = window.confirm('Do ypu want to delete user permanently?');
            if (!confirm)
                return;
            self.usesManageService.deleteUser(user.id).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    self.users.remove(user);
                else
                    Materialize.toast('An error has occured', 4000, 'red');
            });
        };
        UsersManageViewModel.prototype.resetUserPassword = function (user) {
            var newPassword = prompt("Enter new password");
            if (!newPassword)
                return;
            this.usesManageService.resetUserPassword(user.id, newPassword).then(function (result) {
                Materialize.toast('Password changed', 4000, 'green');
            });
        };
        UsersManageViewModel.prototype.getUsersPreviousPage = function () {
            this.pageNumber -= 1;
            if (this.pageNumber < 1)
                this.pageNumber = 1;
            this.getUsers();
        };
        UsersManageViewModel.prototype.getUsersNextPage = function () {
            this.pageNumber += 1;
            if (this.pageNumber > this.totalPages)
                this.pageNumber = this.totalPages;
            this.getUsers();
        };
        UsersManageViewModel = __decorate([
            aurelia_framework_1.inject(services.UsersManageService), 
            __metadata('design:paramtypes', [services.UsersManageService])
        ], UsersManageViewModel);
        return UsersManageViewModel;
    }());
    exports.UsersManageViewModel = UsersManageViewModel;
});
//# sourceMappingURL=users-manage.js.map