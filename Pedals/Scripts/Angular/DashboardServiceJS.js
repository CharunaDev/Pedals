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


    //get order details
    //var data = {
    //    fromDate: '2018-02-04',
    //    toDate: '2018-09-04',
    //    status: '1,3'
    //   };
    //$scope.GetOrderDetails = function () {
    //    $http.get('/Dashboard/getOrderDetails', { params: data })
    //        .then(function (response) {
    //            debugger;
    //            console.log('Success:', response.data);
    //            $scope.orderDetails = response.data;
    //        })
    //        .catch(function (error) {
    //            console.error('Error:', error);
    //        });
    //}

    //new DataTable('#example', {
    //    responsive: true
    //});


    //pagination
    $scope.currentPage = 1;
    $scope.pageSize = 5; // Number of items per page
    $scope.totalPages = 0;

    $scope.prevPage = function () {
        if ($scope.currentPage > 1) {
            $scope.currentPage--;
            $scope.GetOrderDetails();
        }
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.totalPages) {
            $scope.currentPage++;
            $scope.GetOrderDetails();
        }
    };

    $scope.GetOrderDetails = function () {
        var data = {
            fromDate: '2018-02-04',
            toDate: '2018-09-04',
            status: '1,3',
            pageNumber: $scope.currentPage,
            pageSize: $scope.pageSize
        };
        $http.get('/Dashboard/getOrderDetails', { params: data })
            .then(function (response) {
                console.log('Success:', response.data);
                $scope.orderDetails = response.data;
                $scope.totalPages = Math.ceil(response.data.length / $scope.pageSize);
            })
            .catch(function (error) {
                console.error('Error:', error);
            });
    };

    $scope.GetOrderDetails();



}]);


