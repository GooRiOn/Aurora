import models = require('../models/project-models');
import services = require('../services/project-backlog-service');
import sprintServices = require('../services/project-sprints-service')
import data = require('../../../data');
import materialize = require('../../../materialize-helper');
import auth = require('../../../auth-service')
import {inject} from 'aurelia-framework';

@inject(services.ProjectBacklogService, sprintServices.ProjectSprintsService, auth.AuthService)
export class ProjectSprintsViewModel {

    userDefaultProject: auth.IUserProject;

    activeBacklogItem: models.ProjectBacklogItemModel;
    backlogItems: models.ProjectBacklogItemModel[];   
    
    backlogItemStates = [
        {name: "New", value: models.BacklogItemState.New},
        {name: "Approved", value: models.BacklogItemState.Approved},
        {name: "Commited", value: models.BacklogItemState.Commited},
        {name: "Done", value: models.BacklogItemState.Done},
        {name: "Removed", value: models.BacklogItemState.Removed},       
    ];
    
    isActiveBacklogItemViewEnabled: boolean;
    
    sprints: models.SprintModel[];

    private projectBacklogService: services.IProjectBacklogService;
    private sprintService: sprintServices.IProjectSpintsService;
    private authService: auth.IAuthService;

    constructor(projectBacklogService: services.ProjectBacklogService, sprintService: sprintServices.ProjectSprintsService,
     authService: auth.AuthService) {
         
        this.projectBacklogService = projectBacklogService;
        this.sprintService = sprintService;
        this.authService = authService;
    }

    attached()
    {     
        materialize.MaterializeHelper.initializeDropdown('select');
    }

    activate() {
        this.userDefaultProject = this.authService.getUserDefaultProject();

        if (!this.userDefaultProject.id)
            return;

        this.getProjectBacklogItems();
        this.getProjectSprints();
    }
    
    getProjectBacklogItems()
    {
        this.projectBacklogService.getProjectacklogItems(this.userDefaultProject.id).then((result: models.ProjectBacklogItemModel[]) => {
            this.backlogItems = result; 
        });
    }
    
    getProjectSprints()
    {           
        this.sprintService.getProjectSprints(this.userDefaultProject.id).then((result: models.SprintModel[]) => {
            this.sprints = result;
        });
    }

    createBacklogItem()
    {
        this.projectBacklogService.createBacklogItem(this.activeBacklogItem).then((result: data.IResult) =>
        {
            this.clearActiveBacklogItemView();           
            Materialize.toast('Backlog item has been created', 4000, 'btn');
        });
    }

    updateBacklogItem() {
        this.projectBacklogService.updateBacklogItem(this.activeBacklogItem).then((result: data.IResult) => {
            this.clearActiveBacklogItemView();
            Materialize.toast('Backlog item has been updated', 4000, 'btn');
        });
    }

    deleteBacklogItem(backlogItem: models.ProjectBacklogItemModel) {

        let confitm = window.confirm('Do you want to remove this backlog item?');

        if (!confirm)
            return;

        this.projectBacklogService.deleteBacklogItem(backlogItem.id).then((result: data.IResult) => {
            this.backlogItems.remove(backlogItem);
            Materialize.toast('Backlog item has been deleted', 4000, 'btn');
        });
    }
    
    activateNewBacklogItemCreation()
    {
        this.activeBacklogItem = new models.ProjectBacklogItemModel();
        this.isActiveBacklogItemViewEnabled = true;       
    }

    activateBacklogItemEdition(backlogItem: models.ProjectBacklogItemModel)
    {
        this.activeBacklogItem = backlogItem;
        this.isActiveBacklogItemViewEnabled = true;
    }

    clearActiveBacklogItemView()
    {
        this.activeBacklogItem = null;
        this.isActiveBacklogItemViewEnabled = false;
        this.getProjectBacklogItems();
    }
    
    getBacklogItemStateByValue(value: number)
    {
        let state = this.backlogItemStates.firstOrNull(i => i.value === value);        
        return state? state.name : '';
    }
}