import models = require('../models/project-models');
import services = require('../services/project-backlog-service');
import data = require('../../../data');
import materialize = require('../../../materialize-helper');
import auth = require('../../../auth-service')
import {inject} from 'aurelia-framework';


@inject(services.ProjectBacklogService, auth.AuthService)
export class ProjectSprintsViewModel {

    userDefaultProject: auth.IUserProject;

    private projectBacklogService: services.IProjectBacklogService;
    private authService: auth.IAuthService;

    constructor(projectBacklogService: services.ProjectBacklogService, authService: auth.AuthService) {
        this.projectBacklogService = projectBacklogService;
        this.authService = authService;
    }

    attached()
    {
        materialize.MaterializeHelper.initializeDropdown('select');
    }

    activate() {
        this.userDefaultProject = this.authService.getUserDefaultProject();

        if (!this.userDefaultProject.id)
            return;
    }
}