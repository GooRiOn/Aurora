import appModels = require('../../../models');
import models = require('../models/project-models');
import services = require('../services/create-project-service');
import data = require('../../../data');
import {inject, BindingEngine} from 'aurelia-framework';

@inject(services.CreateProjectService, BindingEngine)
export class CreateProjectViewModel
{
    searchPhrase: string;
    users: appModels.UserDto[];
    newProject: models.ProjectCreateDto;

    private createProjectService: services.ICreateProjectService;
    private bindingEngine: BindingEngine;

    constructor(createProjectService: services.CreateProjectService, bindingEngine: BindingEngine)
    {
        this.createProjectService = createProjectService;
        this.bindingEngine = bindingEngine;
        this.newProject = new models.ProjectCreateDto();

        this.bindingEngine.propertyObserver(this,'searchPhrase').subscribe((newValue, oldValue) =>
        {
            if (newValue.length === 0)
            {
                this.users = [];
                return;
            }

            if (newValue.length < 3)
                return;
            
            this.createProjectService.findUsersBySearchPhrase(this.searchPhrase).then((result: appModels.UserDto[]) => {
                this.users = result;
            });
        });
    }

    addProjectMember(user: appModels.UserDto)
    {
        let isUserAlreadyMember = this.newProject.members.some(m => m.id === user.id);

        if (isUserAlreadyMember)
        {
            Materialize.toast("You cannot add same user twice", 4000, 'btn orange');
            return;
        }

        this.newProject.members.push(user);
    }

    removeProjectMember(user: appModels.UserDto)
    {
        this.newProject.members.remove(user);
    }
}