import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import models = require('../models/project-models');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

export interface IProjectBacklogService {

    getProjectacklogItems(projectId: number): Promise<models.ProjectBacklogItemModel[]>;
    //model
    createBacklogItem(project: models.ProjectBacklogItemModel): Promise<data.IResult>;
    updateBacklogItem(project: models.ProjectBacklogItemModel): Promise<data.IResult>;
    deleteBacklogItem(projectId: number): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class ProjectBacklogService extends app.DataService implements IProjectBacklogService {

    constructor(httpClient: HttpClient, authService: auth.AuthService) {
        super(httpClient, authService);
    }

    getProjectacklogItems(projectId: number): Promise<models.ProjectBacklogItemModel[]>
    {
        let url = `Backlogs/${projectId}`;
        return super.get(url, true);
    }

    createBacklogItem(project: models.ProjectBacklogItemModel): Promise<data.IResult>
    {
        return super.post('Backlogs/Create', project, true);
    }

    updateBacklogItem(project: models.ProjectBacklogItemModel): Promise<data.IResult>
    {
        return super.post('Backlogs/Update', project, true);
    }

    deleteBacklogItem(projectId: number): Promise<data.IResult>
    {
        let url = `Backlogs/${projectId}/Delete`;
        return super.post(url, null, true);
        
    }
}