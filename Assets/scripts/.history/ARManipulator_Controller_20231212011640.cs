using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class ARManipulator_Controller : MonoBehaviour
{
    public InputActionReference primaryButtonInputActionReference;

    public InputActionReference secondaryButtonInputActionReference;

    //joy stick
    public InputActionReference joystickInputActionReference;
    public float rotationSpeed = 5f;
    public float bentSpeed = 0.1f;

    public float maxAngel = 3f;
    public float trigger;
    // private Rigidbody rb;
    //private float rotationZ;
    private float movementX;
    private float movementY;
    private float primaryButton;
    private float secondaryButton;
    private float rotationZ;

    private float rotationX;
    private float rotationY;
    [SerializeField] private GameObject[] LinkObjects;

    private GameObject baseObject;
    
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        //get self 
        baseObject = gameObject;

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
        rotationX = joystickInputActionReference.action.ReadValue<Vector2>().x;
        rotationY = joystickInputActionReference.action.ReadValue<Vector2>().y;
        //add deadzone for rotationX, and only enable when rotation X is smaller than rotationY
        if ((rotationX < 0.01 && rotationX > -0.01) || (Mathf.Abs(rotationX) < Mathf.Abs(rotationY)))
        {
            rotationX = 0;
        }
        //add deadzone for rotationY, and only enable when rotation Y is smaller than rotationX
        if ((rotationY < 0.01 && rotationY > -0.01) || (Mathf.Abs(rotationY) < Mathf.Abs(rotationX)))
        {
            rotationY = 0;
        }

        // baseObject.transform.Rotate(new Vector3(0.0f, rotationY*rotationSpeed, 0.0f));
        foreach (var link in LinkObjects) {
            if(Mathf.Abs(180-link.transform.localRotation.eulerAngles.z) > (180-maxAngel))
            {
                link.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationX * bentSpeed));
            }
            //if angel is less than 10 degree and rotation is positive
            
            if ( (link.transform.localRotation.eulerAngles.z >maxAngel) && (link.transform.localRotation.eulerAngles.z < 180)) 
            {
                if ( -rotationX < 0)
                {
                    link.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationX * bentSpeed));
                }
                
            }else if( (link.transform.localRotation.eulerAngles.z < (360-maxAngel)) && (link.transform.localRotation.eulerAngles.z > 180 ))
            {
                if (-rotationX > 0)
                {
                    link.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationX * bentSpeed));
                }
            }else{
                link.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationX * bentSpeed));
            }
        }

        
    }
    void OnTriggerEnter(Collider other){
        print("point is triggered"+other.gameObject.name);
        if (other.gameObject.CompareTag("Guiding Point"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
