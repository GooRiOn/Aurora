import models = require('../models/project-models');
import services = require('../services/project-sprints-service');
import data = require('../../../data');
import auth = require('../../../auth-service')
import {inject} from 'aurelia-framework';


@inject(services.ProjectSprintsService, auth.AuthService)
export class ProjectSprintsViewModel
{
    sprints: models.SprintModel[];
    activeSprint: models.SprintModel;
    isActiveSprintViewEnabled = false;

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
        this.isActiveSprintViewEnabled = true;
        this.activeSprint = new models.SprintModel();

        this.activeSprint.projectId = this.userDefaultProject.id;
    }

    activateSprintEdition(sprint: models.SprintModel)
    {
        this.activeSprint = sprint;
        this.isActiveSprintViewEnabled = true;
    }

    createSprint()
    {
        this.projectSprintsService.createSprint(this.activeSprint).then((result: data.IResult) =>
        {
            this.getProjectSprints();
            this.isActiveSprintViewEnabled = false;
            Materialize.toast('New sprint added!',4000, 'btn');
        });
    }

    updateSprint()
    {
        this.projectSprintsService.updateSprint(this.activeSprint).then((result: data.IResult) => {
            this.getProjectSprints();
            this.isActiveSprintViewEnabled = false;
            Materialize.toast('Sprint updated!', 4000, 'btn');
        });
    }

    deleteSprint()
    {
        let confirm = window.confirm('Are you sure?');

        if (!confirm)
            return;

        this.projectSprintsService.deleteSprint(this.activeSprint.id).then((result: data.IResult) => {
            this.getProjectSprints();
            this.isActiveSprintViewEnabled = false;
            Materialize.toast('Sprint deleted!', 4000, 'btn');
        });
    }

    clearActiveSprintView()
    {
        this.activeSprint = null;
        this.isActiveSprintViewEnabled = false;
    }

    getSprintStateByValue(value: number)
    {
        let state = this.sprintStates.firstOrNull(s => s.value === value);
        return state? state.name : '';
    }
}