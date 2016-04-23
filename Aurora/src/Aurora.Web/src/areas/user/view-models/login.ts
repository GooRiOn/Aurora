import auth = require('../../../auth-service')
import userServices = require('../services/user-service');
import models = require('../models/user-models');
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(userServices.UserService, auth.AuthService, Router)
export class LoginViewModel
{
    userService: userServices.IUserService;
    authService: auth.IAuthService;

    userLoginDto: models.UserLoginModel;

    constructor(userService: userServices.UserService, authService: auth.AuthService, private router: Router)
    {
        this.userService = userService;
        this.authService = authService;
        this.userLoginDto = new models.UserLoginModel();
    }

    login()
    {
        this.userService.login(this.userLoginDto).then((result:string) => {

            this.authService.setAccessToken(result, this.userLoginDto.rememberMe);

            this.getUserSelfInfo().then(() =>
            {
                Materialize.toast(`welcome ${this.authService.user.userName}`, 4000, 'btn');
                this.router.navigate('#/project/dashboard');
            });
        });
    }

    getUserSelfInfo()
    {
        return this.userService.getUserSelfInfo().then((result: auth.IUser) =>
        {
            let user: auth.IUser = { userName: result.userName, roles: result.roles, projects: result.projects };
            this.authService.setUser(user);
        });
    }
}