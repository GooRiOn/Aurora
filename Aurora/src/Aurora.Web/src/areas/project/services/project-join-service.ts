import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface IProjectJoinService {
    joinProject(memberToken: string): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class ProjectJoinService extends app.DataService implements IProjectJoinService {

    constructor(http: HttpClient, authService: auth.AuthService) {
        super(http, authService);
    }

    joinProject(memberToken: string): Promise<data.IResult>
    {
        let url = `Projects/${memberToken}/Join`;
        return super.post(url, null, true);
    }
}