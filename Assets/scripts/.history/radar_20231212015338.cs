using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class radar : MonoBehaviour
{
    public GameObject centerObject;

    public GameObject radarPointObject;
    public GameObject[] radarObjects;

    public float radarRadius = 6f;

    private GameObject CurrentPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (centerObject == null)
        {
            centerObject = GameObject.Find("Snake Base");
        }
        if (radarPointObject == null)
        {
            radarPointObject = GameObject.Find("radar point");
        }
        var Points=GameObject.Find("Guiding Points").GetComponentsInChildren<Transform>();
        radarObjects = Points.Skip(1).Select(p => p.gameObject).ToArray();
        var firstPointLocation = radarObjects[0].transform.position;
        Vector3 relativePosition = centerObject.transform.InverseTransformPoint(radarObjects[0].transform.position);
        print("relative position is " + relativePosition);
        //constrain the relative position to a circle(less than radarRadius)
        if (relativePosition.magnitude > radarRadius)
        {
            relativePosition = relativePosition.normalized * radarRadius;
        }

        Vector3 radarPointLocation = new Vector3(-relativePosition.x, relativePosition.z,0 );
        radarPointObject.transform.localPosition = radarPointLocation;

        
    }
    void FixedUpdate(){
        var activePoints = radarObjects.Where(p => p.activeSelf);
        if (activePoints.Count() == 0)
        {
            // Debug.Log("No guiding points found");
            CurrentPoint=null;
        }
        else
        {
            CurrentPoint=activePoints.FirstOrDefault();
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
            var firstPointLocation = CurrentPoint.transform.position;
            Vector3 relativePosition = centerObject.transform.InverseTransformPoint(radarObjects[0].transform.position);
            //constrain the relative position to a circle(less than radarRadius)
            if (relativePosition.magnitude > radarRadius)
            {
                relativePosition = relativePosition.normalized * radarRadius;
            }
            Vector3 radarPointLocation = new Vector3(-relativePosition.x, relativePosition.z,0 );
            radarPointObject.transform.localPosition = radarPointLocation;
        }
    }
}
