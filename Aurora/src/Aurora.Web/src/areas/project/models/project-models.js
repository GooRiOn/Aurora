define(["require", "exports"], function (require, exports) {
    "use strict";
    (function (SprintState) {
        SprintState[SprintState["Past"] = 1] = "Past";
        SprintState[SprintState["Currnet"] = 2] = "Currnet";
        SprintState[SprintState["Future"] = 3] = "Future";
    })(exports.SprintState || (exports.SprintState = {}));
    var SprintState = exports.SprintState;
    (function (BacklogItemState) {
        BacklogItemState[BacklogItemState["New"] = 1] = "New";
        BacklogItemState[BacklogItemState["Approved"] = 2] = "Approved";
        BacklogItemState[BacklogItemState["Commited"] = 3] = "Commited";
        BacklogItemState[BacklogItemState["Done"] = 4] = "Done";
        BacklogItemState[BacklogItemState["Removed"] = 5] = "Removed";
    })(exports.BacklogItemState || (exports.BacklogItemState = {}));
    var BacklogItemState = exports.BacklogItemState;
    var ProjectCreateModel = (function () {
        function ProjectCreateModel() {
            this.members = [];
        }
        return ProjectCreateModel;
    }());
    exports.ProjectCreateModel = ProjectCreateModel;
    var SprintModel = (function () {
        function SprintModel() {
        }
        return SprintModel;
    }());
    exports.SprintModel = SprintModel;
    var ProjectBacklogItemModel = (function () {
        function ProjectBacklogItemModel() {
        }
        return ProjectBacklogItemModel;
    }());
    exports.ProjectBacklogItemModel = ProjectBacklogItemModel;
});
//# sourceMappingURL=project-models.js.map