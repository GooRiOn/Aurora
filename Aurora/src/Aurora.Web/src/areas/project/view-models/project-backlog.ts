import models = require('../models/project-models');
import services = require('../services/project-backlog-service');
import data = require('../../../data');
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
        //hack as hell. Forgive me...
        let document;

        $('').ready(() => {
            $('select').material_select();
        });
    }

    activate() {
        this.userDefaultProject = this.authService.getUserDefaultProject();

        if (!this.userDefaultProject.id)
            return;
    }
}