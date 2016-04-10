import userModels = require('../../user/models/user-models');
import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

export interface IUsersManageService
{
    getUsers(pageNumber: number, pageSize: number): Promise<data.IPagedResult<userModels.UserModel>>;
    lockUser(userId: string): Promise<data.IResult>;
    unlockUser(userId: string): Promise<data.IResult>;
    deleteUser(userId: string): Promise<data.IResult>;
    resetUserPassword(userId: string, newPassword: string): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class UsersManageService extends app.DataService implements IUsersManageService
{
    constructor(http: HttpClient, authService: auth.AuthService)
    {
        super(http, authService);
    }

    getUsers(pageNumber: number, pageSize: number): Promise<data.IPagedResult<userModels.UserModel>>
    {
        var url = `Admin/Users/${pageNumber}/Page/${pageSize}/Size`;
        return super.get(url, true);
    }

    lockUser(userId: string): Promise<data.IResult>
    {
        var url = `Admin/Users/${userId}/Lock`;
        return super.post(url, null, true);
    }

    unlockUser(userId: string): Promise<data.IResult>
    {
        var url = `Admin/Users/${userId}/Unlock`;
        return super.post(url, null, true);
    }

    deleteUser(userId: string): Promise<data.IResult>
    {
        var url = `Admin/Users/${userId}/Delete`;
        return super.post(url, null, true);
    }

    resetUserPassword(userId: string, newPassword: string): Promise<data.IResult>
    {
        var url = `Admin/Users/${userId}/Password/${newPassword}/Reset`;
        return super.post(url, null, true);
    }
}