//audiobooks.controller.js
(function() {

    "use strict";
    angular.module("app")
        .controller("audiobooksController", audiobooksController);
    audiobooksController.$inject = ['$http'];

    function audiobooksController($http) {
        var vm = this;
        vm.books = [];
        vm.errorMessage = "";
        vm.infoMessage = "";
        vm.isBusy = true;

        $http.get("api/type/1/books")
            .then(function(response) {
                    vm.books = response.data;
                    if (angular.equals(vm.books.length, 0)) {
                        vm.infoMessage = "Nie ma żadnych książek w tym dziale";
                    }
                },
                function() {
                    vm.errorMessage = "Nie udało się załadować książek";
                })
            .finally(function() {
                vm.isBusy = false;
            });
    }
})();
