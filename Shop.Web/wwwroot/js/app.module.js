//app.module.js
(function() {

    angular
        .module("app", ["loading", "ngRoute"])
        .config(function($routeProvider) {
            $routeProvider
                .when("/wszystkie",
                    {
                        controller: "allBooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/allBooksView.html"
                    })
                .when("/audiobooki",
                    {
                        controller: "audiobooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/audiobooksView.html"
                    })
                .when("/ebooki",
                    {
                        controller: "ebooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/ebooksView.html"
                    })
                .when("/nowosci",
                    {
                        controller: "newBooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/newBooksView.html"
                    })
                .when("/zapowiedzi",
                    {
                        controller: "previewBooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/previewBooksView.html"
                    })
                .when("/okazje",
                    {
                        controller: "offerBooksController",
                        controllerAs: "vm",
                        templateUrl: "/views/Navigation/offerBooksView.html"
                    })
                .otherwise({ redirectTo: "/wszystkie" });

        });
})();