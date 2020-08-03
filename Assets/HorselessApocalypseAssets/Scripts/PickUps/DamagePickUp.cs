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
        AudioManager.Instance.PlayPlayerAudioClip2D(1);

        //apply effect
        Attacks stats = player.GetComponent<Attacks>();
        stats.basicAttackDamage += multiplier;

        Destroy(gameObject);
    }
}
