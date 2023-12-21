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
            var firstPointLocation = guidingPoints[0].transform.position;
            var startlocation = GameObject.Find("Drill Point").transform.position;
            print("1st point location is " + firstPointLocation + "start location is " + startlocation);
            Vector3 directionToTarget = startlocation - firstPointLocation;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
            transform.rotation = targetRotation;
            print("rotation is " + transform.rotation);
            //apply rotation to guiding manipulator
            // guidingManipulator.transform.rotation = targetRotation;
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
