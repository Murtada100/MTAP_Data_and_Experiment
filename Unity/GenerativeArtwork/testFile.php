<?php  
$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity";
 error_reporting(0);


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

  $sql = "select ExperimentID,DetectedObject,sum(tt) ss from (select id, ExperimentID,DetectedObject,DetectType,if(DetectType='FocusIn', GameTime*-1 ,GameTime)as tt from mk_data where DetectType<> 'NoramlFrame' and id_session=0 and ExperimentID = (select max(ExperimentID) from mk_data) ) as dd group by DetectedObject order by ss desc limit 30";
 
$result = $conn->query($sql);

$rows = array();
while($r = mysqli_fetch_assoc($result)) {
            
$rows[] = $r; 

$conn->close(); 
file_put_contents('filename.txt', print_r($rows, true));

 
?>