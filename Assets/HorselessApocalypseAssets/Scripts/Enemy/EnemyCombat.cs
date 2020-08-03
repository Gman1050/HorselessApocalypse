using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour 
{

    public float attackSpeed = 1f;

    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public int enemySoundClip = 0;

    public AudioClip attackSoundClip;

    public event System.Action OnAttack;

    EnemyStats myStats;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {

        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        AudioManager.Instance.PlayEnemyAudioClip3D(audioSource, enemySoundClip);
        stats.TakeDamage(myStats.damage);
    }
}
