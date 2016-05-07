import userModels = require('../../user/models/user-models');

export enum SprintState {
    Past = 1,
    Currnet = 2,
    Future = 3
}

export enum BacklogItemState
{
    New = 1,
    Approved = 2,
    Commited = 3,
    Done = 4,
    Removed = 5
}

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



export class SprintModel
{
    id: number;
    projectId: number;
    name: string;
    estimatedStartDate: Date;
    estimatedEndDate: Date;
    state: SprintState;
}

export class ProjectBacklogItemModel
{
    id: number;
    sprintId: number;
    sprintName: string;
    title: string;
    state: BacklogItemState;
}

