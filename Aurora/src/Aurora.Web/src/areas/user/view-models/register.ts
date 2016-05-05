import userServices = require('../services/user-service');
import models = require('../models/user-models');
import data = require('../../../data');
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(userServices.UserService, Router)
export class RegisterViewModel
{
    userService: userServices.IUserService;
    userRegisterDto: models.UserRegisterModel;

    constructor(userService: userServices.UserService, private router: Router)
    {
        this.userService = userService;
        this.userRegisterDto = new models.UserRegisterModel();
    }

    register()
    { 
        if (this.userRegisterDto.password !== this.userRegisterDto.confirmPassword)
        {
            Materialize.toast('Password and confirm password dont match', 4000, 'btn orange');
            return;
        }

        this.userService.register(this.userRegisterDto).then((result :data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
            {
                this.router.navigate('#/user/login');
                Materialize.toast('Registration completed. Login now !', 4000, 'btn');
            }
            else
            {
                for (let error of result.errors)
                    Materialize.toast(error, 4000, 'btn orange');
            }
                
        });
    }
}