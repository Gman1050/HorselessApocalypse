using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASPickUp : MonoBehaviour {

    public float multiplier = .05f;
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
        CharacterCombat stats = player.GetComponent<CharacterCombat>();
        //apply effect
        while (stats.attackSpeed >= .1f)
        { 
            stats.attackSpeed -= multiplier;
        }
        
        Destroy(gameObject);
    }
}
