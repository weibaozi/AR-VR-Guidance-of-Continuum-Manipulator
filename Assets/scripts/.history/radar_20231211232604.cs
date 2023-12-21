using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radar : MonoBehaviour
{
    public GameObject centerObject;
    public GameObject[] radarObjects;

    public float radarRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (centerObject == null)
        {
            centerObject = GameObject.Find("Snake Base");
        }
        // var children = GetComponentsInChildren<Transform>();
        // radarObjects = System.Array.FindAll(children, p =>
        // {
        //     return p.gameObject.name.Contains("radar");
        // }).Select(p => p.gameObject).ToArray();
        // if (radarObjects.Length == 0)
        // {
        //     Debug.Log("No radar objects found");
        // }
        // else
        // {
        //     Debug.Log("radar objects found");
        //     foreach (var radarObject in radarObjects)
        //     {
        //         var radarObjectLocation = radarObject.transform.position;
        //         var startlocation = centerObject.transform.position;
        //         print("radar object location is " + radarObjectLocation + "start location is " + startlocation);
        //         Vector3 directionToTarget = radarObjectLocation - startlocation;
        //         print("direction to target is " + directionToTarget);
        //         Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        //         targetRotation = Quaternion.Euler(270, 0, 0) * targetRotation;
        //         // transform.rotation = targetRotation;
        //         print("rotation is " + targetRotation);
        //         //print rotation in euler angle
        //         print("rotation in euler angle is " + targetRotation.eulerAngles);
        //         //apply rotation to guiding manipulator
        //         radarObject.transform.rotation = targetRotation;
        //     }
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
