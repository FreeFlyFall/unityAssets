using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton example using player object
public class PlayerManager : MonoBehaviour {
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
