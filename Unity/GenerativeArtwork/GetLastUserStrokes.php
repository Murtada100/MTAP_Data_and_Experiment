<?php 

$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity";
//error_reporting(0);


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

  $sql = "SELECT ExperimentID, DetectedObject, SUM(tt) ss FROM (SELECT id,ExperimentID,DetectedObject,DetectType, IF(DetectType = 'FocusIn', GameTime * - 1, GameTime) AS tt FROM mk_data WHERE DetectType <> 'NoramlFrame' AND id_session = 0 AND ExperimentID in (SELECT max(ExperimentID) FROM (select ExperimentID,max(ServerDatatime) ServerDatatime,id_session from mk_data group by ExperimentID having id_session=0 and ServerDatatime<DATE_ADD(now(), INTERVAL -30 second))as ddd)) AS dd GROUP BY DetectedObject ORDER BY ss DESC LIMIT 30;";
 
 
$result = $conn->query($sql);

$rows = array();
while($r = mysqli_fetch_assoc($result)) {
            
$rows[] = $r;
}
print json_encode($rows);

$conn->close(); 