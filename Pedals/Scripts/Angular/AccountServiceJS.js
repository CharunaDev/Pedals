console.log('Defining myApp module...');
angular.module('myApp', []);

angular.module('myApp').controller('AccountControlleree', ['$scope', '$http', function ($scope, $http) {

    $scope.processBtnssClicked = function () {
        
        $scope.staffDetails = {};

        var data = { staff_id: $scope.staff_id }; // Get the staff_id from the model
        console.log("clicked with staff_id:", $scope.staff_id);

        console.log("clicked!");
        $http.get('/Account/getStaff', { params: data })
            .then(function (response) {
                debugger;
                console.log('Success:', response.data);
                $scope.staffDetails = response.data;
            })
            .catch(function (error) {
                console.error('Error:', error);
            });
    };
}]);
