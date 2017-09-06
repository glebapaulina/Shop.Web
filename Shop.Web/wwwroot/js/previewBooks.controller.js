//previewBooks.controller.js
(function () {

    "use strict";
    angular.module("app")
        .controller("previewBooksController", previewBooksController);
    previewBooksController.$inject = ['$http'];

    function previewBooksController($http) {
        var vm = this;
        vm.books = [];
        var books = [];
        var today = new Date();
        vm.errorMessage = "";
        vm.infoMessage = "";
        vm.isBusy = true;

        $http.get("api/books")
            .then(function(response) {
                    books = response.data;
                    if (books.length > 0) {
                        vm.isBusy = false;
                    }

                    function addDays(date, days) {
                        var result = new Date(date);
                        result.setDate(date.getDate() + days);
                        return result;
                    }

                    for (var i = 0; i < books.length; i++) {
                        var book = books[i];
                        var releaseDate = new Date(book.releaseDate);
                        if (releaseDate > today && releaseDate <= addDays(today, 14)) {
                            vm.books.push(book);
                        }
                    }
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
