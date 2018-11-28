using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : MonoBehaviour {

    public int multiplier = 1;
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply effect
        CharacterStats stats = player.GetComponent<CharacterStats>();
        stats.damage += multiplier;
        
        Destroy(gameObject);
    }
}

