using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class TooltipSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference triggerInputActionReference;
    public AudioSource audioSource;
    //scenemanager
    [SerializedField] public string sceneName;

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
                // print("point is triggered "+other.gameObject.name);
                if (other.gameObject.name == "EASY")
                {
                    // print("easy");
                }
                if (other.gameObject.name == "HARD")
                {
                    // print("medium");
                }
                if (other.gameObject.name == "VERY HARD")
                {
                    // print("hard");
                }
            }
        }
    }
}
