angular.module('RoomListApp', [])
	.controller('RoomListController', ['$scope', '$http', function ($scope, $http) {
		var roomList = this;

		var url = "http://www.university.com/api/ClassRoom/GetClassRooms";
		var postData = { "AllReserved": false, "AllAvailable": false };

		$.ajax({
			type: 'POST',
			url: url,
			data: postData,
			dataType: 'json',
			headers: { 'Content-Type': 'application/json; charset=UTF-8' },
			headers: { 'Origin': 'www.university.com' },
			success: function (resultData, textStatus, jqXHR) {
				$scope.$apply(function () {
					roomList.Room = resultData.ReservedRoomList;
				});
			},
			error: function (request, status, error) {
				alert(status);
			}
		});

	}]);

