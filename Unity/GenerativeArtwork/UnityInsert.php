<?php 
//port of database is important
$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity"; 
 
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

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

 
$sql = "SELECT MAX( ID ) AS max FROM `sessions`";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    // output data of each row
    while($row = mysqli_fetch_assoc($result)) {
        
$largestNumber = $row['max'];
    }
}
 $sql = "INSERT INTO  MK_Data (ExperimentID, DetectedObject, DetectType, EyeX, EyeY, EyeZ, PlayerX, PlayerY, PlayerZ, GazeValid, LeftBlink, RightBlink, GameTime, ConvergenceDistance, ConvergenceDistanceValid, Local_time, CameraX, CameraY, CameraZ, CameraDirecationX, CameraDirecationY, CameraDirecationz, CameraDirecationW, ServerDatatime,id_session) VALUES ( '".$largestNumber."','".$DetectedObject."','".$DetectType."','".$EyeX."','".$EyeY."','".$EyeZ."','".$PlayerX."','".$PlayerY."','".$PlayerZ."','".$GazeValid."','".$LeftBlink."','".$RightBlink."','".$GameTime."','".$ConvergenceDistance."','".$ConvergenceDistanceValid."','".$Local_time."','".$CameraX."','".$CameraY."','".$CameraZ."','".$CameraDirecationX."','".$CameraDirecationY."','".$CameraDirecationz."','".$CameraDirecationW."',NOW(4),'0')";

    $retval = mysqli_query( $conn,$sql );
         
            if(! $retval ) {
               die('Could not enter data: ' .mysqli_error($conn)."   --   ".$sql);
            }
            else
            {
            	echo "0";	
			}

$conn->close(); 