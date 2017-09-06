//cancelSearch.directive.js
(function () {
    "use strict";

    angular.module("app")
        .directive("cancelSearch", cancelSearch);

    function cancelSearch() {
        return {
            restrict: 'E',
            templateUrl: 'views/Directives/cancelSearch.html',
            scope: {
                results: "="
            },
            controller: function($scope, $rootScope) {
                $scope.cancel = function() {
                    $rootScope.global.query = "";
                };

            }
        };
    }
})();