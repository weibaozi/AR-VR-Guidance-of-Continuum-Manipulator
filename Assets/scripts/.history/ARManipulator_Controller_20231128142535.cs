using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class ARManipulator_Controller : MonoBehaviour
{
    public InputActionReference primaryButtonInputActionReference;

    public InputActionReference secondaryButtonInputActionReference;
    public float speed = 0;
    public float bentSpeed = 0;

    private Rigidbody rb;
    //private float rotationZ;
    private float movementX;
    private float movementY;
    private float primaryButton;
    private float secondaryButton;
    private float rotationZ;
    [SerializeField] private GameObject[] LinkObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        var children = GetComponentsInChildren<Transform>();


        LinkObjects = System.Array.FindAll(children, p =>
        {
            return p.gameObject.name.Contains("Link");
        }).Select(p => p.gameObject).ToArray();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = -movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
        //print primarybuttong value
        primaryButton= primaryButtonInputActionReference.action.ReadValue<float>();
        secondaryButton = secondaryButtonInputActionReference.action.ReadValue<float>();
        // print(primaryButton);
        // print(secondaryButton);
        Vector3 movement = new Vector3(0.0f, secondaryButton, 0.0f);
        // rb.angularVelocity = movement * speed;
        //rotationz is 1 if primary -1 if secondary
        rotationZ = primaryButton - secondaryButton;
        foreach (var link in LinkObjects) {
            link.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ * bentSpeed));
        }

        
    }
}
