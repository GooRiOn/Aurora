define(["require", "exports"], function (require, exports) {
    var AuthService = (function () {
        function AuthService() {
            this.accessToken = '';
        }
        AuthService.prototype.setUser = function (user) {
            this.user = user;
        };
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
        };
        AuthService.prototype.getAccessToken = function () {
            var accessToken = sessionStorage.getItem('accessToken');
            if (accessToken)
                return accessToken;
            return localStorage.getItem('accessToken');
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
        return AuthService;
    })();
    exports.AuthService = AuthService;
});
//# sourceMappingURL=auth-service.js.map