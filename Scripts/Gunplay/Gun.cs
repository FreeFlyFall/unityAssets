using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//General gun behaviour script
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 100f;
    public float fireRate = 8f;
    public float nextTimeToFire = 0f;

	void Update ()
    {
        // For automatic shots. remove second conditional, use GetButtonDown,
        // and keep only the shoot method in the conditional body for semi-auto
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            //Since dividing, greater fire rate means less shot delay
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}
    void Shoot()
    {
        // Play muzzle flash attached to gun
        muzzleFlash.Play();

        // Create a Raycast from the camera, forwards, named hit, with the range var
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // If it hits, tell what was hit, pass damage to
            // the takeDamage method from target.cs
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // If a rigidbody was hit, add a force to it.
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            // Add the impact effect where the raycast impacts, and destroy
            // the effect after 2 seconds.
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
