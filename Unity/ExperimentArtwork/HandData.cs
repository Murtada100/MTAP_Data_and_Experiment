using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System.IO;
using System;

public class HandData : MonoBehaviour
{
    Frame frame;
// Start is called before the first frame update
void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {

        string data = "";
        Controller controller = new Controller();
        frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;

           // Hand firstHand = hands[0];
           foreach(Hand h in hands)
            {

                List<Finger> fings = h.Fingers;
                data += h.IsRight + ",";
                data += h.Arm.WristPosition.x + ",";
                data += h.Arm.WristPosition.y + ",";
                data += h.Arm.WristPosition.z + ",";
                data += h.Arm.ElbowPosition.x + ",";
                data += h.Arm.ElbowPosition.y + ",";
                data += h.Arm.ElbowPosition.z + ",";
                data += h.Arm.Direction.x + ",";
                data += h.Arm.Direction.y + ",";
                data += h.Arm.Direction.z + ",";
                data += h.PalmPosition.x + ",";
                data += h.PalmPosition.y + ",";
                data += h.PalmPosition.z + ",";
                data += h.PalmVelocity.x+ ",";
                data += h.PalmVelocity.y+ ",";
                data += h.PalmVelocity.z + ",";
                data += h.IsRight + ",";
                foreach (Finger F in fings)
                {
                    data += F.TipPosition.x+ ",";
                    data += F.TipPosition.y+ ",";
                    data += F.TipPosition.z + ",";
                    data += F.Direction.x + ",";
                    data += F.Direction.y + ",";
                    data += F.Direction.z + ",";

                    Bone[] bones = F.bones;
                    foreach (Bone b in bones)
                    {
                        data += b.Direction.x.ToString() + ",";
                        data += b.Direction.y.ToString() + ",";
                        data += b.Direction.z.ToString() + ",";
                        data += b.Width.ToString() + ",";
                        data += b.Length.ToString() + ",";
                        data += b.Rotation.x.ToString() + ",";
                        data += b.Rotation.y.ToString() + ",";
                        data += b.Rotation.x.ToString() + ",";
                        data += b.Rotation.x.ToString() + ",";
                        data += b.Type.ToString() + ",";
                    }
                }
            }
 
        }
        if(File.Exists("/Data/HandTracking.csv"))
        {
            data += DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine;

            Debug.Log(data);
            File.AppendAllText("/Data/HandTracking.csv", data);
        }
    }
}
