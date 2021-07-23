using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class CreateObjectCopy : MonoBehaviour
{

    //float MinX, MinZ, MaxX,MaxZ;
    public GameObject GenArtWork;
    private string LastGenerativeSession="";
    public GameObject cam1;
    public GameObject cam2;
    int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
         ReadHostFile();
        StartCoroutine(GetText()); 
      
    }
    private void ReadHostFile() 
    {
        StreamReader reader = new StreamReader(@"/GenerativeArt/HOST.txt");
        string HostFile = reader.ReadToEnd();
        Debug.Log(HostFile);
        References r= new References(HostFile);
        reader.Close();
    }
    private float nextActionTime = 0.0f;

    void Update()
    {
        ///*AnimatedCam*/();

        //timer++;
        //if (Time.time < 30) return;

        if (Time.time > nextActionTime)
        {
            nextActionTime += 15;

            StartCoroutine(GetText());

        }


    }
    int counterCamPoistion = 0;
    Vector3 toPosition;
    bool centrized = true;
    void AnimatedCam()
    {
        //Debug.Log("AnimtedCalled");
        Debug.Log("MaxX:" + MaxX + "  -MinX:" + MinX);
        Debug.Log("Maxx:" + MaxZ + "  -MinZ:" + MinZ);
        if (toPosition != null)
        {
            if (Vector2.Distance(toPosition, transform.localPosition) < 1)
            {

                Debug.Log("Object in the traget");

            }
            else
            {
                Debug.Log("Object is Far");
                Debug.Log("Moving111111");
                transform.localPosition = Vector3.Lerp(transform.position, toPosition, .1f * Time.deltaTime);
                return;
            }

        }
        else
            Debug.Log("Null Positioning");




        if (counterCamPoistion == 0)
        {
            toPosition = new Vector3(MinX, 100, MinZ);
            counterCamPoistion = 1;
            centrized = !centrized;
            Debug.Log("0");
        }
        else if (counterCamPoistion == 1)
        {
            toPosition = new Vector3(MaxX, 100, MaxZ);
            counterCamPoistion = 2;
            centrized = centrized = !centrized;
            ;
            Debug.Log("1");
        }
        else if (counterCamPoistion == 2)
        {
            toPosition = new Vector3(MinX, 100, MaxZ);
            counterCamPoistion = 3;
            centrized = !centrized;
            Debug.Log("2");
        }
        else
        {
            toPosition = new Vector3(MaxX, 100, MinZ);
            counterCamPoistion = 0;
            centrized = !centrized;
            Debug.Log("3");
        }
        if (centrized)
        {
            toPosition = new Vector3(0, 100, 0);
            centrized = !centrized;
        }

        Debug.Log("Moving");
        transform.localPosition = Vector3.Lerp(transform.position, toPosition, .5f * Time.deltaTime);
    }
    string PreviousData = "";
    IEnumerator GetText()
    {
        WWW www = new WWW(References.URL_GetLastStrokes);
        yield return www; 
        Debug.Log(www.url);
        Debug.Log(www.text); 
        JArray json = JArray.Parse(www.text);
        if (!String.Equals(PreviousData, www.text))
        {
            Debug.Log("Update Paint");
            foreach (var v in json)
                {
                   ShowStrokes((string)v.Value<string>("DetectedObject"));
                   LastGenerativeSession = v.Value<string>("ExperimentID");
                   }
                PreviousData = www.text;
                if (!LastGenerativeSession.Equals(""))
                { 
                   StartCoroutine(UpdateSession());
                }
        }
       
     
    }
    private IEnumerator UpdateSession()
    {
        WWWForm form = new WWWForm();
        form.AddField("ExperimentID", LastGenerativeSession);
        WWW www = new WWW(References.URL_UpdateSession,form);
        yield return www;
        if (www.text == "0")

        {
            Debug.Log("Session Updated" + www.text);
        }
        else
        {
            Debug.Log("Session Fail: " + www.text);
        }
    }


    private void ShowStrokes(string strokesName)
    {
        GameObject tempobj = GameObject.Find(strokesName); 
        if (tempobj != null)
        { 
            GameObject newobj = Instantiate(tempobj, GetSpiralpoints(), Quaternion.identity);//update
            newobj.GetComponent<MeshRenderer>().enabled = true;
            newobj.transform.parent = GenArtWork.transform;
            
        }
        else
        {
            Debug.Log("Not Found " + strokesName);
        }
    }
    private float length = 1;
    private float angle = 0.0f;
    private float interval = 0.1f;
    Vector3 GetSpiralpoints()
    {
        Vector3 v = new Vector3();
        v.x = (0.2f * length * Mathf.Cos(angle));
        v.z = (0.2f * length * Mathf.Sin(angle));
        MinX = MinX > v.x ? v.x : MinX;
        MaxX = MaxX < v.x ? v.x : MaxX;
        MinZ = MinZ > v.z ? v.z : MinZ;
        MaxZ = MaxZ < v.z ? v.z : MaxZ;
        angle += interval;
        length += 1.0f;
        v.y = GenArtWork.transform.position.y;
        return v;
    }

 
}
