this.app.controller("CourseController", function ($scope, $http, $window) {
    //List
    $http.get("/Course/CourseList").then(function (res) {
        $scope.courses = res.data;
    }, function (error) {
        alert("Error to load the Courses");
    });

    //Save/update
    var urlPost = '';
    checkUpdate();
    $scope.savedata = function () {
        $scope.btnDisable = true;
        $scope.btntext = "Please Wait...";

        $http({
            method: 'POST',
            url: urlPost,
            data: $scope.data
        }).then(function (result) {
            if (result.data == true) {
                alert("Success!");
                $scope.data = null;
                $window.location.href = '/Course/Courses';
            } else {
                alert("Error saving data.\n" + result.data);
                $('#btnSave').prop('disabled', false);
                $scope.btntext = "Save";
            }
        }, function (error) {
            alert(error);
        });
    }

    //Delete
    $scope.deleteCourse = function (id) {
        $http({
            method: 'POST',
            url: '/Course/DeleteCourse/' + id,
        }).then(function (result) {
            if (result.data) {
                alert("Success!");
            }
            $scope.data = null;
            $window.location.href = '/Course/Courses';
        }, function (error) {
            alert(error);
        });
    }

    function checkUpdate() {
        var url = window.location.pathname;
        var id = url.substring(url.lastIndexOf('/') + 1);
        let s = "" + id;
        s = s.match('^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$');
        if (s === null) {
            urlPost = '/Course/CreateCourse';
        } else {
            urlPost = '/Course/UpdateCourse'

            $http({
                method: 'GET',
                url: '/Course/GetCourse/' + id
            }).then(function (result) {
                $scope.data = result.data;
            }, function (error) {
                alert("Error to update the Course");
            });
        }
    }

});