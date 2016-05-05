import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import models = require('../models/project-models');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

export interface IProjectBacklogService {
}

@inject(HttpClient, auth.AuthService)
export class ProjectBacklogService extends app.DataService implements IProjectBacklogService {

    constructor(httpClient: HttpClient, authService: auth.AuthService) {
        super(httpClient, authService);
    }


}