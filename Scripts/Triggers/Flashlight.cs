using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In Progress
// For setup of flashlight with sound
// Delay for feedback(switches light bool on second click of button sound)
public class Flashlight : MonoBehaviour {

    public GameObject flashlight;
    // public float maxEnergy;
    // private float currentEnergy;
    private bool isEnabled = true;
    public AudioSource ClickOn;
    public AudioSource ClickOff;

	void Update ()
    {
        //equip
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEnabled = !isEnabled;
            if (isEnabled)
            {
                StartCoroutine(WaitTimeForClick());
                ClickOn.Play();
            }
            else
            {
                ClickOff.Play();
                StartCoroutine(WaitTimeForClick());
            }
        }
	}

    IEnumerator WaitTimeForClick()
    {
        yield return new WaitForSeconds(0.35f);
        if (isEnabled)
        {
            flashlight.SetActive(true);
        }
        else
        {
            flashlight.SetActive(false);
        }
    }
}
