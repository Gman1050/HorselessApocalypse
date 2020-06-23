using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private Animator anim;

    public int damage;

    public int maxHealth;

    public RepawnEnemy respawnPoint;
    

    public int currentHealth
    {
        get;
        set;
    }

    public GameObject[] dropitems;

    float droprate = 0.25f;

    void Awake()
    {
        anim = GetComponent<Animator>();
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
            DropItem();
            Die();

        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This is meant to be overwritten
        Debug.Log(transform.name + " died.");
        anim.SetBool("IsDead", true);
        respawnPoint.Respawn();
        //if (respawnPoint.numberofRespawns == 0)
        //{ Destroy(gameObject, 2f); }
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

    public void DropItem()
    {
        if (Random.Range(0f, 1f) <= droprate)
        {
            int indexToDrop = Random.Range(0, dropitems.Length);
            Instantiate(dropitems[indexToDrop], this.transform.position + new Vector3(0f, 2f, 0f), this.transform.rotation);
        }
    }
}



