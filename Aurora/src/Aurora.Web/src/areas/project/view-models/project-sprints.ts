import models = require('../models/project-models');
import services = require('../services/project-sprints-service');
import data = require('../../../data');
import auth = require('../../../auth-service')
import {inject} from 'aurelia-framework';


@inject(services.ProjectSprintsService, auth.AuthService)
export class ProjectSprintsViewModel
{
    sprints: models.SprintModel[];

    private projectSprintsService: services.IProjectSpintsService;
    private authService: auth.IAuthService;

    constructor(projectSprintsService: services.ProjectSprintsService, authService: auth.AuthService)
    {
        this.projectSprintsService = projectSprintsService;
        this.authService = authService;
    }

    activate()
    {
        let userDefaultProject = this.authService.getUserDefaultProject();

        if (!userDefaultProject.id)
            return;

        this.projectSprintsService.getProjectSprints(userDefaultProject.id).then((result: models.SprintModel[]) =>
        {
            this.sprints = result;
        });
    }

    createSprint()
    {
        
    }
}