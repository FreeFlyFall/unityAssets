using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to a camera which is the child of the player object
// Set Position Y to "0.9"
// Set Field of View to "90" or desired amount
// Set Clipping Planes Near value to 0.1
// Set Mouse X Input Name to "Mouse X"
// Set Mouse Y Input Name to "Mouse Y"
// Set Mouse Sensitivity  to "100"
// Set Player Body to the player object which the camera is a child of

public class PlayerLookScript : MonoBehaviour {

    [SerializeField] private string mouseXInputName;
    [SerializeField] private string mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    private float xAxisClamp;

	// Use this for initialization
	void Start() {
        ///////////
	}
    
    
    private void Awake()
    { 
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	
	void Update ()
    {
        CameraRotation();
    }

    public void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
