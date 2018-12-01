using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : MonoBehaviour
{

    public GameObject towerLight;
    //Don't place script on light or will deactivate.

    void Start()
    {
        StartCoroutine(ToggleTowerLight());
    }

    IEnumerator ToggleTowerLight()
    {
        towerLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.15f);
        towerLight.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        towerLight.SetActive(true);
        yield return new WaitForSecondsRealtime(0.15f);
        towerLight.SetActive(false);
        yield return new WaitForSecondsRealtime(3.0f);
        StartCoroutine(ToggleTowerLight());
    }
}
