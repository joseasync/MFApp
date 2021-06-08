this.app.controller("TeacherController", function ($scope, $http, $window, $filter, TeacherStream) {
    //List
    $http.get("/Teacher/TeacherList").then(function (res) {
        $scope.teachers = res.data;
    }, function (error) {
        alert("Error to load the Teachers");
    });
    TeacherStream.on('addNewTeacher', function (newTeacher) {
        $scope.teachers.push(newTeacher);
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
                $window.location.href = '/Teacher/Teachers';
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
    $scope.deleteTeacher = function (id) {
        $http({
            method: 'POST',
            url: '/Teacher/DeleteTeacher/' + id,
        }).then(function (result) {
            if (result.data) {
                alert("Success!");
            }
            $scope.data = null;
            $window.location.href = '/Teacher/Teachers';
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
            urlPost = '/Teacher/CreateTeacher';
        } else {
            urlPost = '/Teacher/UpdateTeacher'

            $http({
                method: 'GET',
                url: '/Teacher/GetTeacher/' + id
            }).then(function (result) {
                result.data.Birthday = new Date($filter('date')(result.data.Birthday.slice(6, -2), 'yyyy-MM-dd'));
                $scope.data = result.data;
            }, function (error) {
                alert("Error to update the Teacher");
            });
        }
    }

});