import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface IProjectOverviewService {
}

@inject(HttpClient, auth.AuthService)
export class ProjectOverviewService extends app.DataService implements IProjectOverviewService {

    constructor(http: HttpClient, authService: auth.AuthService) {
        super(http, authService);
    }
}