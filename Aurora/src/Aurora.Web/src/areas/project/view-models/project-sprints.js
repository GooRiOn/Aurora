var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../models/project-models', '../services/project-sprints-service', '../../../auth-service', 'aurelia-framework'], function (require, exports, models, services, auth, aurelia_framework_1) {
    "use strict";
    var ProjectSprintsViewModel = (function () {
        function ProjectSprintsViewModel(projectSprintsService, authService) {
            this.isActiveSprintViewEnabled = false;
            this.sprintStates = [
                { name: 'Past', value: models.SprintState.Past },
                { name: 'Current', value: models.SprintState.Currnet },
                { name: 'Future', value: models.SprintState.Future }
            ];
            this.projectSprintsService = projectSprintsService;
            this.authService = authService;
        }
        ProjectSprintsViewModel.prototype.activate = function () {
            this.userDefaultProject = this.authService.getUserDefaultProject();
            if (!this.userDefaultProject.id)
                return;
            this.getProjectSprints();
        };
        ProjectSprintsViewModel.prototype.getProjectSprints = function () {
            var _this = this;
            this.projectSprintsService.getProjectSprints(this.userDefaultProject.id).then(function (result) {
                _this.sprints = result;
            });
        };
        ProjectSprintsViewModel.prototype.activateNewSprintCreation = function () {
            this.isActiveSprintViewEnabled = true;
            this.activeSprint = new models.SprintModel();
            this.activeSprint.projectId = this.userDefaultProject.id;
        };
        ProjectSprintsViewModel.prototype.activateSprintEdition = function (sprint) {
            this.activeSprint = sprint;
            this.isActiveSprintViewEnabled = true;
        };
        ProjectSprintsViewModel.prototype.createSprint = function () {
            var _this = this;
            this.projectSprintsService.createSprint(this.activeSprint).then(function (result) {
                _this.getProjectSprints();
                _this.isActiveSprintViewEnabled = false;
                Materialize.toast('New sprint added!', 4000, 'btn');
            });
        };
        ProjectSprintsViewModel.prototype.updateSprint = function () {
            var _this = this;
            this.projectSprintsService.updateSprint(this.activeSprint).then(function (result) {
                _this.getProjectSprints();
                _this.isActiveSprintViewEnabled = false;
                Materialize.toast('Sprint updated!', 4000, 'btn');
            });
        };
        ProjectSprintsViewModel.prototype.deleteSprint = function () {
            var _this = this;
            var confirm = window.confirm('Are you sure?');
            if (!confirm)
                return;
            this.projectSprintsService.deleteSprint(this.activeSprint.id).then(function (result) {
                _this.getProjectSprints();
                _this.isActiveSprintViewEnabled = false;
                Materialize.toast('Sprint deleted!', 4000, 'btn');
            });
        };
        ProjectSprintsViewModel.prototype.clearActiveSprintView = function () {
            this.activeSprint = null;
            this.isActiveSprintViewEnabled = false;
        };
        ProjectSprintsViewModel.prototype.getSprintStateByValue = function (value) {
            var state = this.sprintStates.firstOrNull(function (s) { return s.value === value; });
            return state ? state.name : '';
        };
        ProjectSprintsViewModel = __decorate([
            aurelia_framework_1.inject(services.ProjectSprintsService, auth.AuthService), 
            __metadata('design:paramtypes', [services.ProjectSprintsService, auth.AuthService])
        ], ProjectSprintsViewModel);
        return ProjectSprintsViewModel;
    }());
    exports.ProjectSprintsViewModel = ProjectSprintsViewModel;
});
//# sourceMappingURL=project-sprints.js.map