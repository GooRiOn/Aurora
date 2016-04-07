import appModels = require('../../../models');

export class UserDto {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    isLocked: boolean;
}

export class ProjectCreateDto
{
    name: string;
    description: string;
    members: appModels.UserDto[];

    constructor()
    {
        this.members = [];
    }
}