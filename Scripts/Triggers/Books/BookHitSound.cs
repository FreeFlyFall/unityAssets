using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHitSound : MonoBehaviour {

    public AudioSource bookSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision col)
    {
        if(col.relativeVelocity.magnitude >= 2)
        {
            //magnitude most likely will never register over 20, so divide mag by 20
            // to get a value for volume of the sound to play that is less than 1;
            bookSound.volume = col.relativeVelocity.magnitude / 20;
            //Debug.Log(col.relativeVelocity.magnitude);
            bookSound.Play();
            Debug.Log("Played");
        } 
    }
}
