import services = require('../services/project-join-service');
import data = require('../../../data');
import {inject} from 'aurelia-framework';

@inject(services.ProjectJoinService)
export class JoinProjectViewModel
{
    private joinProjectService: services.IProjectJoinService;

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
                Materialize.toast('WORKS!', 4000, 'btn');
        });
    }
}