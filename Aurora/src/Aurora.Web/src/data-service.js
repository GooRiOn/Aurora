define(["require", "exports", "aurelia-fetch-client"], function (require, exports, aurelia_fetch_client_1) {
    var DataService = (function () {
        function DataService(http, authService) {
            this.authService = authService;
            this.http = http;
            this.http.configure(function (config) {
                config.withBaseUrl('http://localhost:49849/api/');
            });
        }
        DataService.prototype.get = function (url, isAccessTokenRequired) {
            var requestConfig = {};
            if (isAccessTokenRequired) {
                var accessToken = this.authService.getAccessToken();
                requestConfig.headers = { 'Authorization': "Bearer " + accessToken };
            }
            return this.http.fetch(url, requestConfig).then(function (response) { return response.json(); });
        };
        DataService.prototype.post = function (url, data, isAccessTokenRequired) {
            var requestConfig = {
                method: 'post',
                body: aurelia_fetch_client_1.json(data)
            };
            if (isAccessTokenRequired) {
                var accessToken = this.authService.getAccessToken();
                requestConfig.headers = { 'Authorization': "Bearer " + accessToken };
            }
            return this.http.fetch(url, requestConfig).then(function (response) { return response.json(); });
        };
        return DataService;
    })();
    exports.DataService = DataService;
});
//# sourceMappingURL=data-service.js.map