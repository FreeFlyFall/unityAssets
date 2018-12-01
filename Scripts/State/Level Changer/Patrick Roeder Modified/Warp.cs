using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public int warpNumber;
    public int nextLevelBuildIndex;
    public GameObject actionText;

	void OnTriggerStay()
    {
        //actionText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Pass the warpNumber and nextLevelBuildIndex to the scene manager script
            ManageScene.instance.LoadScene(warpNumber, nextLevelBuildIndex);
        }
    }

    void OnTriggerExit()
    {
        //actionText.SetActive(false);
    }
}
