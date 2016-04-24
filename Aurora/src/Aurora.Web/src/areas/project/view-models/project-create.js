var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../models/project-models', '../services/project-create-service', '../../../data', '../../user/services/user-service', 'aurelia-framework', 'aurelia-router'], function (require, exports, models, services, data, userSerices, aurelia_framework_1, aurelia_router_1) {
    "use strict";
    var CreateProjectViewModel = (function () {
        function CreateProjectViewModel(createProjectService, userService, bindingEngine, router) {
            var _this = this;
            this.bindingEngine = bindingEngine;
            this.router = router;
            this.createProjectService = createProjectService;
            this.userService = userService;
            this.newProject = new models.ProjectCreateModel();
            this.bindingEngine.propertyObserver(this, 'searchPhrase').subscribe(function (newValue, oldValue) {
                if (newValue.length === 0) {
                    _this.users = [];
                    return;
                }
                if (newValue.length < 3)
                    return;
                _this.userService.findUsersBySearchPhrase(_this.searchPhrase).then(function (result) {
                    _this.users = result;
                });
            });
        }
        CreateProjectViewModel.prototype.addProjectMember = function (user) {
            var isUserAlreadyMember = this.newProject.members.some(function (m) { return m.id === user.id; });
            if (isUserAlreadyMember) {
                Materialize.toast('You cannot add same user twice', 4000, 'btn orange');
                return;
            }
            this.newProject.members.push(user);
        };
        CreateProjectViewModel.prototype.removeProjectMember = function (user) {
            this.newProject.members.remove(user);
        };
        CreateProjectViewModel.prototype.createProject = function () {
            var _this = this;
            this.createProjectService.createProject(this.newProject).then(function (result) {
                if (result.state === data.ResultStateEnum.Succeed) {
                    Materialize.toast('Project created', 4000, 'btn');
                    _this.router.navigate('#/project/overview');
                }
                else {
                    for (var _i = 0, _a = result.errors; _i < _a.length; _i++) {
                        var error = _a[_i];
                        Materialize.toast(error, 4000, 'btn orange');
                    }
                }
            });
        };
        CreateProjectViewModel = __decorate([
            aurelia_framework_1.inject(services.ProjectCreateService, userSerices.UserService, aurelia_framework_1.BindingEngine, aurelia_router_1.Router), 
            __metadata('design:paramtypes', [services.ProjectCreateService, userSerices.UserService, aurelia_framework_1.BindingEngine, aurelia_router_1.Router])
        ], CreateProjectViewModel);
        return CreateProjectViewModel;
    }());
    exports.CreateProjectViewModel = CreateProjectViewModel;
});
//# sourceMappingURL=project-create.js.map