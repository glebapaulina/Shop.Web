//offerBooks.controller.js
(function () {

    "use strict";
    angular.module("app")
        .controller("offerBooksController", offerBooksController);
    offerBooksController.$inject = ['$http'];

    function offerBooksController($http) {
        var vm = this;
        var books = [];
        vm.books = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("api/books")
            .then(function(response) {
                    books = response.data;
                    for (var i = 0; i < books.length; i++) {
                        var book = books[i];
                        if (book.isOffer) {
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
