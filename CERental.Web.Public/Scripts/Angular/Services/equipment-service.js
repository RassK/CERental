app.service('EquipmentService', ['$http', function ($http) {

    this.getAll = function (callback) {
        return $http.get('/api/equipment').success(function (data) {
            callback(data);
        });
    };

}]);