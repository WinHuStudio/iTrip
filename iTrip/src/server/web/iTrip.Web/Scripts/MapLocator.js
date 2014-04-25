/// <reference path="TripperLocation.js" />

(function ($) {
    $.fn.MapLocator = function () {
        //设定默认值
        //var conf = $.extend({
        //    mapid: ""
        //}, opts);
        var map;
        var _mapContainer = this;
        this.location = new TripperLocation({ name: 'TripperLocation' });
        $.fn.Initialize = function (lng, lat) {
            var mapOptions = {
                zoom: 12,
                center: new google.maps.LatLng(lng, lat),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            console.log(document.getElementById(_mapContainer.attr('id')));
            map = new google.maps.Map(document.getElementById(_mapContainer.attr('id')),
                mapOptions);

            //var marker = new google.maps.Marker({
            //    position: map.getCenter(),
            //    map: map,
            //    title: 'Click to zoom'
            //});

            google.maps.event.addListener(map, 'center_changed', function () {
                // 3 seconds after the center of the map has changed, pan back to the
                // marker.
                //window.setTimeout(function () {
                //    map.panTo(marker.getPosition());
                //}, 3000);
            });
            google.maps.event.addListener(map, 'zoom_changed', function () {
                //var zoomLevel = map.getZoom();
                //map.setCenter(myLatLng);
                //infowindow.setContent('Zoom: ' + zoomLevel);
            });

            google.maps.event.addListener(map, 'click', function (event) {
                //map.setZoom(12);
                console.log(event.LatLng);
                //map.setCenter(marker.getPosition());
                //palceMaker(event.LatLng);
            });
            //var myLatLng = new google.maps.LatLng(lng, lat);
            //var infowindow = new google.maps.InfoWindow({
            //    content: 'Change the zoom level',
            //    position: myLatLng
            //});
        }

        this.location.ShowName();
        $.fn.UpdatePoint = function (account, name, lng, lat, time, nation, city) {
            var snap = this.location.UpdateSnap(account, name, time, nation, city);
            if (snap.NeedToUpdate(lng, lat)) {
                var marker = snap.GetPoint();
                if (marker != undefined) marker.setMap(null);
                var location = new google.maps.LatLng(lng, lat);
                marker = new google.maps.Marker({
                    title: snap.name,
                    position: location,
                    map: map
                });

                map.setCenter(location);
                snap.UpdateLngLat(lng, lat);
                snap.SetPoint(marker);
            }
        }
        return this;
    };


})(jQuery)

