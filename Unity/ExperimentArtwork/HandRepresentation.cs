using Leap;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRepresentation : MonoBehaviour
{
    public     GameObject hand;
    public List<GameObject> fingers;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Controller controller = new Controller();
        Frame frame = controller.Frame(); // controller is a Controller object
        string data = "+++";
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
         
            // Hand firstHand = hands[0];
            foreach (Hand h in hands)
            {
                hand.transform.position =getVector( h.Direction);
             List <Finger> fings = h.Fingers;

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
                data += h.PalmVelocity.x + ",";
                data += h.PalmVelocity.y + ",";
                data += h.PalmVelocity.z + ",";
                data += h.IsRight + ",";
                int i = 0;
                foreach (Finger F in fings)
                {
                    fingers[i].transform.position = getVector(F.Direction);
//                    fingers[i++].transform.rotation= getVector(F.Direction);

                    data += F.TipPosition.x + ",";
                    data += F.TipPosition.y + ",";
                    data += F.TipPosition.z + ",";
                    data += F.Direction.x + ",";
                    data += F.Direction.y + ",";
                    data += F.Direction.z + ",";

                    Bone[] bones = F.bones;
                    int j = 0;
                    foreach (Bone b in bones)
                    {
                        Debug.Log("-"+j);
                        if (fingers[i].transform.childCount <= j) continue;
                        fingers[i].transform.GetChild(j++).gameObject.transform.position = getVector(b.Direction);
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
                    i++;
                }
            }
        }
        Debug.Log(data);
    }

    private Vector3 getVector(Vector direction)
    {
        if (direction == null) return new Vector3();
        Vector3 v = new Vector3(direction.x, direction.y, direction.z);
        return v;
    }
}
