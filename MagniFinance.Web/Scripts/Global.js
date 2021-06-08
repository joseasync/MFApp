var app = angular.module("MFApp", ['ui.mask', 'ngMessages', 'ngResource']);
app.factory('StudentStream', ['$rootScope', function ($rootScope) {
    'use strict';
        return {
        on: function (eventName, callback) {
            var connection = $.hubConnection();
            var studentHubProxy = connection.createHubProxy('studentHub');
            studentHubProxy.on(eventName, function () {
                var args = arguments;
                $rootScope.$apply(function () {
                    callback.apply(studentHubProxy, args);
                });
            });
            connection.start().done(function () { });
        }
    };
}]);
app.factory('TeacherStream', ['$rootScope', function ($rootScope) {
    'use strict';
    return {
        on: function (eventName, callback) {
            var connection = $.hubConnection();
            var studentHubProxy = connection.createHubProxy('teacherHub');
            studentHubProxy.on(eventName, function () {
                var args = arguments;
                $rootScope.$apply(function () {
                    callback.apply(studentHubProxy, args);
                });
            });
            connection.start().done(function () { });
        }
    };
}]);
