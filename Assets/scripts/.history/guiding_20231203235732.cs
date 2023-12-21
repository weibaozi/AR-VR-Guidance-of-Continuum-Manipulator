using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class guiding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guidingManipulator;

    public GameObject[] guidingPoints;
    void Start()
    {
        guidingManipulator = GameObject.Find("guidingManipulator");
        //find cihld called "Guiding Points" 
        var Points=GameObject.Find("Guiding Points").GetComponentsInChildren<Transform>();
        //add all child to array no matter what the name is
        guidingPoints = Points.Select(p => p.gameObject).removeAt(0).ToArray();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
