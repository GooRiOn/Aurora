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

export enum SprintState
{
    Past = 1,
    Currnet = 2,
    Future = 3
}

export class SprintModel
{
    id: number;
    projectId: number;
    name: string;
    estimatedStartDate: Date;
    estimatedEndDate: Date;
    state: SprintState;
}