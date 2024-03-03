console.log('Defining myApp module...');
angular.module('myApp', []);

angular.module('myApp').controller('DashboardController', ['$scope', '$http', function ($scope, $http) {

    $scope.getCheckboxValues = function () {

        console.log("Dash");
        var checkboxValues = ''; 
        var checkboxes = document.querySelectorAll('input[type="checkbox"]'); 

        checkboxes.forEach(function (checkbox) {
            if (checkbox.checked) { 
                checkboxValues += checkbox.value + ','; 
            }
        });

        // Remove the trailing comma
        checkboxValues = checkboxValues.slice(0, -1);

        console.log("Checkbox values: " + checkboxValues);
    };
}]);


