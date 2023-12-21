using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    // Start is called before the first frame update
    private float trigger;
    void Start()
    {
        //get from parent
        trigger = transform.parent.GetComponent<ARManipulator_Controller>().trigger;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        print("point is triggered"+other.gameObject.name);
        if (other.gameObject.CompareTag("Guiding Points"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
