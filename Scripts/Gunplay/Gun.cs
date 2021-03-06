﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public Camera fpsCam;
    public Text AmmoDisplay;

    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private float impactForce = 100f;

    public float fireRate = 10f;
    private float nextTimeToFire = 0f;

    public AudioSource gunSound;
    public AudioSource emptyFire;
    public AudioSource reload;

    public int reserveAmmo;
    public int clipAmmo;
    private bool reloadPause;
    private readonly int clipAmmoLimit = 30;
    private readonly int reserveAmmoLimit = 120;

    void Start()
    {
        reserveAmmo = reserveAmmoLimit;
        clipAmmo = clipAmmoLimit;
    }

	void Update () {
        // isPaused bool from GamePause.cs
        if(GamePause.isPaused == false)
        {
            // For automatic shots. remove second conditional, use GetButtonDown,
            // and keep only the shoot method in the conditional body for semi-auto
            if(Input.GetButton("Fire1") &&
                Time.time >= nextTimeToFire &&
                clipAmmo > 0 &&
                reloadPause != true)
            {
                //Since dividing, greater fire rate means less shot delay
                nextTimeToFire = (Time.time + 1f / fireRate);
                Shoot();
            }
            // Empty Fire
            else if(Input.GetButton("Fire1") &&
                Time.time >= nextTimeToFire &&
                reloadPause != true)
            {
                nextTimeToFire = (Time.time + 1f / fireRate);
                FindObjectOfType<AudioManager>().Play("EmptyFire");
            }
            //Reload
            if (Input.GetKeyDown(KeyCode.R) &&
                reserveAmmo > 0 &&
                clipAmmo < clipAmmoLimit &&
                reloadPause != true)
            {
                StartCoroutine(Reload());
            }
            // Refresh ammo display
            AmmoDisplay.text = clipAmmo + " / " + reserveAmmo;
        }
    }

    IEnumerator Reload()
    {
        // Change condition to stop the dependents
        reloadPause = true;
        FindObjectOfType<AudioManager>().Play("Reload");
        // 3 seconds from audio clip length
        yield return new WaitForSeconds(3);
        reloadPause = false;

    ///Reload Logic
        /* Take the value of the ammo that has been used from the clip
            And subtract it from the total ammo
            if the total ammo is below zero, it now represents the
            deficit of ammo for the final clip
            Could also be written like this after
            declaring the local variable for the used ammo:
            // usedAmmo = clipAmmoLimit - clipAmmo;
            // reserveAmmo -= usedAmmo; */
        reserveAmmo -= clipAmmoLimit - clipAmmo;
        // If the total ammo is above zero after accounting
        // for the clip space, there's no deficit, so fill it to the limit
        if(reserveAmmo >= 0)
        {
            clipAmmo = clipAmmoLimit;
        }
        // However, if the total ammo is below zero after accounting for the deficit,
        // there's not enough ammo to fill the clip
        else if(reserveAmmo < 0)
        {
            /* Use the deficit value to establish the ammo value in the final clip
                Could be written like this after declaring a local variable for the deficit
                for ease of understanding, since it's effectively adding a negative
                    //deficit = 0 - reserveAmmo;
                    //clipAmmo = clipAmmoLimit - deficit; */
            clipAmmo = clipAmmoLimit + reserveAmmo;
            // Reset the reserveAmmo to zero so the display doesn't show the negative value
            reserveAmmo = 0;
        }
    }

    void Shoot()
    {
        // Play muzzle flash attached to gun
        muzzleFlash.Play();
        //gunSound.Play();
        FindObjectOfType<AudioManager>().Play("GunFire");
        --clipAmmo;

        // Create a Raycast from the camera, forwards, named hit, with the range var
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // If it hits, tell what was hit, pass damage to
            // the takeDamage method from target.cs
            Debug.Log(hit.transform.name);
            TargetHealth target = hit.transform.GetComponent<TargetHealth>();
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
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
