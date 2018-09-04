using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for calling different animations of a pointlight
public class FlameAnimation : MonoBehaviour {

    public int LightMode;
    public GameObject FlameLight;

	void Start () {

	}

	void Update () {
		if (LightMode == 0)
        {
            StartCoroutine (AnimateLight());
        }
	}

    IEnumerator AnimateLight()
    {
        LightMode = Random.Range(1, 4);
        if(LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("torchAnim1");
        } else if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("torchAnim2");
        } else if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("torchAnim3");
        }
        yield return new WaitForSeconds(0.99f);
        LightMode = 0;
    }
}
