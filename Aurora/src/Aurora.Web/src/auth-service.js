define(["require", "exports"], function (require, exports) {
    var AuthService = (function () {
        function AuthService() {
            this.accessToken = '';
        }
        AuthService.prototype.setAccessToken = function (accessToken, isSessionStored) {
            if (isSessionStored) {
                sessionStorage.setItem('accessToken', accessToken);
                localStorage.clear();
            }
            else {
                localStorage.setItem('accessToken', accessToken);
                sessionStorage.clear();
            }
            this.accessToken = accessToken;
            this.isSessionStored = isSessionStored;
        };
        AuthService.prototype.getAccessToken = function () {
            if (this.isSessionStored)
                return sessionStorage.getItem('accessToken');
            else
                return localStorage.getItem('accessToken');
        };
        AuthService.prototype.clearAccessToken = function () {
            localStorage.clear();
            sessionStorage.clear();
            document.cookie = '';
            this.setAccessToken('', true);
        };
        AuthService.prototype.isUserAdmin = function () {
            if (!this.user || !this.user.isLoggedIn)
                return false;
            return this.user.userRoles.some(function (r) { return r === 'Admin'; });
        };
        return AuthService;
    })();
    exports.AuthService = AuthService;
});
//# sourceMappingURL=auth-service.js.map