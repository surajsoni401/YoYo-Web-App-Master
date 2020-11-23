var time = 0;
var running = 0;
var fitnessRating = {};
var cummulative_seconds = 0;
var currentShuttleLevel = "";
var currentLevel = "";
var currentSpeed = "";
var totalNextShuttleTime = 0;
var firstime = true;
var previousLevel = "";
var previousShuttleLevel = "";
var query = '';

class FitnessRating {
    constructor(AccumulatedShuttleDistance, SpeedLevel, ShuttleNo, Speed, LevelTime, CommulativeTime, StartTime) {
        this.AccumulatedShuttleDistance = AccumulatedShuttleDistance;
        this.SpeedLevel = SpeedLevel;
        this.ShuttleNo = ShuttleNo;
        this.Speed = Speed;
        this.LevelTime = LevelTime;
        this.CommulativeTime = CommulativeTime;
        this.StartTime = StartTime;
    }
}

window.onload = function () {
    @foreach(string key in Model.FitnessRating.Keys)
    {
        <text>
            fitnessRating['@key:1'] = new FitnessRating(@Model.FitnessRating[key].AccumulatedShuttleDistance, @Model.FitnessRating[key].SpeedLevel,@Model.FitnessRating[key].ShuttleNo,@Model.FitnessRating[key].Speed,@Model.FitnessRating[key].LevelTime,'@Model.FitnessRating[key].CommulativeTime','@Model.FitnessRating[key].StartTime');
            </text>
    }
}

function startPause() {
    if (running == 0) {
        running = 1;
        document.getElementById("startPause").innerHTML = "<i class='glyphicon glyphicon-pause'></i> Level " + currentLevel
            + "</br>Shuttle " + currentShuttleLevel
            + "</br>" + currentSpeed + " km/h";
        increment();
    } else {
        running = 0;
        document.getElementById("startPause").innerHTML = "<i class='glyphicon glyphicon-repeat'></i> Resume";
    }
}

function increment() {
    if (running == 1) {
        setTimeout(function () {
            time++;
            var mins = Math.floor(time / 10 / 60) % 60;
            var secs = Math.floor(time / 10) % 60;
            var tenths = time % 10;

            var currenttime = ((mins * 60) + secs) * 10 + tenths;
            var nextShuttle = cummulative_seconds - currenttime;

            if (mins < 10) {
                mins = "0" + mins;
            }
            if (secs < 10) {
                secs = "0" + secs;
            }
            document.getElementById("stopWatchDisplay").innerHTML = mins + ":" + secs;
            if (nextShuttle >= 0 && firstime == true) {
                firstime = false;
                totalNextShuttleTime = nextShuttle;
            }
            if (nextShuttle >= 0) {
                document.getElementById("nextShuttleDisplay").innerText = Math.ceil(nextShuttle / 10) + ":" + nextShuttle % 10;
                document.getElementById("progressbar").style.width = nextShuttle / totalNextShuttleTime * 100 + "%";
            }
            if (nextShuttle < 0) {
                document.getElementById("progressbar").style.width = "100%";
                firstime = true;
            }

            var startTime = mins + ":" + secs + ":" + tenths;
            if (fitnessRating[startTime] != null) {
                var cummulativetime = fitnessRating[startTime].CommulativeTime.split(":");
                cummulative_seconds = (parseInt(cummulativetime[0]) * 60 + parseInt(cummulativetime[1])) * 10;

                previousLevel = currentLevel;
                previousShuttleLevel = currentShuttleLevel;
                currentLevel = fitnessRating[startTime].SpeedLevel;
                currentShuttleLevel = fitnessRating[startTime].ShuttleNo;
                currentSpeed = fitnessRating[startTime].Speed;
                document.getElementById("startPause").innerHTML = "<i class='glyphicon glyphicon-pause'></i> Level " + currentLevel
                    + "</br>Shuttle " + currentShuttleLevel
                    + "</br>" + currentSpeed + " km/h";
                document.getElementById("totalDistanceDisplay").innerText = fitnessRating[startTime].AccumulatedShuttleDistance - 40 + " m";
            }
            increment();
        }, 100);
    }
}
function warn(id) {
    if (currentLevel != "" && currentShuttleLevel != "") {
        var btnwarn = document.getElementById(id);
        btnwarn.innerHTML = "Warned";
        btnwarn.disabled = true;
    }
}

function stop(warnid, resultid, stopid, id) {
    if (currentLevel != "" && currentShuttleLevel != "") {
        if (previousLevel == "") previousLevel = "0";
        if (previousShuttleLevel == "") previousShuttleLevel = "0";
        var btnstop = document.getElementById(stopid);
        var btnwarn = document.getElementById(warnid);
        btnstop.parentNode.removeChild(btnstop);
        btnwarn.parentNode.removeChild(btnwarn);
        var result = document.getElementById(resultid);
        result.innerHTML = "<p class='font-weight-bold'>" + previousLevel + " - " + previousShuttleLevel + "</p>";
        query = query + id + '%' + previousLevel + '%' + previousShuttleLevel + ':';
        document.getElementById("endTestLink").href = "/Home/Detail?query=" + query;
    }
}