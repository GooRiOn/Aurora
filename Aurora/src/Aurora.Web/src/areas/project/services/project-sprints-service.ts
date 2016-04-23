import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import models = require('../models/project-models');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

export interface IProjectSpintsService
{
    getProjectSprints(projectId: number): Promise<models.SprintModel[]>;
    createSprint(sprint: models.SprintModel): Promise<data.IResult>;
    updateSprint(sprint: models.SprintModel): Promise<data.IResult>;
    deleteSprint(sprintId: number): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class ProjectSprintsService extends app.DataService implements IProjectSpintsService
{
    constructor(httpClient: HttpClient, authService: auth.AuthService)
    {
        super(httpClient, authService);
    }

    getProjectSprints(projectId: number): Promise<models.SprintModel[]>
    {
        let url = `Sprints/${projectId}`;
        return super.get(url, true);
    }

    createSprint(sprint: models.SprintModel): Promise<data.IResult>
    {
        return super.post('Sprints/Create', sprint, true);
    }

    updateSprint(sprint: models.SprintModel): Promise<data.IResult>
    {
        return super.post('Sprints/Update', sprint, true);
    }

    deleteSprint(sprintId: number): Promise<data.IResult>
    {
        let url = `Sprints/${sprintId}/Delete`;

        return super.post(url, null, true);
    }
}