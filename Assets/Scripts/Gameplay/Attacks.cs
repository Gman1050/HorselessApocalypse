using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public SpecialAttacks special;
    public LayerMask layer;
    
    [Header("Basic Attack Settings: ")]
    [Range(0, 5)] public float basicAttackRange = 3.0f;
    [Range(0, 5)] public float basicAttackInterval = 1.0f;
    [Range(0, 5)] public int basicAttackDamage = 1;
    public SphereCollider basicAttack;
    public GameObject basicAttackParticle;

    [Header("Pestilence Attack Settings: ")]
    [Range(0, 5)] public float pestilenceAttackRange = 3.0f;
    [Range(0, 5)] public float pestilenceAttackInterval = 5.0f;
    [Range(0, 15)] public float pestilenceAttackSpeed = 15.0f;
    [Range(0, 15)] public int pestilenceAttackDamage = 15;
    public SphereCollider pestilenceAttack;
    public GameObject pestilenceParticlePart1, pestilenceParticlePart2;

    [Header("War Attack Settings: ")]
    [Range(0, 20)] public float warAttackRange = 3.0f;
    [Range(0, 5)] public float warAttackInterval = 5.0f;
    [Range(0, 15)] public int warAttackDamage = 15;
    public SphereCollider warAttack;
    public GameObject warParticle;

    [Header("Famine Attack Settings: ")]
    [Range(0, 5)] public float famineAttackRange = 3.0f;
    [Range(0, 5)] public float famineAttackInterval = 5.0f;
    [Range(0, 15)] public int famineAttackDamage = 15;
    public SphereCollider famineAttack;
    public GameObject famineParticle;

    [Header("Death Attack Settings: ")]
    [Range(0, 5)] public float deathAttackInterval = 5.0f;
    [Range(0, 15)] public int deathAttackDamage = 15;
    public BoxCollider deathAttack;
    public GameObject deathParticle;
    
    private float timer = 0.0f;
    private bool isAttacking = false, isSpecialAttacking = false;

    public bool IsSpecialAttack { get { return isSpecialAttacking; } }
    public SpecialAttacks Special { get { return special; } set { special = value; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackAction();

    }

    private void AttackAction()
    {
        BasicAttack();

        switch (special)
        {
            case SpecialAttacks.NONE:
                break;
            case SpecialAttacks.PESTILENCE:
                PestilenceAttack();
                break;
            case SpecialAttacks.WAR:
                WarAttack();
                break;
            case SpecialAttacks.FAMINE:
                FamineAttack();
                break;
            case SpecialAttacks.DEATH:
                DeathAttack();
                break;
        }
    }

    private void BasicAttack()
    {
        Collider[] hits = Physics.OverlapSphere(basicAttack.transform.position, basicAttackRange, layer);

        if (!isAttacking)
        {
            if (ControllerManager.Instance.GetAButtonDown(playerOrder))
            {
                GameObject tempParticle = Instantiate(basicAttackParticle, transform.position, transform.rotation);
                Destroy(tempParticle, basicAttackInterval);

                for (int i = 0; i < hits.Length; i++)
                {
                    hits[i].GetComponent<EnemyStats>().TakeDamage(basicAttackDamage);
                    Debug.Log(hits[i].GetComponent<EnemyStats>().currentHealth);
                }

                isAttacking = true;

                StartCoroutine(DisplayAttackRange(basicAttack.gameObject, basicAttackInterval));

            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= basicAttackInterval)
            {
                isAttacking = false;
                timer = 0.0f;
            }
        }
    }

    GameObject tempParticle1;
    bool pestilenceHit = false;

    private void PestilenceAttack()
    {
        Collider[] hits = Physics.OverlapSphere(pestilenceAttack.transform.position, pestilenceAttackRange, layer);

        if (!isSpecialAttacking)
        {
            if (GetComponent<CharacterStats>().currentSpecialTimer >= GetComponent<CharacterStats>().maxSpecialTimer)
            {
                if (ControllerManager.Instance.GetBButtonDown(playerOrder))
                {
                    pestilenceAttack.transform.parent = null;
                    isSpecialAttacking = true;
                    StartCoroutine(DisplayAttackRange(pestilenceAttack.gameObject, pestilenceAttackInterval));
                    GameObject tempParticle = Instantiate(pestilenceParticlePart1, transform.position, transform.rotation);
                    tempParticle1 = tempParticle;
                    Destroy(tempParticle, 3);

                    GetComponent<CharacterStats>().ResetSpecialTimer();
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            pestilenceAttack.transform.Translate(Vector3.forward * Time.deltaTime * pestilenceAttackSpeed);

            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i]);
                
            }

            if (timer >= pestilenceAttackInterval || hits.Length > 0)
            {
                if (hits.Length > 0 && !pestilenceHit)
                {
                    Destroy(tempParticle1);

                    // Play ring particle
                    GameObject tempParticle = Instantiate(pestilenceParticlePart2, hits[0].transform.position, transform.rotation);
                    Destroy(tempParticle, pestilenceAttackInterval - timer);
                    pestilenceHit = true;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        hits[i].GetComponent<EnemyStats>().TakeDamage(pestilenceAttackDamage);
                        Debug.Log(hits[i].GetComponent<EnemyStats>().currentHealth);
                    }
                }

                if (timer >= pestilenceAttackInterval)
                {
                    isSpecialAttacking = false;
                    pestilenceHit = false;
                    timer = 0.0f;

                    pestilenceAttack.transform.position = transform.position;
                    pestilenceAttack.transform.parent = transform;
                    pestilenceAttack.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }

            if (timer < pestilenceAttackInterval && pestilenceHit && hits.Length > 0)
            {
                pestilenceAttack.transform.position = hits[0].transform.position;
            }
        }
    }

    private void WarAttack()
    {
        Collider[] hits = Physics.OverlapSphere(warAttack.transform.position, warAttackRange, layer);

        if (!isSpecialAttacking)
        {
            if (GetComponent<CharacterStats>().currentSpecialTimer >= GetComponent<CharacterStats>().maxSpecialTimer)
            {
                if (ControllerManager.Instance.GetBButtonDown(playerOrder))
                {
                    for (int i = 0; i < hits.Length; i++)
                    {
                        hits[i].GetComponent<EnemyStats>().TakeDamage(warAttackDamage);
                        Debug.Log(hits[i].GetComponent<EnemyStats>().currentHealth);
                    }

                    isSpecialAttacking = true;

                    StartCoroutine(DisplayAttackRange(warAttack.gameObject, warAttackInterval));

                    GameObject tempParticle1 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(transform.forward));
                    Destroy(tempParticle1, warAttackInterval);

                    GameObject tempParticle2 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(-transform.forward));
                    Destroy(tempParticle2.GetComponent<AudioSource>());
                    Destroy(tempParticle2, warAttackInterval);

                    GameObject tempParticle3 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(-transform.right));
                    Destroy(tempParticle3.GetComponent<AudioSource>());
                    Destroy(tempParticle3, warAttackInterval);

                    GameObject tempParticle4 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(transform.right));
                    Destroy(tempParticle4.GetComponent<AudioSource>());
                    Destroy(tempParticle4, warAttackInterval);

                    GameObject tempParticle5 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(transform.forward - transform.right));
                    Destroy(tempParticle5.GetComponent<AudioSource>());
                    Destroy(tempParticle5, warAttackInterval);

                    GameObject tempParticle6 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(-transform.forward - transform.right));
                    Destroy(tempParticle6.GetComponent<AudioSource>());
                    Destroy(tempParticle6, warAttackInterval);

                    GameObject tempParticle7 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(transform.forward + transform.right));
                    Destroy(tempParticle7.GetComponent<AudioSource>());
                    Destroy(tempParticle7, warAttackInterval);

                    GameObject tempParticle8 = Instantiate(warParticle, transform.position, Quaternion.LookRotation(-transform.forward + transform.right));
                    Destroy(tempParticle8.GetComponent<AudioSource>());
                    Destroy(tempParticle8, warAttackInterval);

                    GetComponent<CharacterStats>().ResetSpecialTimer();
                }
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= warAttackInterval)
            {
                isSpecialAttacking = false;
                timer = 0.0f;
            }
        }
    }

    private void FamineAttack()
    {
        Collider[] hits = Physics.OverlapSphere(famineAttack.transform.position, famineAttackRange, layer);

        if (!isSpecialAttacking)
        {
            if (GetComponent<CharacterStats>().currentSpecialTimer >= GetComponent<CharacterStats>().maxSpecialTimer)
            {
                if (ControllerManager.Instance.GetBButtonDown(playerOrder))
                {
                    isSpecialAttacking = true;

                    StartCoroutine(DisplayAttackRange(famineAttack.gameObject, famineAttackInterval));

                    GameObject tempParticle = Instantiate(famineParticle, famineAttack.transform.position, transform.rotation);
                    StartCoroutine(PlayFamineParticle(hits, tempParticle, 1.0f));
                    Destroy(tempParticle, famineAttackInterval);

                    GetComponent<CharacterStats>().ResetSpecialTimer();
                }
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= famineAttackInterval)
            {
                isSpecialAttacking = false;
                timer = 0.0f;
            }
        }
    }

    private void DeathAttack()
    {
        Collider[] hits = Physics.OverlapBox(deathAttack.transform.position, deathAttack.transform.localScale / 2, deathAttack.transform.rotation, layer);

        if (!isSpecialAttacking)
        {
            if (GetComponent<CharacterStats>().currentSpecialTimer >= GetComponent<CharacterStats>().maxSpecialTimer)
            {
                if (ControllerManager.Instance.GetBButtonDown(playerOrder))
                {
                    for (int i = 0; i < hits.Length; i++)
                    {
                        hits[i].GetComponent<EnemyStats>().TakeDamage(deathAttackDamage);
                        Debug.Log(hits[i].GetComponent<EnemyStats>().currentHealth);
                    }

                    isSpecialAttacking = true;

                    StartCoroutine(DisplayAttackRange(deathAttack.gameObject, deathAttackInterval));

                    GameObject tempParticle = Instantiate(deathParticle, transform.position, transform.rotation);
                    Destroy(tempParticle, deathAttackInterval);

                    GetComponent<CharacterStats>().ResetSpecialTimer();
                }
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= deathAttackInterval)
            {
                isSpecialAttacking = false;
                timer = 0.0f;
            }
        }
    }

    private IEnumerator DisplayAttackRange(GameObject areaRange, float seconds)
    {
        areaRange.SetActive(true);
        yield return new WaitForSeconds(seconds);
        areaRange.SetActive(false);
    }

    private IEnumerator PlayFamineParticle(Collider[] hits, GameObject particle, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        particle.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].GetComponent<EnemyStats>().TakeDamage(famineAttackDamage);
            Debug.Log(hits[i].GetComponent<EnemyStats>().currentHealth);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Vector3 boxWidth = new Vector3(1.0f, 5.0f, 12.0f);

        Gizmos.DrawWireSphere(basicAttack.transform.position, basicAttackRange);
        Gizmos.DrawWireSphere(warAttack.transform.position, warAttackRange);
        Gizmos.DrawWireSphere(famineAttack.transform.position, famineAttackRange);
        Gizmos.DrawWireCube(deathAttack.transform.position, deathAttack.transform.localScale);
    }
}
