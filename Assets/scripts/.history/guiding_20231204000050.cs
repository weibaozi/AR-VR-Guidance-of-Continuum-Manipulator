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
        guidingPoints = Points.Skip(1).Select(p => p.gameObject).ToArray();
        if (guidingPoints.Length == 0)
        {
            Debug.Log("No guiding points found");
        }
        else
        {
            Debug.Log("guiding points found");
            var startPointLocation = guidingPoints[0].transform.position;
            var startlocation = GameObject.Find("Drill Point").transform.position;
            print("start point location is " + startPointLocation + "start location is " + startlocation);
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
