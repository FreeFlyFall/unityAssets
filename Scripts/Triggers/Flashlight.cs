using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* In Progress
    For setup of flashlight with sound,
    intensity variation, and battery count/level */
public class Flashlight : MonoBehaviour {

    public GameObject lightAsObject;
    public float energy;
    private float maxEnergy = 100f;
    public int numBatteries;
    private bool isEnabled = true;
    public AudioSource ClickOn;
    public AudioSource ClickOff;
    public AudioSource Recharge;
    public Light light;
    public Text batteryDisplay;


    void Start ()
    {
        energy = maxEnergy;
        numBatteries = 3;
	}
	
	void Update ()
    {
        // Set up Battery UI
        batteryDisplay.text = "Batteries (Q): " + numBatteries;
        // Turn on & off with sound
        ToggleLight();
        
        // Handle battery level effects
        /// should be replaced with animations for smooth transitions or other effects
        if (isEnabled)
        {
            DrainBattery();
            ComputeLightStatus();
        }
        // Handle battery reloading
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ReloadBatteries();
        }
        // For manually incrementing battery level
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    ++numBatteries;
        //}
    }

    public void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEnabled = !isEnabled;
            if (isEnabled)
            {
                ClickOn.Play();
                StartCoroutine(WaitTimeForClick());
            }
            else
            {
                ClickOff.Play();
                StartCoroutine(WaitTimeForClick());
            }
        }
    }

    public void DrainBattery()
    {
        if (energy > 0)
        {
            energy -= Time.deltaTime / 3f;
        }
    }

    public void ComputeLightStatus()
    {
        if (energy >= 50f)
        {
            light.intensity = 1.5f;
            light.range = 150f;
        } 
        else if (energy >= 25f)
        {
            light.intensity = 1f;
            light.range = 105f;
        }
        else if (energy >= 0f)
        {
            light.intensity = 0.5f;
            light.range = 50f;
        }
    }

    public void ReloadBatteries()
    {
        if (energy <= 50 && numBatteries > 0)
        {
            Recharge.Play();
            --numBatteries;
            energy = 100f;
        }
    }

    IEnumerator WaitTimeForClick()
    {
        yield return new WaitForSeconds(0.35f);
        if (isEnabled)
        {
            lightAsObject.SetActive(true);
        }
        else
        {
            lightAsObject.SetActive(false);
        }
    }
}
