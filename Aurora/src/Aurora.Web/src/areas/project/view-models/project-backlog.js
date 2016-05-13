var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../models/project-models', '../services/project-backlog-service', '../services/project-sprints-service', '../../../materialize-helper', '../../../auth-service', 'aurelia-framework'], function (require, exports, models, services, sprintServices, materialize, auth, aurelia_framework_1) {
    "use strict";
    var ProjectSprintsViewModel = (function () {
        function ProjectSprintsViewModel(projectBacklogService, sprintService, authService) {
            this.backlogItemStates = [
                { name: "New", value: models.BacklogItemState.New },
                { name: "Approved", value: models.BacklogItemState.Approved },
                { name: "Commited", value: models.BacklogItemState.Commited },
                { name: "Done", value: models.BacklogItemState.Done },
                { name: "Removed", value: models.BacklogItemState.Removed },
            ];
            this.projectBacklogService = projectBacklogService;
            this.sprintService = sprintService;
            this.authService = authService;
        }
        ProjectSprintsViewModel.prototype.attached = function () {
            materialize.MaterializeHelper.initializeDropdown('select');
        };
        ProjectSprintsViewModel.prototype.activate = function () {
            this.userDefaultProject = this.authService.getUserDefaultProject();
            if (!this.userDefaultProject.id)
                return;
            this.getProjectBacklogItems();
            this.getProjectSprints();
        };
        ProjectSprintsViewModel.prototype.getProjectBacklogItems = function () {
            var _this = this;
            this.projectBacklogService.getProjectacklogItems(this.userDefaultProject.id).then(function (result) {
                _this.backlogItems = result;
            });
        };
        ProjectSprintsViewModel.prototype.getProjectSprints = function () {
            var _this = this;
            this.sprintService.getProjectSprints(this.userDefaultProject.id).then(function (result) {
                _this.sprints = result;
            });
        };
        ProjectSprintsViewModel.prototype.createBacklogItem = function () {
            this.projectBacklogService.createBacklogItem(this.activeBacklogItem).then(function (result) {
            });
        };
        ProjectSprintsViewModel.prototype.updateBacklogItem = function () {
            this.projectBacklogService.updateBacklogItem(this.activeBacklogItem).then(function (result) {
            });
        };
        ProjectSprintsViewModel.prototype.deleteBacklogItem = function (backlogItemId) {
            this.projectBacklogService.deleteBacklogItem(backlogItemId).then(function (result) {
            });
        };
        ProjectSprintsViewModel.prototype.activateNewBacklogItemCreation = function () {
            this.activeBacklogItem = new models.ProjectBacklogItemModel();
            this.isActiveBacklogItemViewEnabled = true;
        };
        ProjectSprintsViewModel.prototype.clearActiveBacklogItemView = function () {
            this.activeBacklogItem = null;
            this.isActiveBacklogItemViewEnabled = false;
        };
        ProjectSprintsViewModel.prototype.getBacklogItemStateByValue = function (value) {
            var state = this.backlogItemStates.firstOrNull(function (i) { return i.value === value; });
            return state ? state.name : '';
        };
        ProjectSprintsViewModel = __decorate([
            aurelia_framework_1.inject(services.ProjectBacklogService, sprintServices.ProjectSprintsService, auth.AuthService), 
            __metadata('design:paramtypes', [services.ProjectBacklogService, sprintServices.ProjectSprintsService, auth.AuthService])
        ], ProjectSprintsViewModel);
        return ProjectSprintsViewModel;
    }());
    exports.ProjectSprintsViewModel = ProjectSprintsViewModel;
});
//# sourceMappingURL=project-backlog.js.map