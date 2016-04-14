import services = require('../services/project-join-service');
import data = require('../../../data');
import {inject} from 'aurelia-framework';

@inject(services.ProjectJoinService)
export class ProjectJoinViewModel
{
    private joinProjectService: services.IProjectJoinService;

    isProjectJoinSucceed = false;

    constructor(joinProjectService: services.ProjectJoinService)
    {
        this.joinProjectService = joinProjectService;
    }

    activate(params: any)
    {
        let memberToken = params.memberToken;
        this.joinProject(memberToken);
    }

    joinProject(memberToken: string)
    {
        this.joinProjectService.joinProject(memberToken).then((result: data.IResult) =>
        {
            if (result.state === data.ResultStateEnum.Succeed)
                this.isProjectJoinSucceed = true;
        });
    }
}