using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackspeedPU : MonoBehaviour {


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

        //apply effect
        CharacterCombat stats = player.GetComponent<CharacterCombat>();
        while(stats.attackSpeed >= .2f)
        {
            stats.attackSpeed -= multiplier;
        }
        

        Destroy(gameObject);
    }
}
