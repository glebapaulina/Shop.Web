//newBooks.controller.js
(function () {

    "use strict";
    angular.module("app")
        .controller("newBooksController", newBooksController);
    newBooksController.$inject = ['$http'];

    function newBooksController($http) {
        var vm = this;
        var books = [];
        vm.books = [];
        vm.errorMessage = "";
        vm.infoMessage = "";
        vm.isBusy = true;
        var today = new Date();

        $http.get("api/books")
            .then(function(response) {
                    books = response.data;

                    function addDays(date, days) {
                        var result = new Date(date);
                        result.setDate(date.getDate() + days);
                        return result;
                    }

                    for (var i = 0; i < books.length; i++) {
                        var book = books[i];
                        var releaseDate = new Date(book.releaseDate);

                        if (releaseDate < today && releaseDate >= addDays(today, -14)) {
                            vm.books.push(book);
                        }
                    }
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
