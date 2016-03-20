define(["require", "exports"], function (require, exports) {
    (function (ResultStateEnum) {
        ResultStateEnum[ResultStateEnum["Succeed"] = 1] = "Succeed";
        ResultStateEnum[ResultStateEnum["Failed"] = 2] = "Failed";
    })(exports.ResultStateEnum || (exports.ResultStateEnum = {}));
    var ResultStateEnum = exports.ResultStateEnum;
});
//# sourceMappingURL=data.js.map