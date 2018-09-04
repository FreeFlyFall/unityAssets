using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for firing a gun with animation
// Set to 0.5 sec or less
public class FirePistol : MonoBehaviour {
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool IsFiring;
    public float TargetDistance;
    public int DamageAmount = 5;

	void Update () {
        //TargetDistance = PlayerCasting.DistanceFromTarget;
        if (Input.GetButtonDown("Fire1"))
        {
            if(IsFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }
	}

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        IsFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;

            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleFlashanim");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
