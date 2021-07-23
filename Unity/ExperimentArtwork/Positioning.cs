using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    //private GameObject arrow; // Assign a prefab to this in the inspector

    //[SerializeField]
    //private Transform arrowPosition; // grab objects's position

    void Start()
    {
        //Debug.Log(gameObject.transform.position);

        //InstantiateObject();
        Debug.Log(gameObject.transform.localPosition.x+"  -  "+ gameObject.transform.localPosition.y+"     "+ gameObject.transform.localPosition.z);
    }

    //private void InstantiateObject()
    //{
    //    GameObject arrowPrefab = Instantiate(arrow) as GameObject; // creating a local game object to store the    instantiated object and then casting it to a Gamebject

    //    arrowPrefab.name = "Arrow"; // Setting prefab name in hierarchy
    //    arrowPrefab.transform.position = new Vector3(arrowPosition.position.x, arrowPosition.position.y, arrowPosition.position.z); // Setting the position of the prefab to "arrowPosition"
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
