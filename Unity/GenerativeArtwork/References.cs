using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References 
{
    private static string host = "";

    public static string URL_insert =        host + "/Unity_test/GetLastUserStrokes.php";
    public static string URL_UpdateSession = host + "/Unity_test/Update_Session_gen.php";
    public static string URL_GetLastStrokes= host + "/Unity_test/GetLastUserStrokes.php";
    public static string URL_InsertSession = host + "/Unity_test/Session_Insert.php";
    public static string URL_InsertCamera =  host + "/Unity_test/Camera_cord.php";
    public References(string host)
    {
        References.host = host;
           URL_insert = host + "/Unity_test/GetLastUserStrokes.php";
     URL_UpdateSession = host + "/Unity_test/Update_Session_gen.php";
     URL_GetLastStrokes = host + "/Unity_test/GetLastUserStrokes.php";
     URL_InsertSession = host + "/Unity_test/Session_Insert.php";
     URL_InsertCamera = host + "/Unity_test/Camera_cord.php";
}
}
