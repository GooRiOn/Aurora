﻿import userModels = require('../../user/models/user-models');
import models = require('../models/project-models');
import services = require('../services/create-project-service');
import data = require('../../../data');
import userSerices = require('../../user/services/user-service'); 
import {inject, BindingEngine} from 'aurelia-framework';

@inject(services.CreateProjectService, userSerices.UserService, BindingEngine)
export class CreateProjectViewModel
{
    searchPhrase: string;
    users: userModels.UserModel[];
    newProject: models.ProjectCreateModel;

    private createProjectService: services.ICreateProjectService;
    private userService: userSerices.IUserService;
    private bindingEngine: BindingEngine;

    constructor(createProjectService: services.CreateProjectService, userService: userSerices.UserService, bindingEngine: BindingEngine)
    {
        this.createProjectService = createProjectService;
        this.userService = userService;
        this.bindingEngine = bindingEngine;
        this.newProject = new models.ProjectCreateModel();

        this.bindingEngine.propertyObserver(this,'searchPhrase').subscribe((newValue, oldValue) =>
        {
            if (newValue.length === 0)
            {
                this.users = [];
                return;
            }

            if (newValue.length < 3)
                return;
            
            this.userService.findUsersBySearchPhrase(this.searchPhrase).then((result: userModels.UserModel[]) => {
                this.users = result;
            });
        });
    }

    addProjectMember(user: userModels.UserModel)
    {
        let isUserAlreadyMember = this.newProject.members.some(m => m.id === user.id);

        if (isUserAlreadyMember)
        {
            Materialize.toast("You cannot add same user twice", 4000, 'btn orange');
            return;
        }

        this.newProject.members.push(user);
    }

    removeProjectMember(user: userModels.UserModel)
    {
        this.newProject.members.remove(user);
    }

    createProject()
    {
        this.createProjectService.createProject(this.newProject).then((result: data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
                Materialize.toast('Project created', 4000, 'btn');
        });
    }
}