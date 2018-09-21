using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {
    public static float distanceFromTarget;
    public float toTarget;
    public static RaycastHit hit;

    //public GameObject actionText;
	
	// Update is called once per frame
	void Update () {
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)){
            toTarget = hit.distance;
            distanceFromTarget = toTarget;

        }
	}
}