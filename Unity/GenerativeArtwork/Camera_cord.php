<?php 
//port of database is important
//
//Camera_cord.php
//
$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity";
error_reporting(0);
// $cx=$_POST['cx'];
// $cy=$_POST['cy'];
// $cz=$_POST['cz'];

// $cRx=$_POST['cx'];
// $cRy=$_POST['cy'];
// $cRz=$_POST['cz'];

// $name=$_POST['name'];
// $tag=$_POST['tag'];

//$ExperimentID=$_POST['ExperimentID'];
$DetectedObject=$_POST['DetectedObject'];
$DetectType=$_POST['DetectType'];
$EyeX=$_POST['EyeX'];
$EyeY=$_POST['EyeY'];
$EyeZ=$_POST['EyeZ'];
$PlayerX=$_POST['PlayerX'];
$PlayerY=$_POST['PlayerY'];
$PlayerZ=$_POST['PlayerZ'];
$GazeValid=$_POST['GazeValid'];
$LeftBlink=$_POST['LeftBlink'];
$RightBlink=$_POST['RightBlink'];
$GameTime=$_POST['GameTime'];
$ConvergenceDistance=$_POST['ConvergenceDistance'];
$ConvergenceDistanceValid=$_POST['ConvergenceDistanceValid'];
$Local_time=$_POST['Local_time'];
$CameraX=$_POST['CameraX'];
$CameraY=$_POST['CameraY'];
$CameraZ=$_POST['CameraZ'];
$CameraDirecationX=$_POST['CameraDirecationX'];
$CameraDirecationY=$_POST['CameraDirecationY'];
$CameraDirecationz=$_POST['CameraDirecationz'];
$CameraDirecationW=$_POST['CameraDirecationW'];
//$ServerDatatime=$_POST['ServerDatatime'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

/*$ ExperimentID=$_POST['cx'];
$DetectedObject=$_POST['cx'];
$DetectType=$_POST['cx'];
$EyeX=$_POST['cx'];
$EyeY=$_POST['cx'];
$EyeZ=$_POST['cx'];
$PlayerX=$_POST['cx'];
$PlayerY=$_POST['cx'];
$PlayerZ=$_POST['cx'];
$GazeValid=$_POST['cx'];
$LeftBlink=$_POST['cx'];
$RightBlink=$_POST['cx'];
$GameTime=$_POST['cx'];
$ConvergenceDistance=$_POST['cx'];
$ConvergenceDistanceValid=$_POST['cx'];
$Local_time=$_POST['cx'];
$CameraX=$_POST['cx'];
$CameraY=$_POST['cx'];
$CameraZ=$_POST['cx'];
$CameraDirecationX=$_POST['cx'];
$CameraDirecationY=$_POST['cx'];
$CameraDirecationz=$_POST['cx'];
$CameraDirecationW=$_POST['cx'];
$ServerDatatime=$_POST['cx'];


ExperimentID."','".$DetectedObject."','".$DetectType."','".$EyeX."','".$EyeY."','".$EyeZ."','".$PlayerX."','".$PlayerY."','".$PlayerZ."','".$GazeValid."','".$LeftBlink."','".$RightBlink."','".$GameTime."','".$ConvergenceDistance."','".$ConvergenceDistanceValid."','".$Local_time."','".$CameraX."','".$CameraY."','".$CameraZ."','".$CameraDirecationX."','".$CameraDirecationY."','".$CameraDirecationz."','".$CameraDirecationW."','".$ServerDatatime

 */
 
$sql = "SELECT MAX( ID ) AS max FROM `sessions`";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    // output data of each row
    while($row = mysqli_fetch_assoc($result)) {
        
$largestNumber = $row['max'];
    }
}
 $sql = "INSERT INTO  Camera_MK_Data (ExperimentID, DetectedObject, DetectType, EyeX, EyeY, EyeZ, PlayerX, PlayerY, PlayerZ, GazeValid, LeftBlink, RightBlink, GameTime, ConvergenceDistance, ConvergenceDistanceValid, Local_time, CameraX, CameraY, CameraZ, CameraDirecationX, CameraDirecationY, CameraDirecationz, CameraDirecationW, ServerDatatime,id_session) VALUES ( '".$largestNumber."','".$DetectedObject."','".$DetectType."','".$EyeX."','".$EyeY."','".$EyeZ."','".$PlayerX."','".$PlayerY."','".$PlayerZ."','".$GazeValid."','".$LeftBlink."','".$RightBlink."','".$GameTime."','".$ConvergenceDistance."','".$ConvergenceDistanceValid."','".$Local_time."','".$CameraX."','".$CameraY."','".$CameraZ."','".$CameraDirecationX."','".$CameraDirecationY."','".$CameraDirecationz."','".$CameraDirecationW."',NOW(4),'0')";

    $retval = mysqli_query( $conn,$sql );
         
            if(! $retval ) {
               die('Could not enter data: ' .mysqli_error($conn)."   --   ".$sql);
            }
            else
            {
            	echo "0";	
            }
// if ($conn->query($sql) === TRUE) {
//     echo "0";
// } else {
//     echo "Error: " . $sql . "<br>" . $conn->error;
// }

$conn->close(); 