using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    public GameObject actionDisplay;
    public GameObject door;
    public RaycastHit hit;
    public GameObject actionText;
    public GameObject playerCamera;
    public static bool isOpen = true;
    public bool displayIsOpen;
    public GameObject DoorHinge;
    //public AudioSource doorMove;

    void Update()
    {
        displayIsOpen = isOpen;
        hit = PlayerCasting.hit;
        if(Physics.Raycast(playerCamera.transform.position,
        playerCamera.transform.TransformDirection(Vector3.forward),
        out hit)){
            if (hit.distance <= 3.0 &&
                hit.collider.gameObject.tag == "interactable" &&
                isOpen == false)
            {
                actionText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isOpen = true;
                    actionText.SetActive(false);
                    DoorHinge.GetComponent<Animation>().Play("DoorOpenAnim");
                    //play open sound
                }
            }
            else
            {
                actionText.SetActive(false);
            }
        }
    }
}
