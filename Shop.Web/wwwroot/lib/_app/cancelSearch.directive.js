!function(){"use strict";function e(){return{restrict:"E",templateUrl:"views/Directives/cancelSearch.html",scope:{results:"="},controller:["$scope","$rootScope",function(e,c){e.cancel=function(){c.global.query=""}}]}}angular.module("app").directive("cancelSearch",e)}();