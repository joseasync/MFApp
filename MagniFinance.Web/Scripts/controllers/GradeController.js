this.app.controller("GradeController", function ($scope, $http, $window) {
    //List
    $http.get("/Grade/GradeList").then(function (res) {
        $scope.grades = res.data;
    }, function (error) {
        alert("Error to load the Grade");
    });
    $http.get("/Subject/SubjectList").then(function (res) {
        $scope.subjects = res.data;
    }, function (error) {
        alert("Error to load the Subjects");
    });
    $http.get("/Student/StudentList").then(function (res) {
        $scope.students = res.data;
    }, function (error) {
        alert("Error to load the Students");
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
                $window.location.href = '/Grade/Grades';
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
    $scope.deleteGrade = function (id) {
        $http({
            method: 'POST',
            url: '/Grade/DeleteGrade/' + id,
        }).then(function (result) {
            if (result.data) {
                alert("Success!");
            }
            $scope.data = null;
            $window.location.href = '/Grade/Grades';
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
            urlPost = '/Grade/CreateGrade';
        } else {
            urlPost = '/Grade/UpdateGrade'

            $http({
                method: 'GET',
                url: '/Grade/GetGrade/' + id
            }).then(function (result) {
                $scope.data = result.data;
            }, function (error) {
                alert("Error to update the Grade");
            });
        }
    }

});