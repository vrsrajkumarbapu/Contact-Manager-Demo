
//Root Controller
window.app = angular.module('contactDetailApp', ['ngRoute', 'ngResource', 'ngCookies']);
debugger;
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/demo', { templateUrl: '/home/demo', controller: 'DemoController' })
        .when('/profile', { templateUrl: '/home/profile', controller: 'ProfileController' })
    .otherwise({ redirectTo: '/demo' });
}])
.controller('RootController', ['$scope', '$route', '$routeParams', '$location', function ($scope, $route, $routeParams, $location) {
    $scope.$on('$routeChangeSuccess', function (e, current, previous) {
        $scope.activeViewPath = $location.path();

    });
}]);


app.controller('DemoController', function ($scope, dataService) {
    $scope.contactdetaildata = [];
    clearText();
    loadRecords();


    function loadRecords() {
        var contactdetaildata = dataService.get();
        contactdetaildata.then(function (pdata) {
            $scope.contactdetaildata = pdata.data;
        },
        function (error) {
            alert('error');
        });
    };
    $scope.delete = function (data) {
        if (confirm('Are you Sure?')) {
            var deleteContactdetail = dataService.delete(data);
            deleteContactdetail.then(function (pd) {
                loadRecords();
                alert('Data Deleted Successfully');
            }, function (error) {
                alert('An error Occured');
            });
        }
    };
    $scope.select = function (data) {
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
    //ID
    //FirstName
    //LastName
    //Email
    //Born
    //Cellphone
    //IsActive
    function clearText() {
        //var contactdetail = {};
        //newPerson.ID = 0;
        //newPerson.FirstName = "";
        //newPerson.LastName = "";
        //newPerson.Born = "";
        //newPerson.Cellphone = "";
        //newPerson.Email = "";
        //newPerson.IsActive = false;
        debugger;
        $scope.contactdetail = { ID: 0, FirstName: '', LastName: '', Email: '', Born: '', Cellphone: '', IsActive: false };

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
    }
    this.put = function (contactdetail) {
        var request = $http({
            method: 'put',
            url: baseUrl,
            data: contactdetail
        });
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


app.directive('serverValidate', ['$http', function ($http) {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, ele, attrs, c) {
            //console.log('wiring up ' + attrs.ngModel + ' to controller ' + c.$name);
            scope.$watch('modelState', function () {
                if (scope.modelState == null) return;
                var modelStateKey = attrs.serverValidate || attrs.ngModel;
                modelStateKey = modelStateKey.replace('$index', scope.$index);
                //console.log('validation for ' + modelStateKey);
                modelStateKey.indexOf(".");
                //modelStateKey = 'entity.' + modelStateKey.substring(modelStateKey.indexOf(".") + 1, modelStateKey.length);
                modelStateKey = modelStateKey.substring(modelStateKey.indexOf(".") + 1, modelStateKey.length);
                var statemodel;
                var errormodel = null;
                for (var i = 0; i < scope.modelState.length; i++) {

                    if (scope.modelState[i].PropertyName == modelStateKey) {
                        errormodel = scope.modelState[i];
                        break;
                    }
                }
                c.$setValidity('server', true);
                if (errormodel != null) {
                    c.$setValidity('server', false);
                    c.$error.server = { "errorMessage": errormodel.ErrorMessage };

                } else {
                    c.$setValidity('server', true);
                }


                ele.bind('focus', function (evt) {
                    c.$setValidity('server', true);
                }).bind('blur', function (evt) {
                    c.$setValidity('server', true);
                });
            });

            scope.$watch(attrs.ngModel, function (oldValue, newValue) {

                if (oldValue != newValue) {
                    c.$setValidity('server', true);
                    c.$error.server = '';
                }
            });
        }
    };
}]);
