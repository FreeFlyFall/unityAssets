using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// In Progress
// Shows text when looking at an object and handles interaction
public class DoorCellOpen : MonoBehaviour {

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    public GameObject ActionCursor;

	void Update () {
        TheDistance = PlayerCasting.DistanceFromTarget;
	}

    void OnMouseOver()
    {
        // Needs consideration for distance when backing up
        // At the moment, shows up after being close enough forever
        // as long as mouseover is true
        if(TheDistance <= 2)
        {
            ActionCursor.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("doorOpenAnim");
                CreakSound.Play();
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
