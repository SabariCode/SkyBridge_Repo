angular.module("MyApp")
    .controller("LoginController", function ($scope, LoginService) {
        $scope.IsLoggedIn = false;
        $scope.Message = '';
        $scope.Submitted = false;
        $scope.IsFormValid = false;

        $scope.LoginData = {
            Username: '',
            Password: ''
        };
        $scope.$watch('lf.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });
        $scope.Login = function () {
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                LoginService.GetUser($scope.LoginData).then(function (d) {
                    if (d.data.UserName != null) {
                        $scope.IsLoggedIn = true;
                        $scope.Message = "Welcome" + "  " + d.data.FullName;
                    }
                    else {
                        alert("Invalid credentials");
                    }
                });
            }
        };
    })

    .factory('LoginService', function ($http) {
        var log = {};
        log.GetUser = function (d) {
            return $http({
                url: '/Data/UserLogin',
                method: 'POST',
                data: JSON.stringify(d),
                headers: { 'content-type': 'application/json' }
            });
        };
        return log;
    });