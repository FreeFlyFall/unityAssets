using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWoodsLevel : MonoBehaviour {

    public GameObject loadWoodsLevelTrigger;
    public Collider loadWoodsLevelTriggerCollider;
    
    void Start()
    {
        loadWoodsLevelTriggerCollider = loadWoodsLevelTrigger.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider loadWoodsLevelTriggerCollider)
    {
        SceneManager.LoadScene(2);
    }
}
