/// <reference path="../../../../typings/materialize.d.ts" />

import models = require('../models/project-models');
import services = require('../services/project-sprints-service');
import data = require('../../../data');
import auth = require('../../../auth-service')
import {inject} from 'aurelia-framework';


@inject(services.ProjectSprintsService, auth.AuthService)
export class ProjectSprintsViewModel
{
    sprints: models.SprintModel[];
    newSprint: models.SprintModel;
    isNewSprintCreating = false;
    userDefaultProject: auth.IUserProject;

    sprintStates = [
        { name: 'Past', value: models.SprintState.Past },
        { name: 'Current', value: models.SprintState.Currnet },
        { name: 'Future', value: models.SprintState.Future }
    ];

    private projectSprintsService: services.IProjectSpintsService;
    private authService: auth.IAuthService;

    constructor(projectSprintsService: services.ProjectSprintsService, authService: auth.AuthService)
    {
        this.projectSprintsService = projectSprintsService;
        this.authService = authService;
    }
    
    activate()
    {
        this.userDefaultProject = this.authService.getUserDefaultProject();

        if (! this.userDefaultProject.id)
            return;

        this.getProjectSprints();
    }

    getProjectSprints()
    {
        this.projectSprintsService.getProjectSprints(this.userDefaultProject.id).then((result: models.SprintModel[]) => {
            this.sprints = result;
        });
    }

    activateNewSprintCreation()
    {
        this.isNewSprintCreating = true;
        this.newSprint = new models.SprintModel();

        this.newSprint.projectId = this.userDefaultProject.id;
    }

    createSprint()
    {
        this.projectSprintsService.createSprint(this.newSprint).then((result: data.IResult) =>
        {
            this.getProjectSprints();
            this.isNewSprintCreating = false;
            Materialize.toast('New sprint added!',4000, 'btn');
        });
    }

    getSprintStateByValue(value: number)
    {
        let state = this.sprintStates.firstOrNull(s => s.value === value);
        return state? state.name : '';
    }
}