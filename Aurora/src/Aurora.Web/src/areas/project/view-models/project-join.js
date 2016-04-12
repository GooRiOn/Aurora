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
    var JoinProjectViewModel = (function () {
        function JoinProjectViewModel(joinProjectService) {
            this.joinProjectService = joinProjectService;
        }
        JoinProjectViewModel.prototype.activate = function (params) {
            this.memberToken = params;
            this.joinProject();
        };
        JoinProjectViewModel.prototype.joinProject = function () {
            this.joinProjectService.joinProject(this.memberToken).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed)
                    Materialize.toast('WORKS!', 4000, 'btn');
            });
        };
        JoinProjectViewModel = __decorate([
            aurelia_framework_1.inject(services.ProjectJoinService), 
            __metadata('design:paramtypes', [services.ProjectJoinService])
        ], JoinProjectViewModel);
        return JoinProjectViewModel;
    }());
    exports.JoinProjectViewModel = JoinProjectViewModel;
});
//# sourceMappingURL=project-join.js.map