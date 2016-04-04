import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface ICreateProjectService {
}

@inject(HttpClient, auth.AuthService)
export class CreateProjectService extends app.DataService implements ICreateProjectService {

    constructor(http: HttpClient, authService: auth.AuthService) {
        super(http, authService);
    }
}