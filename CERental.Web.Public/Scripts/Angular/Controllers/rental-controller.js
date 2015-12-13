app.controller('RentalController', ['$scope', 'EquipmentService', 'RentalService',
    function ($scope, equipmentService, rentalService) {

        $scope.model = {
            showCart: false,
            equipments: null,
            cart: []
        };

        $scope.rent = function (equipment) {
            console.log("Renting ...");
            console.log(equipment);

            $scope.model.showCart = true;
            if ($scope.model.cart.indexOf(equipment) == -1) {
                $scope.model.cart.push(equipment);
            }

            console.log($scope.model.cart);
        };

        $scope.mapType = function (typeId) {
            switch (typeId) {
                case 0:
                    return "Heavy equipment";
                case 1:
                    return "Regular equipment";
                case 2:
                    return "Specialized equipment";
                default:
                    return "Unknown type";
            }
        };

        $scope.model.cartHasItems = function () {
            console.log("checking cart");
            console.log($scope.model.cart);

            return $scope.model.cart.length > 0;
        };

        $scope.remove = function (item) {
            var index = $scope.model.cart.indexOf(item);
            $scope.model.cart.splice(index, 1);
        };

        $scope.order = function () {
            for (var i = 0; i < $scope.model.cart.length; i++) {
                var item = $scope.model.cart[i];

                if (item.Days == undefined) {
                    alert("Specify days for all items!");
                    return;
                }
            }

            rentalService.rent($scope.model.cart);
        };

        (function init() {

            console.log("Rental controller initialized");

            var set = equipmentService.getAll(function (data) {
                console.log(data);
                $scope.model.equipments = data;
            })

        })();

    }]);