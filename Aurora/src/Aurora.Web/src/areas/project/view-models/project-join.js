var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../services/project-join-service', '../../../data', 'aurelia-framework'], function (require, exports, services, data, aurelia_framework_1) {
    "use strict";
    var ProjectJoinViewModel = (function () {
        function ProjectJoinViewModel(joinProjectService) {
            this.isProjectJoinSucceed = false;
            this.joinProjectService = joinProjectService;
        }
        ProjectJoinViewModel.prototype.activate = function (params) {
            var memberToken = params.memberToken;
            this.joinProject(memberToken);
        };
        ProjectJoinViewModel.prototype.joinProject = function (memberToken) {
            var _this = this;
            this.joinProjectService.joinProject(memberToken).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    _this.isProjectJoinSucceed = true;
            });
        };
        ProjectJoinViewModel = __decorate([
            aurelia_framework_1.inject(services.ProjectJoinService), 
            __metadata('design:paramtypes', [services.ProjectJoinService])
        ], ProjectJoinViewModel);
        return ProjectJoinViewModel;
    }());
    exports.ProjectJoinViewModel = ProjectJoinViewModel;
});
//# sourceMappingURL=project-join.js.map