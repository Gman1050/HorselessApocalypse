using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    private Animator anim;

    public int damage;

    public int maxHealth;

    public int currentHealth
    {
        get;
        set;
    }

    private bool isLevelEnd = false;

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
            Die();

        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This is meant to be overwritten
        Debug.Log(transform.name + " died.");
        anim.SetBool("IsDead", true);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<BossOne>().enabled = false;
        StartCoroutine(Die(1.0f));
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

    private IEnumerator Die(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(EndLevel(3.0f));
    }

    private IEnumerator EndLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.ChangeScene("Main Menu");
    }
}
