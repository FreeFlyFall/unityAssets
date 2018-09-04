using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For health of an object
public class Target : MonoBehaviour {

    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
