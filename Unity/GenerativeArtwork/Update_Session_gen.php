<?php 
//port of database is important
//
//Update_Session_gen

$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity";
error_reporting(0); 
$ExperimentID=$_POST['ExperimentID'];
//$ExperimentID=0;

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
 
 $sql = "update mk_data set id_session=1 where ExperimentID = '".$ExperimentID."'";

    $retval = mysqli_query( $conn,$sql );
         
            if(! $retval ) {
               die('Could not enter data: ' .mysqli_error($conn)."   --   ".$sql);
            }
            else
            {
            	echo "0";	
            }
 

$conn->close(); 