//allBooks.controller.js
(function() {

    "use strict";
    angular.module("app")
        .controller("allBooksController", allBooksController);
    allBooksController.$inject = ['$http'];

    function allBooksController($http) {
        var vm = this;
        vm.books = [];
        vm.errorMessage = "";
        vm.infoMessage = "";
        vm.isBusy = true;
        $http.get("api/books")
            .then(function(response) {
                    vm.books = response.data;
                    if (angular.equals(vm.books.length, 0)) {
                        vm.infoMessage = "Nie ma żadnych książek";
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
