angular.module("MyApp")
    //Login controller creation
    .controller("LoginController", function ($scope, LoginService) {
        $scope.IsLoggedIn = false;
        $scope.Message = '';
        $scope.Submitted = false;
        $scope.IsFormValid = false;

        $scope.LoginData = {
            Username: '',
            Password: ''
        };
        //To check if form is valid or not
        $scope.$watch('lf.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });
        //Function to be called when login button  is clicked
        $scope.Login = function () {
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                //GetUser function of factory method
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
    //factory method to  get data from controller
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