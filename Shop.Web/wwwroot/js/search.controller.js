//search.controller.js
(function () {

    "use strict";
    angular.module("app")
        .controller("searchController", searchController);
    searchController.$inject = ['$rootScope'];

    function searchController($rootScope) {
        $rootScope.global = {
            query: '',

            search: function(book) {
                if (angular.lowercase(book.title).indexOf(angular.lowercase($rootScope.global.query) || '') !== -1
                    || angular.lowercase(book.authorAuthorName).indexOf(angular.lowercase($rootScope.global.query) || '') !== -1)
                {
                    return true;
                }
                return false;
            }
        };
    } 
})();
