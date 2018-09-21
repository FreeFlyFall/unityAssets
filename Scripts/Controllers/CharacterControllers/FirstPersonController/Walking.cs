using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

    public GameObject PlayerCamera;
    private bool isWalking;
    private string anim;

    // Change to unity's input axes horizontal and vertical
	void Update () {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayerCamera.GetComponent<Animation>().Play("RunningAnim");
            }
            else
            {
                PlayerCamera.GetComponent<Animation>().Play("WalkingAnim");
            }
        }

        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D))
        {
            PlayerCamera.GetComponent<Animation>().Stop("WalkingAnim");
            PlayerCamera.GetComponent<Animation>().Stop("RunningAnim");
        }
	}
}
