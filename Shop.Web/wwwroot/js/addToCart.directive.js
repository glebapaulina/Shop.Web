//addToCart.controller.js
(function () {
    "use strict";

    angular.module("app")
        .directive("addToCart", addToCart);

    function addToCart() {
        return {
            restrict: 'E',
            templateUrl: 'views/Directives/addToCart.html',
            scope: {
                book: "="

            },
            controller: function($scope, $http, $window) {

                $scope.storages = [];
                $scope.newCartItem = {};
                $scope.cartItems = [];
                $scope.getStorages = $http.get("api/storages")
                    .then(function(response) {
                        $scope.storages = response.data;
                    });
                $scope.newCartItem.bookTitle = $scope.book.title;
                $scope.newCartItem.bookBookId = $scope.book.bookId;
                $scope.addItemToCart = function() {
                    $http.post("/api/cart", $scope.newCartItem)
                            .then(function(response) {
                                $scope.cartItems.push(response.data);
                                console.log($scope.newCartItem);
                            })
                        .catch(function(err) {
                            console.log(err);                           
                        })
                        .finally (function() {
                                $window.location.reload();
                            });
                };
            }
        };
    }
})();