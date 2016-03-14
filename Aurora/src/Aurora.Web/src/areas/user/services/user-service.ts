import Data = require("../../../data-service");
import Auth = require("../../../auth-service");
import UserModels = require("../models/user-models");
import {HttpClient} from "aurelia-fetch-client";
import {inject} from 'aurelia-framework';


export interface IUserService
{
    register(registerModel: UserModels.UserRegisterModel) : Promise<any>
}

@inject(HttpClient, Auth.AuthService)
export class UserService extends Data.DataService implements IUserService 
{
    constructor(http: HttpClient, authService: Auth.AuthService)
    {
        super(http, authService);
    }

    register(registerModel: UserModels.UserRegisterModel): Promise<any>
    {
        return super.post('accounts/register', registerModel, false);
    }
}