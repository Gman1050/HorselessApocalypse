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

    public bool IsDead { get; private set; }

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
        //anim.SetBool("IsDamaged", true);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        //anim.SetBool("IsDamaged", false);


        if (currentHealth <= 0)
        {
            if (!IsDead)
            {
                AudioManager.Instance.PlayEnemyAudioClip3D(GetComponent<AudioSource>(), 0);
                IsDead = true;
            }
        }
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
