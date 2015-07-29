
//Root Controller
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
    //$scope.contactdetaildata = [];
    //clearText();
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
        //$scope.clear();
        $scope.show = true;
        
    };
    $scope.select = function (data) {
        $scope.show = false;
        $scope.contactdetail = data;
    };
    $scope.save = function () {
        debugger;
        var saveData = $scope.contactdetail;
        if (saveData.ID > 0) {
            var updateContactdetail = dataService.put(saveData);
            updateContactdetail.then(function (prmData) {
                alert('Data updated');
               
                loadRecords();
            }, function (error) {
                alert('An error occured');
            });
        }
        else {
            var saveContactdetail = dataService.post(saveData);
            saveContactdetail.then(function (pdata) {
                loadRecords();
            }, function (error) {
            });
            clearText();
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
    var baseUrl = "/api/contactdetail/";
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


