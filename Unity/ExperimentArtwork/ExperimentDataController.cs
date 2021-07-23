using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ExperimentDataController : MonoBehaviour
{
    public static int ExperimentID = 1;
    public static string ExperimentDataFile = @"C:/Data_VIVE_PRO_EYE/ExperimentData.txt.TXT";
    public static string DataFilesDirectory = @"C:/Data_VIVE_PRO_EYE/";
    public static string CurrentDataFile = @"";
    public static int DataCounter=0;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();
        ExperimentID = r.Next(10000);
        if(File.Exists(ExperimentDataFile))
        {
            File.AppendAllText(ExperimentDataFile, "--------------------------------------" + Environment.NewLine
                + "Experiment ID: " + ExperimentID + Environment.NewLine);
            File.AppendAllText(ExperimentDataFile, "Time Started :"+ DateTime.Now.ToString("h:mm:ss tt")+ Environment.NewLine);
        }
        else {
            Debug.Log("No File");
        }
        if(!File.Exists(CurrentDataFile))
        {
            CurrentDataFile = DataFilesDirectory + "Experiment_" + ExperimentID + ".csv";
            File.CreateText(CurrentDataFile).Dispose();
        }
    //    File.AppendAllText(CurrentDataFile, "--------------------------------------" + Environment.NewLine
  //              + "Experiment ID: " + ExperimentID + Environment.NewLine);
    }

        // Update is called once per frame
        void Update()
        {
        string data = "";
        //eyes data
        data += gameObject.name + ",NoramlFrame,";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Direction.x.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Direction.y.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Direction.z.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Origin.x.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Origin.y.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.Origin.z.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.GazeRay.IsValid.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.IsLeftEyeBlinking.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.IsRightEyeBlinking.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.Timestamp.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.ConvergenceDistance.ToString() + ",";
        data += Tobii.XR.TobiiXR.Provider.EyeTrackingData.ConvergenceDistanceIsValid.ToString() + ",";
        data += DateTime.Now.ToString("h:mm:ss tt") + ",";

        //head data
        if (Camera.main != null)
        {
            data += Camera.main.transform.position.x.ToString() + ",";
            data += Camera.main.transform.position.y.ToString() + ",";
            data += Camera.main.transform.position.z.ToString() + ",";
            data += Camera.main.transform.rotation.x.ToString() + ",";
            data += Camera.main.transform.rotation.y.ToString() + ",";
        }
        ExperimentDataController.StoreDATA( CurrentDataFile, data);
    }
    public static void StoreDATA(string FileName, String Data) {
        if(File.Exists(FileName))
        {
            DataCounter++;
            File.AppendAllText(FileName,Data+ Environment.NewLine);
        }

    }
    private void OnApplicationQuit()
    {
        if (File.Exists(ExperimentDataFile))
        {
             File.AppendAllText(ExperimentDataFile, "Data Samples :" + DataCounter + Environment.NewLine);
            File.AppendAllText(ExperimentDataFile, "Time End :" + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine);
        }
    }
}
