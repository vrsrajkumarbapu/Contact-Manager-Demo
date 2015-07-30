var webAPIURL = "http://localhost:63008";
var headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': ['GET', 'POST', 'OPTIONS', 'PUT', 'DELETE'],
    'Access-Control-Allow-Headers': 'true',
    'Access-Control-Allow-Credendtials': 'true',
    'Content-Type': 'application/json;charset=utf-8'
};
window.app = angular.module('contactDetailApp', ['ngRoute', 'ngResource', 'ngCookies']);
debugger;
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/demo', { templateUrl: '/home/demo', controller: 'DemoController' })
}]);
app.directive('numeric', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {

            function inputValue(val) {
                if (val) {
                    var digits = val.replace(/[^0-9]/g, '');

                    if (digits !== val) {
                        ctrl.$setViewValue(digits);
                        ctrl.$render();
                    }
                    return parseInt(digits, 10);
                }
                else if (val.trim() == '')
                    return true;
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    };
});
app.controller('DemoController', function ($scope, dataService) {
    $scope.show = true;
    loadRecords();


    function loadRecords() {
        var contactdetaildata = dataService.get();
        contactdetaildata.then(function (pdata) {

            $scope.contactdetaildata = pdata.data;
            
            $scope.show = true;
        },
        function (error) {
            alert('error');
        });
    };
    $scope.delete = function (data) {
        if (confirm('Are you Sure?')) {
            var deleteContactdetail = dataService.delete(data);
            deleteContactdetail.then(function (pd) {
                alert('Data Deleted Successfully');
                clearText();
                loadRecords();
                
            }, function (error) {
                alert('An error Occured');
            });
        }
    };
    
    $scope.cancel = function () {
        $scope.show = true;
        
    };
    $scope.select = function (data) {
        debugger;
        $scope.show = false;
        $scope.contactdetail = angular.copy(data);     
        $scope.contactdetail.Born = new Date($scope.contactdetail.Born);
    };
    function getDateFormat(date)
    {
        return new Date(date.getFullYear(), date.getMonth(), date.getDay())
    }
    $scope.save = function () {
        debugger;
        if ($scope.contactdetail.FirstName != "") {
            debugger;
            $scope.contactdetail.Born = getDateFormat($scope.contactdetail.Born);
            var saveData = $scope.contactdetail;
            if (saveData.ID > 0) {
                var updateContactdetail = dataService.put(saveData);
                updateContactdetail.then(function (prmData) {
                    alert('Data updated');
                    debugger;
                    loadRecords();
                    clearText();
                }, function (error) {
                    debugger;
                    alert('An error occured');
                });
            }
            else {
                var saveContactdetail = dataService.post(saveData);
                saveContactdetail.then(function (pdata) {
                    loadRecords();
                    clearText();
                    debugger;
                }, function (error) {
                    debugger;
                });
                debugger;
           
            }
        }
    };
    $scope.clear = function () {
        clearText();
    }
  
    function clearText() {
       
        $scope.contactdetail = { ID: 0, FirstName: '', LastName: '', Email: '', Born: '', Cellphone: '', IsActive: false };
        $scope.show = false;
    }
});
var app=
angular.module('contactDetailApp').service('dataService', ['$http', function ($http) {
    var baseUrl = webAPIURL+"/api/contacts/";
    this.post = function (contactdetail) {
        var request = $http({
            method: 'post',
            url: baseUrl,
            data: contactdetail
        });
        return request;
    }
    this.put = function (contactdetail) {
        var request = $http({
            method: 'put',
            url: baseUrl,
            data: contactdetail
        });
        return request;
    }
    this.delete = function (contactdetail) {
        var request = $http({
            method: 'delete',
            url: baseUrl + contactdetail.ID
        });
        return request;
    }
    this.get = function () {
        return $http.get(baseUrl);
    }
}]);


