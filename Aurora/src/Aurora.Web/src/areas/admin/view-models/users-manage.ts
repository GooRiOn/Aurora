import models = require('../models/admin-models');
import services = require('../services/users-manage-service');
import data = require('../../../data');
import {inject} from 'aurelia-framework';


@inject(services.UsersManageService)
export class UsersManageViewModel
{
    usesManageService: services.IUsersManageService;
    users: models.UserDto[];
    pageNumber = 1;
    pageSize = 10;

    constructor(usesManageService: services.UsersManageService)
    {
        this.usesManageService = usesManageService;
    }

    activate()
    {
        this.getUsers();
    }

    getUsers()
    {
        this.usesManageService.getUsers(this.pageNumber, this.pageSize).then((result: data.IPagedResult<models.UserDto>) =>
        {
             this.users = result.content;
        });
    }

    changeUserLockout(user: models.UserDto)
    {
        let promise = this.usesManageService.lockUser(user.id);
        if (user.isLocked)
            promise = this.usesManageService.unlockUser(user.id);


        promise.then((result: data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
                user.isLocked = !user.isLocked;
            else
                Materialize.toast('An error has occured',4000,'red');
        });
    }

    unlockUser(user: models.UserDto) {
        this.usesManageService.unlockUser(user.id).then((result: data.IResult) => {
            if (result.state === data.ResultStateEnum.Succeed)
                user.isLocked = false;
            else
                Materialize.toast('An error has occured', 4000, 'red');
        });
    }

    deleteUser(user: models.UserDto)
    {
        var self = this;

        var confirm = window.confirm('Do ypu want to delete user permanently?');

        if (!confirm)
            return;

        self.usesManageService.deleteUser(user.id).then((result: data.IResult) => {
            if (result.state === data.ResultStateEnum.Succeed)
                self.users.remove(user);
            else
                Materialize.toast('An error has occured', 4000, 'red');
        });
    }

    resetUserPassword(user: models.UserDto)
    {
        var newPassword = prompt("Enter new password");

        if (!newPassword)
            return;

        this.usesManageService.resetUserPassword(user.id, newPassword).then((result: data.IResult) =>
        {
            Materialize.toast('Password changed', 4000, 'green');
        });
    }
}