app.service('RentalService', ['$http', '$window', function ($http, $window) {

    this.rent = function (items) {

        var postModel = [];

        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            postModel.push({ EquipmentId: item.Id, Days: item.Days });
        }

        console.log(postModel);
        $http.post('/Home/PostOrder', postModel)
            .success(function (data) {

            console.log('order success');
            console.log(data);
            $window.location.href = '/home/ThankYou';

            }).error(function(){
              
                alert("Invalid input. Please check your data");
                
            });
    };

}]);