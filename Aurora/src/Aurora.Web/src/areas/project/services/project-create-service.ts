﻿import models = require('../models/project-models');
import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface IProjectCreateService {
    createProject(project: models.ProjectCreateModel): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class ProjectCreateService extends app.DataService implements IProjectCreateService {

    constructor(http: HttpClient, authService: auth.AuthService) {
        super(http, authService);
    }

    createProject(project: models.ProjectCreateModel): Promise<data.IResult> {
        return super.post('Projects/Create', project , true);
    }
}