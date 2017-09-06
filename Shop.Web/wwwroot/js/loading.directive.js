//loading.directive.js
(function () {
    "use strict";

    angular.module("loading", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "E",
            templateUrl: "/views/Directives/waitCursor.html"
        };
    }

})();