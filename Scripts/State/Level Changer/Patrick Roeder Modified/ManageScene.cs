using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {

    public static ManageScene instance = null;
    public int currentWarpNumber;

    public GameObject player;
    public GameObject[] warpTriggerArray;

	// Use this for initialization
	void Awake () {
		if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(warpTriggerArray.Length == 0)
        {
            warpTriggerArray = GameObject.FindGameObjectsWithTag("WarpTrigger");
        }
	}

    void OnLevelWasLoaded()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        warpTriggerArray = GameObject.FindGameObjectsWithTag("WarpTrigger");

        for(int i = 0; i < warpTriggerArray.Length; i++)
        {
            if (warpTriggerArray[i].GetComponent<Warp>().warpNumber == currentWarpNumber)
            {
                player.transform.position = warpTriggerArray[i].transform.position;
            }
        }
    }



    public void LoadScene(int passedWarpNumber, int passedNextLevelBuildIndex)
    {
        currentWarpNumber = passedWarpNumber;
        SceneManager.LoadScene(passedNextLevelBuildIndex);

    }
}
