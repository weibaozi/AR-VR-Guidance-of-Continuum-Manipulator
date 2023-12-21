using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter(Collider other){
        print("point is triggered"+other.gameObject.name);
        if (other.gameObject.CompareTag("Guiding Point"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
