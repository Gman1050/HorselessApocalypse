using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public string characterName;
    public Image characterImage;
    public Stats damage;

    public int maxHealth;

    public int currentHealth
    {
        get;
        set;
    }

    void Awake()
    {
        currentHealth = maxHealth;
        currentSpecialTimer = maxSpecialTimer;

        GameManager.Instance.LoadPlayerData(playerOrder, this);   // Always have this in awake to set the player data before game begins
    }



    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        // Die in some way
        // This is meant to be overwritten
        Debug.Log(transform.name + " died.");
        Destroy(gameObject);
    }

}
