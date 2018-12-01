using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockControl : MonoBehaviour {

    public GameObject alarmClockText;
    private bool active;

    void Start()
    {
        StartCoroutine(Toggle());
    }

    IEnumerator Toggle()
    {
        if (active)
        {
            alarmClockText.SetActive(false);
            active = false;
        }
        else
        {
            alarmClockText.SetActive(true);
            active = true;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(Toggle());
    }
}
