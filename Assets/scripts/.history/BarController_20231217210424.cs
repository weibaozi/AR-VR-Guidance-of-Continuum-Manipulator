using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject centerObject;

    public GameObject BarArrowObject;
    public GameObject[] radarObjects;

    public float BarRadius = 9.8f;

    public float scale = 0.5f;

    private GameObject CurrentPoint;


    // Start is called before the first frame update
    void Start()
    {
        if (centerObject == null)
        {
            centerObject = GameObject.Find("Tool");
        }
        if (BarArrowObject == null)
        {
            BarArrowObject = GameObject.Find("Bar Arrow");
        }
        var Points=GameObject.Find("Guiding Points").GetComponentsInChildren<Transform>();
        radarObjects = Points.Skip(1).Select(p => p.gameObject).ToArray();
        var firstPointLocation = radarObjects[0].transform.position;
        Vector3 relativePosition = centerObject.transform.InverseTransformPoint(radarObjects[0].transform.position);
        print("relative position is " + relativePosition);
        //constrain the relative position to a circle(less than radarRadius)
        if (relativePosition.magnitude > BarRadius)
        {
            relativePosition = relativePosition.normalized * BarRadius;
        }

        // Vector3 radarPointLocation = new Vector3(-relativePosition.x, relativePosition.z,0 );
        Vector3 radarPointLocation = new Vector3(relativePosition.x, 0,0 );
        BarArrowObject.transform.localPosition = radarPointLocation;


        
    }
    void FixedUpdate(){
        var activePoints = radarObjects.Where(p => p.activeSelf);
        //number
        if (activePoints.Count() == 0)
        {
            // Debug.Log("No guiding points found");
            CurrentPoint=null;
        }
        else
        {
            CurrentPoint=activePoints.FirstOrDefault();
            // print("current point is "+CurrentPoint);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //find first active point
        var activePoints = radarObjects.Where(p => p.activeSelf);
        if (CurrentPoint == null)
        {
            // Debug.Log("No guiding points found");
        }
        else
        {
            float relativePositionX = centerObject.transform.InverseTransformPoint(CurrentPoint.transform.position).x;
            //times scale
            relativePositionX = relativePositionX * scale;
            //if x abs is larger than BarRadius, then set it to BarRadius
            if (Mathf.Abs(relativePositionX) > BarRadius)
            {
                relativePositionX = relativePositionX > 0 ? BarRadius : -BarRadius;
            }
            Vector3 radarPointLocation = new Vector3(relativePositionX, 0,0 );
            BarArrowObject.transform.localPosition = radarPointLocation;
        }
    }
}
