using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plays animation, and sound with a delay
public class JumpTrigger : MonoBehaviour {

    public AudioSource DoorBang;
    public AudioSource JumpTune;
    public GameObject Zombie;
    public GameObject Door;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        Door.GetComponent<Animation>().Play("JumpDoor");
        DoorBang.Play();
        Zombie.SetActive(true);
        StartCoroutine(PlayJumpTune());
    }

    IEnumerator PlayJumpTune()
    {
        yield return new WaitForSeconds(0.4f);
        JumpTune.Play();
    }


}
