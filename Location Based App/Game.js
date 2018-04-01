
//Runs on pageshow on the first page.
$(document).on('pagecreate', '#login-page', function (event, args) {
    $('#startBTN').click(function (event) {
        playerName = $('#playerNameTB').val();
        if (playerName == null || playerName == "") {
            alert("Enter your nickname before starting the game");
            event.preventDefault();
        }
    });


    $('#backBTN').click(function (event) {
        endGameLogic(false);
    });


    $('#winBTN').click(function (event) {
        pos_player = new google.maps.LatLng(pos_challenge.lat(), pos_challenge.lng());
        SuccessNextChallenge = true;
    });

    $('#loseBTN').click(function (event) {
        challengeTime = 1;
    });

});


$(document).on('pageshow', '#game-page', function (event, args) { //init function for game page
    markers = [];
    pos_player = null; //
    pos_challenge = null;
    infowindow = null;
    gameTime = 0;
    challenges_lost = 0;
    challenges_won = 0;
    handle_gameTimer = setInterval('gameTimer()', 1000);
    handle_challengeTimer = null;

    //Create map
    var mapOptions = {
        zoom: 17
    }

    mapCanvas = document.getElementById('map-canvas');
    map = new google.maps.Map(mapCanvas, mapOptions);

    //Get position
    interval_getPosition = 5000;
    getMyPosition(); //First time, it will get a challenge also
    handle_getPosition = setInterval('getMyPosition()', interval_getPosition)



    //Cheating For Testing:
    SuccessNextChallenge = false;
    $(document).on("keydown", function (event) {
        //  $("#log").html(event.type + ": " + event.which);
        console.log(event.type + ": " + event.which);


        //if you press P (for player) you're "moved" to the challenge (success)
        if (event.which == 80) {
            pos_player = new google.maps.LatLng(pos_challenge.lat(), pos_challenge.lng());
            SuccessNextChallenge = true;

        }

        //if you press C (for challenge) you fail the challenge

        if (event.which == 67) {
            challengeTime = 1;

        }
    });

})

/*
------------------------------------------------------
Get  Position
------------------------------------------------------
*/
function getMyPosition() {
    var options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 1000
    };
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(getCurrentPosition_Success,
            getCurrentPosition_Failure,
            options);
    }
}

function getCurrentPosition_Success(position) {
    pos_player = new google.maps.LatLng(position.coords.latitude, position.coords.longitude); //to access via .lng()

    //if we don't have a challenge yet, focus on the player position for the first time.
    //without this, map wont have a center before we get a challenge and we wont see the map...
    if (!pos_challenge) {
        console.log("Centered without a challenge position, " + pos_player);
        map.setCenter(new google.maps.LatLng(pos_player.lat(), pos_player.lng()));
        getChallengeAttempt();
    } else {

        console.log("Centered without a challenge position, " + pos_player);
        console.log(pos_player + ", " + pos_challenge);
        var lat = (pos_player.lat() + pos_challenge.lat()) / 2;
        var lng = (pos_player.lng() + pos_challenge.lng()) / 2;
        var coords = new google.maps.LatLng(lat, lng);
        map.setCenter(coords);

        var request = {
            lat: lat,
            lng: lng,
            groupName: playerName
        };
        getDistance(request, getDistance_Success, getDistance_Failure);
    }


    //Place a marker on player location
    if (markers[0] != null) {
        markers[0].setMap(null);
    }
    player_marker = new google.maps.Marker({
        position: pos_player,
        map: map,
        title: 'player', icon: "images/man_small.png"
    });
    markers[0] = player_marker;



}

function getCurrentPosition_Failure(err) {
   // alert("Failed to get position");
    console.log(err);
}

/*
------------------------------------------------------
Get  Challenge
------------------------------------------------------
*/

function getChallengeAttempt() {

    var challengeRequest = {
        lat: pos_player.lat(),
        lng: pos_player.lng(),
        groupName: document.getElementById('playerNameTB').value
    }
    getChallenge(challengeRequest, getChallenge_Success, getChallenge_Failure);


    // alert("Player Position:"+pos_player.Lat() + ", " + pos_player.lng)
}

function getChallenge_Success(result) {
    if (infowindow) {
        infowindow.close();
    }
    console.log(result);
    var data = $.parseJSON(result.d);
    var lat = data.Latitude;
    var lng = data.Longtitude;
    var desc = data.Description;
    var imgPath = data.ImagePath;
    challengeTime = data.TimeInSec;// + "000";
    if (handle_challengeTimer != null) {
        clearInterval(handle_challengeTimer);
    }
    handle_challengeTimer = setInterval('challengeTimer()', 1000);
    // create a marker
    pos_challenge = new google.maps.LatLng(lat, lng);
    challenge_marker = new google.maps.Marker({
        position: pos_challenge,
        map: map,
        title: 'Challenge Point',
        icon: "images/blue-dot.png"
    });

    var contentString = '<div><h4>' + desc + '</h4><div><img class="infoImg" src = "' + imgPath + '"/></div></div>';
    infowindow = new google.maps.InfoWindow({
        content: contentString
    });
    infowindow.open(map, challenge_marker);
    markers.push(challenge_marker);
}

function getChallenge_Failure(e) {
   // alert("failed in get challenge :( " + e.responseText);
}

function NextChallenge(win) {
    if (win) {
        var icon = {
            url: 'images/happy.png', // url
            scaledSize: new google.maps.Size(50, 50), // scaled size

        };
        challenges_won++;
    } else {
        var icon = {
            url: 'images/sad.png', // url
            scaledSize: new google.maps.Size(50, 50), // scaled size

        };
        challenges_lost++;
    }

    challenge_marker.setIcon(icon);
    getChallengeAttempt();
}


/*
------------------------------------------------------
Game Timers
------------------------------------------------------
*/

function gameTimer() {
    gameTime++;
    // $('#totalTimeSPAN').text(gameTime);
    if (gameTime >= 5 * 60) {
       
        endGameLogic(true);
    }
}

function challengeTimer() {
    challengeTime--;
    $('#challengeTimeSPAN').text(challengeTime);
    if (challengeTime <= 0) {

        NextChallenge(false);
    }
}

/*
------------------------------------------------------
Get Distance
------------------------------------------------------
*/

function getDistance_Success(data) {
    
    var distance = $.parseJSON(data.d) * 1000; //X 1000 is because the value received is in KM
    distance = Math.floor(distance);           // round the distance

    if (SuccessNextChallenge) {
        SuccessNextChallenge = false;
        distance = 0;
      
    }
    if (distance < 5) {
       
        NextChallenge(true);

    }
}

function getDistance_Failure(data) {
   
   // alert("Failed getting the distance");
}



function endGameLogic(timeEnded) {

    clearInterval(handle_getPosition);
    clearInterval(handle_gameTimer);
    clearInterval(handle_challengeTimer);

    var byebye = "Game ended, ";
    if (timeEnded) {
        byebye += "you ran out of time.";
    } else {
        byebye += "you chose to leave."
    }
    byebye += "\r\nChallenges Finished: " + challenges_won + "\r\n"; //get challenges finished
    byebye += "Challenges Lost: " +challenges_lost;

    alert(byebye);
}