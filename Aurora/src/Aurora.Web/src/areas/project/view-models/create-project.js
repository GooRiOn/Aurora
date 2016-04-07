var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../services/create-project-service', 'aurelia-framework', 'aurelia-binding'], function (require, exports, services, aurelia_framework_1, aurelia_binding_1) {
    "use strict";
    var CreateProjectViewModel = (function () {
        function CreateProjectViewModel(createProjectService, observerLocator) {
            this.createProjectService = createProjectService;
            this.observerLocator = observerLocator;
            this.observerLocator.getObserver(this, 'searchPhrase').subscribe(this.findUsersBySearchPhrase);
        }
        CreateProjectViewModel.prototype.findUsersBySearchPhrase = function () {
            var self = this;
            self.createProjectService.findUsersBySearchPhrase(self.searchPhrase).then(function (result) {
                self.users = result;
            });
        };
        CreateProjectViewModel = __decorate([
            aurelia_framework_1.inject(services.CreateProjectService, aurelia_binding_1.ObserverLocator), 
            __metadata('design:paramtypes', [services.CreateProjectService, aurelia_binding_1.ObserverLocator])
        ], CreateProjectViewModel);
        return CreateProjectViewModel;
    }());
    exports.CreateProjectViewModel = CreateProjectViewModel;
});
//# sourceMappingURL=create-project.js.map