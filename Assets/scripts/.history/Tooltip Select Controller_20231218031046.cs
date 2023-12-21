using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public float trigger=0f;
    public AudioSource audioSource;
    void Start()
    {

        
    }

    // Update is called once per frame
   void OnTriggerEnter(Collider other){
        print("point is triggered"+other.gameObject.name);
        if (other.gameObject.CompareTag("Guiding Points"))
        {
            if (trigger > 0.5f)
            {
                other.gameObject.SetActive(false);
                audioSource.Play();
            }
        }
    }
}
