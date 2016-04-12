var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
define(["require", "exports"], function (require, exports) {
    "use strict";
    var UserLoginModel = (function () {
        function UserLoginModel() {
            this.rememberMe = true;
        }
        return UserLoginModel;
    }());
    exports.UserLoginModel = UserLoginModel;
    var UserRegisterModel = (function (_super) {
        __extends(UserRegisterModel, _super);
        function UserRegisterModel() {
            _super.apply(this, arguments);
        }
        return UserRegisterModel;
    }(UserLoginModel));
    exports.UserRegisterModel = UserRegisterModel;
    var UserPasswordResetModel = (function () {
        function UserPasswordResetModel() {
        }
        return UserPasswordResetModel;
    }());
    exports.UserPasswordResetModel = UserPasswordResetModel;
    var UserModel = (function () {
        function UserModel() {
        }
        return UserModel;
    }());
    exports.UserModel = UserModel;
});
//# sourceMappingURL=user-models.js.map