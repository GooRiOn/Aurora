define(["require", "exports"], function (require, exports) {
    "use strict";
    var ProjectCreateModel = (function () {
        function ProjectCreateModel() {
            this.members = [];
        }
        return ProjectCreateModel;
    }());
    exports.ProjectCreateModel = ProjectCreateModel;
    (function (SprintState) {
        SprintState[SprintState["Past"] = 1] = "Past";
        SprintState[SprintState["Currnet"] = 2] = "Currnet";
        SprintState[SprintState["Future"] = 3] = "Future";
    })(exports.SprintState || (exports.SprintState = {}));
    var SprintState = exports.SprintState;
    var SprintModel = (function () {
        function SprintModel() {
        }
        return SprintModel;
    }());
    exports.SprintModel = SprintModel;
});
//# sourceMappingURL=project-models.js.map