import models = require('../models/user-models');
import app = require('../../../data-service');
import data = require('../../../data');
import auth = require('../../../auth-service');
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';


export interface IUserService
{
    register(userRegisterDto: models.UserRegisterModel): Promise<data.IResult>;
    login(userLoginDto: models.UserLoginModel): Promise<string>;
    getUserSelfInfo(): Promise<auth.IUser>;
    logout(): Promise<data.IResult>;
    sendPasswordResetEmail(userEmail: string): Promise<data.IResult>;
    resetUserPassword(userPasswordResetDto: models.UserPasswordResetModel): Promise<data.IResult>;
    findUsersBySearchPhrase(searchPhrase: string): Promise<models.UserModel[]> ;
}

@inject(HttpClient, auth.AuthService)
export class UserService extends app.DataService implements IUserService 
{
    constructor(http: HttpClient, authService: auth.AuthService)
    {
        super(http, authService);
    }

    register(userRegisterDto: models.UserRegisterModel): Promise<data.IResult>
    {
        return super.post('Accounts/Register', userRegisterDto, false);
    }

    login(userLoginDto: models.UserLoginModel): Promise<string>
    {
        return super.post('Accounts/Login', userLoginDto, false);
    }

    getUserSelfInfo() : Promise<auth.IUser>
    {
        return super.get('Accounts/SelfInfo', true);
    }

    logout(): Promise<data.IResult>
    {
        return super.post('Accounts/SignOut', null, true);
    }

    sendPasswordResetEmail(userEmail: string): Promise<data.IResult>
    {
        const url = `Accounts/Password/Reset/${userEmail}/Email/Send`;
        return super.post(url, null, false);
    }

    resetUserPassword(userPasswordResetDto: models.UserPasswordResetModel): Promise<data.IResult> {
        return super.post('Accounts/Password/Reset', userPasswordResetDto, false);
    }

    findUsersBySearchPhrase(searchPhrase: string): Promise<models.UserModel[]> {
        let url = `Users/${searchPhrase}/Find`;
        return super.get(url, true);
    }
}