using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guidingManipulator;
    void Start()
    {
        guidingManipulator = GameObject.Find("guidingManipulator");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
