//cart.directive.js
(function () {
    "use strict";

    angular.module("app")
        .directive("cart", cart);

    function cart() {
        return {
            restrict: 'E',
            templateUrl: 'views/Directives/cart.html',

            controller: function($http, $scope) {
                var cartItems = [];
                $http.get("api/cart")
                    .then(function(response) {
                        cartItems = response.data;
                        $scope.count = 0;
                        var countItems = function(i) {
                            $scope.count += cartItems[i].quantity;
                        };
                        for (var i = 0; i < cartItems.length; i++) {
                            countItems(i);
                        }
                        $scope.cartItems = cartItems;
                    });
            }
        };
    }
})();