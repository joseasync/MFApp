this.app.controller("StudentController", function ($scope, $http, $window, $filter, StudentStream) {
    //List
    $http.get("/Student/StudentListView").then(function (res) {
        $scope.students = res.data;
    }, function (error) {
        alert("Error to load the Students");
    });
    StudentStream.on('addNewStudent', function (newStudent) {
        $scope.students.push(newStudent);
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
                $window.location.href = '/Student/Students';
            } else {
                alert("Error saving data.");
                $('#btnSave').prop('disabled', false);
                $scope.btntext = "Save";
            }
        }, function (error) {
            alert(error);
        });
    }

    //Delete
    $scope.deleteStudent = function (id) {
        $http({
            method: 'POST',
            url: '/Student/DeleteStudent/' + id,
        }).then(function (result) {
            if (result.data) {
                alert("Success!");
            }
            $scope.data = null;
            $window.location.href = '/Student/Students';
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
            urlPost = '/Student/CreateStudent';
        } else {
            urlPost = '/Student/UpdateStudent'

            $http({
                method: 'GET',
                url: '/Student/GetStudent/' + id
            }).then(function (result) {
                result.data.Birthday = new Date($filter('date')(result.data.Birthday.slice(6, -2), 'yyyy-MM-dd'));
                $scope.data = result.data;
            }, function (error) {
                alert("Error to update the Student");
            });
        }
    }

});