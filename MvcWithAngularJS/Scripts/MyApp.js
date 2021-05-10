(function () {
    //module creation
    var app = angular.module("MyApp", ['ngRoute']);
    //controller creation
    app.controller('HomeController', function ($scope) {
        $scope.Message = "Welcome to the World";
    });
})();