using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TooltipSelectController : MonoBehaviour
{
    // Start is called before the first frame update
     public InputActionReference triggerInputActionReference;
    public AudioSource audioSource;

    private float trigger = 0f;
    void Start()
    {

        
    }

    void Update()
    {
        trigger = triggerInputActionReference.action.ReadValue<float>();
    }

    // Update is called once per frame
   void OnTriggerEnter(Collider other){
        
        if (other.gameObject.CompareTag("Level Selector"))
        {
            if (trigger > 0.5f)
            {
                audioSource.Play();
                print("point is triggered "+other.gameObject.name);
            }
        }
    }
}
