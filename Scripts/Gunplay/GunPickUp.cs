using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handles gun pickup logic, text display upon pickup
// and activates a trigger
public class GunPickUp : MonoBehaviour {

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject ActionCursor;
    public GameObject TheJumpTrigger;


	void Update () {
        TheDistance = PlayerCasting.DistanceFromTarget;
	}

    void OnMouseOver()
    {
        if(TheDistance <= 4)
        {
            ActionCursor.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                ActionCursor.SetActive(false);
                TheJumpTrigger.SetActive(true);
            }
        }
    }
    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ActionCursor.SetActive(false);
    }
}