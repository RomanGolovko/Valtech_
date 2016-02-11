function initialize() {
    var dp = { lat: 48.473796, lng: 35.017151 };
    var map = new google.maps.Map(document.getElementById('map_canvas'), {
        zoom: 17,
        center: dp
    });

    var geocoder = new google.maps.Geocoder();
    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng, map);
        var add = $(".address_container > input");

        geocoder.geocode({ 'location': event.latLng }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK) {
                $("#Addresses_0__Number").val(results[0].address_components[0].long_name);
                $("#Addresses_0__Street_Title").val(results[0].address_components[1].long_name);
                $("#Addresses_0__Street_City_Title").val(results[0].address_components[3].long_name);
                $("#Addresses_0__Street_City_Country_Title").val(results[0].address_components[6].long_name);                  
            }
        });
    });

    addMarker(dp, map);


    document.getElementById('submit').addEventListener('click', function () {
        console.log($(".address_container > input"));
        var add = $(".address_container > input");
        var address = add[4].value + "," + add[5].value + "," + add[6].value + "," + add[7].value;
        geocodeAddress(geocoder, map, address);

    });
}
var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
var labelIndex = 0;

function addMarker(location, map) {
    var marker = new google.maps.Marker({
        position: location,
        label: labels[labelIndex++ % labels.length],
        map: map
    });
}


function geocodeAddress(geocoder, resultsMap, address) {

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            resultsMap.setCenter(results[0].geometry.location);

            var add = $(".address_container > input");
            add[11].value = results[0].geometry.location.lat();
            add[12].value = results[0].geometry.location.lng();


            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location
            });

        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}

google.maps.event.addDomListener(window, 'load', initialize);
<input type="button" value="Get location" id="submit">

                <div id="map_canvas" style="width:700px; height:450px;"></div>
<script type="text/javascript" src="http://maps.google.com/maps/api/js"></script>