using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public int multiplier = 1;
    public GameObject pickupEffect;

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        AudioManager.Instance.PlayPlayerAudioClip2D(0);

        //apply effect
        CharacterStats stats = player.GetComponent<CharacterStats>();
        stats.maxHealth += multiplier;
        stats.currentHealth = stats.maxHealth;
        Destroy(gameObject);
    }
}
