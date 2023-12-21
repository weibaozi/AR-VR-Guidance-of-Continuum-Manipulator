using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 originalPosition;

    public InputActionReference resetInputActionReference;
    void Start()
    {
        originalPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float reset = resetInputActionReference.action.ReadValue<float>();
        if (reset > 0.5f)
        {
            transform.position = originalPosition;
        }
        
    }
}
