import userModels = require('../../user/models/user-models');

export class ProjectCreateModel
{
    name: string;
    description: string;
    members: userModels.UserModel[];

    constructor()
    {
        this.members = [];
    }
}