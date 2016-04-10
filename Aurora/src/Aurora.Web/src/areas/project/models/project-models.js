define(["require", "exports"], function (require, exports) {
    "use strict";
    var UserDto = (function () {
        function UserDto() {
        }
        return UserDto;
    }());
    exports.UserDto = UserDto;
    var ProjectCreateDto = (function () {
        function ProjectCreateDto() {
            this.members = [];
        }
        return ProjectCreateDto;
    }());
    exports.ProjectCreateDto = ProjectCreateDto;
});
//# sourceMappingURL=project-models.js.map