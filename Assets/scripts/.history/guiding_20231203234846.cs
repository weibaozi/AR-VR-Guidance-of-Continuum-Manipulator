using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guidingManipulator;

    public GameObject[] guidingPoints;
    void Start()
    {
        guidingManipulator = GameObject.Find("guidingManipulator");
        //find cihld called "Guiding Points" 
        guidingPoints=GameObject.Find("Guiding Points").GetComponentsInChildren<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
