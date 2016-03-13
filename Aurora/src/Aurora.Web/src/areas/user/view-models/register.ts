import {inject} from 'aurelia-framework';
import UserServices = require("../services/user-service");
import UserModels = require("../models/user-models");


@inject(UserServices.UserService)
export class RegisterViewModel
{
    userService: UserServices.IUserService;
    userRegisterModel: UserModels.UserRegisterModel;

    constructor(userService: UserServices.UserService)
    {
        this.userService = userService;
        this.userRegisterModel = new UserModels.UserRegisterModel();
    }

    register()
    {
        this.userService.register(this.userRegisterModel).then(response =>
        {
            var test = response;
        });
    }
}