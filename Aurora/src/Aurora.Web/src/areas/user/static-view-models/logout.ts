import auth = require('../../../auth-service')
import userServices = require('../services/user-service');
import data = require('../../../data');
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';


@inject(auth.AuthService, userServices.UserService, Router)
export class LogoutStaticViewModel
{
    authService: auth.IAuthService;
    userService: userServices.IUserService;
    
    constructor(authService: auth.AuthService, userService: userServices.UserService, private router: Router)
    {
        this.authService = authService;
        this.userService = userService;
    }

    logout()
    {
        this.userService.logout().then((result: data.IResult) =>
        {
            this.authService.clearAccessToken();
            this.authService.setUser(null);
            this.router.navigate('#/');
        });
    }
}