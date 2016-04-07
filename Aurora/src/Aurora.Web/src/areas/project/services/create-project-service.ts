import appModels = require('../../../models');
import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface ICreateProjectService {
    findUsersBySearchPhrase(searchPhrase: string): Promise<appModels.UserDto[]>
}

@inject(HttpClient, auth.AuthService)
export class CreateProjectService extends app.DataService implements ICreateProjectService {

    constructor(http: HttpClient, authService: auth.AuthService) {
        super(http, authService);
    }

    findUsersBySearchPhrase(searchPhrase: string): Promise<appModels.UserDto[]>
    {
        let url = `Users/${searchPhrase}/Find`;
        return super.get(url, true);
    }
}