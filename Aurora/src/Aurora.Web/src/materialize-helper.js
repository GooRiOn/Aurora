define(["require", "exports"], function (require, exports) {
    "use strict";
    var MaterializeHelper = (function () {
        function MaterializeHelper() {
        }
        MaterializeHelper.initializeDropdown = function (elemName) {
            $('').ready(function () {
                $(elemName).material_select();
            });
        };
        MaterializeHelper.initializeDatePicker = function (elemName) {
            $(elemName).pickadate({
                selectMonths: true,
                selectYears: 15
            });
        };
        return MaterializeHelper;
    }());
    exports.MaterializeHelper = MaterializeHelper;
});
//# sourceMappingURL=materialize-helper.js.map