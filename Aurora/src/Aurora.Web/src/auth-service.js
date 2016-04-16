define(["require", "exports"], function (require, exports) {
    "use strict";
    var AuthService = (function () {
        function AuthService() {
            this.accessToken = '';
            this.isSessionStored = true;
        }
        AuthService.prototype.getUser = function () {
            return this.user;
        };
        AuthService.prototype.setUser = function (user) {
            this.user = user;
        };
        AuthService.prototype.setAccessToken = function (accessToken, isSessionStored) {
            if (isSessionStored) {
                localStorage.setItem('accessToken', accessToken);
                sessionStorage.clear();
            }
            else {
                sessionStorage.setItem('accessToken', accessToken);
                localStorage.clear();
            }
            this.accessToken = accessToken;
            this.isSessionStored = isSessionStored;
        };
        AuthService.prototype.getAccessToken = function () {
            return this.isSessionStored ? localStorage.getItem('accessToken') : sessionStorage.getItem('accessToken');
        };
        AuthService.prototype.clearAccessToken = function () {
            localStorage.clear();
            sessionStorage.clear();
            document.cookie = '';
            this.setAccessToken('', true);
        };
        AuthService.prototype.isUserAdmin = function () {
            if (!this.user)
                return false;
            return this.user.roles.some(function (r) { return r === 'Admin'; });
        };
        AuthService.prototype.isUserLogged = function () {
            return this.user !== null;
        };
        return AuthService;
    }());
    exports.AuthService = AuthService;
});
//# sourceMappingURL=auth-service.js.map