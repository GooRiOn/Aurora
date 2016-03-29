import userServices = require("../services/user-service");
import data = require("../../../data");
import models = require('../models/user-models');
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(userServices.UserService, Router)
export class PasswordResetViewModel
{
    userService: userServices.IUserService;
    userEmail: string;
    
    userResetPasswordDto: models.UserPasswordResetDto;

    constructor(userService: userServices.UserService, private router : Router)
    {
        this.userService = userService;
    }

    activate(params: any)
    {
        this.userResetPasswordDto = params;
    }

    sendPasswordResetEmail()
    {
        this.userService.sendPasswordResetEmail(this.userEmail).then((result: data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
                Materialize.toast('An email has been sent to you', 4000, 'btn');
        });
    }

    resetUserPassword()
    {
        this.userService.resetUserPassword(this.userResetPasswordDto).then((result: data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
            {
                this.router.navigate('#/user/login');
                Materialize.toast('Operation succeed. Login now !', 4000, 'btn');
            } else
            {
                for (let error of result.errors)
                    Materialize.toast(error, 4000, 'btn orange');
            }
        });
    }
}