<?php 
//port of database is important
//
//Session_Insert
//
$servername = "localhost:3306";
$username = "root";
$password = "";
$dbname = "unity";
error_reporting(0); 

$SessionID=$_POST['SessionID'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
 
 
 
 $sql = "INSERT INTO  sessions (id, StartTime, gen) VALUES ( '".$SessionID."',NOW(4),'0')";

    $retval = mysqli_query( $conn,$sql );
         
            if(! $retval ) {
               die('Could not enter data: ' .mysqli_error($conn)."   --   ".$sql);
            }
            else
            {
            	echo "0";	
            }
 
$conn->close(); 