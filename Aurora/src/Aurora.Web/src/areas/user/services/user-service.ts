﻿import models = require("../models/user-models");
import app = require("../../../data-service");
import data = require("../../../data");
import auth = require("../../../auth-service");
import {HttpClient} from "aurelia-fetch-client";
import {inject} from 'aurelia-framework';


export interface IUserService
{
    register(userRegisterDto: models.UserRegisterDto): Promise<data.IResult>;
    login(userLoginDto: models.UserLoginDto): Promise<data.IContentResult<string>>;
    getUserSelfInfo(): Promise<data.IContentResult<auth.IUser>>;
    logout(): Promise<data.IResult>;
}

@inject(HttpClient, auth.AuthService)
export class UserService extends app.DataService implements IUserService 
{
    constructor(http: HttpClient, authService: auth.AuthService)
    {
        super(http, authService);
    }

    register(userRegisterDto: models.UserRegisterDto): Promise<data.IResult>
    {
        return super.post('Accounts/Register', userRegisterDto, false);
    }

    login(userLoginDto: models.UserLoginDto): Promise<data.IContentResult<string>>
    {
        return super.post('Accounts/Login', userLoginDto, false);
    }

    getUserSelfInfo() : Promise<data.IContentResult<auth.IUser>>
    {
        return super.get('Accounts/SelfInfo', true);
    }

    logout(): Promise<data.IResult>
    {
        return super.post('Accounts/SignOut', null, true);
    }
}