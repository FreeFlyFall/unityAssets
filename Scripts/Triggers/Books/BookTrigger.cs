using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour {

    public Rigidbody[] books;
    public GameObject bookThrowTrigger;
    public Collider bookThrowTriggerCollider;


    void Start()
    {
        //add rigidbodies of the book objects to the books array
        // array not created yet. in progress
        bookThrowTriggerCollider = bookThrowTrigger.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider bookThrowTriggerCollider)
    {
        //Play cabinet hit sound
        for (int i = 0; i < books.Length; i++)
        {
            var forceValue = Random.Range(200, 801);
            books[i].AddForce(-transform.forward * forceValue);
            Debug.Log(forceValue);
        }
        bookThrowTrigger.SetActive(false);
    }
}
