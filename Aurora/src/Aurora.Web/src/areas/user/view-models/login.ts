import auth = require("../../../auth-service")
import userServices = require("../services/user-service");
import models = require("../models/user-models");
import data = require("../../../data");
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(userServices.UserService, auth.AuthService, Router)
export class LoginViewModel
{

    userService: userServices.IUserService;
    authService: auth.IAuthService

    userLoginDto: models.UserLoginDto;

    constructor(userService: userServices.UserService, authService: auth.AuthService, private router: Router)
    {
        this.userService = userService;
        this.authService = authService;
        this.userLoginDto = new models.UserLoginDto();
    }

    login()
    {
        this.userService.login(this.userLoginDto).then((result: data.IContentResult<string>) => {

            if (result.state === data.ResultStateEnum.Succeed)
            {
                let token = result.content;

                this.authService.setAccessToken(token, !this.userLoginDto.rememberMe);

                this.getUserSelfInfo().then(() =>
                {
                    Materialize.toast(`welcome ${this.authService.user.userName}`, 4000, 'btn');
                    this.router.navigate('#/');
                });
            }
            else
            {
                for (let error of result.errors)
                    Materialize.toast(error, 4000, 'btn orange');
            }
        });
    }

    getUserSelfInfo()
    {
        return this.userService.getUserSelfInfo().then((result: data.IContentResult<auth.IUser>) =>
        {
            let user: auth.IUser = { userName: result.content.userName, roles: result.content.roles };
            this.authService.setUser(user);
        });
    }

    changeRememberMeState()
    {
        this.userLoginDto.rememberMe = !this.userLoginDto.rememberMe;
        Materialize.toast(this.userLoginDto.rememberMe.toString(),4000);
    }
}