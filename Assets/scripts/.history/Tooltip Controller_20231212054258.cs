using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipController : MonoBehaviour
{
    // Start is called before the first frame update
    public float trigger=0f;

    public TextMeshProUGUI pointCountText;

    public AudioSource audioSource;

    public int pointCount=0;
    void Start()
    {
        //get from parent
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
