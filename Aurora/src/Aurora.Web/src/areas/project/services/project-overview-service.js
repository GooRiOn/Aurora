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
    var ProjectOverviewService = (function (_super) {
        __extends(ProjectOverviewService, _super);
        function ProjectOverviewService(http, authService) {
            _super.call(this, http, authService);
        }
        ProjectOverviewService = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient, auth.AuthService), 
            __metadata('design:paramtypes', [aurelia_fetch_client_1.HttpClient, auth.AuthService])
        ], ProjectOverviewService);
        return ProjectOverviewService;
    })(app.DataService);
    exports.ProjectOverviewService = ProjectOverviewService;
});
//# sourceMappingURL=project-overview-service.js.map