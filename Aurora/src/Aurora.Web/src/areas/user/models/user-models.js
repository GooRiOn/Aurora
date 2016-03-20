var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
define(["require", "exports"], function (require, exports) {
    var UserLoginDto = (function () {
        function UserLoginDto() {
            this.rememberMe = true;
        }
        return UserLoginDto;
    })();
    exports.UserLoginDto = UserLoginDto;
    var UserRegisterDto = (function (_super) {
        __extends(UserRegisterDto, _super);
        function UserRegisterDto() {
            _super.apply(this, arguments);
        }
        return UserRegisterDto;
    })(UserLoginDto);
    exports.UserRegisterDto = UserRegisterDto;
});
//# sourceMappingURL=user-models.js.map