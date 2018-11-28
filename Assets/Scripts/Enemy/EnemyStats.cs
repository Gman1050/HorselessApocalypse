using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private Animator anim;

    public Stats damage;

    public int maxHealth;

    public int currentHealth
    {
        get;
        private set;
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        CurrentHealthBoundaries();
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("IsDamaged", true);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        anim.SetBool("IsDamaged", false);


        if (currentHealth <= 0)
        {
            
            Die();

        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This is meant to be overwritten
        Debug.Log(transform.name + " died.");
        anim.SetBool("IsDead", true);
        Destroy(gameObject);
    }

    private void CurrentHealthBoundaries()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
