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
    public SphereCollider basicAttack;
    
    [Header("Pestilence Attack Settings: ")]
    [Range(0, 5)] public float pestilenceAttackRange = 3.0f;
    [Range(0, 5)] public float pestilenceAttackInterval = 5.0f;
    [Range(0, 15)] public float pestilenceAttackSpeed = 15.0f;
    public SphereCollider pestilenceAttack;
    public GameObject pestilenceParticle;

    [Header("War Attack Settings: ")]
    [Range(0, 20)] public float warAttackRange = 3.0f;
    [Range(0, 5)] public float warAttackInterval = 5.0f;
    public SphereCollider warAttack;
    public GameObject warParticle;

    [Header("Famine Attack Settings: ")]
    [Range(0, 5)] public float famineAttackRange = 3.0f;
    [Range(0, 5)] public float famineAttackInterval = 5.0f;
    public SphereCollider famineAttack;
    public GameObject faminePartile;

    [Header("Death Attack Settings: ")]
    [Range(0, 5)] public float deathAttackInterval = 5.0f;
    public BoxCollider deathAttack;
    public GameObject deathParticle;
    private float timer = 0.0f;
    private bool isAttacking = false, isSpecialAttacking = false;

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
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log(hits[i]);
                }

                isAttacking = true;
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

    private void PestilenceAttack()
    {
        Collider[] hits = Physics.OverlapSphere(pestilenceAttack.transform.position, pestilenceAttackRange, layer);

        if (!isSpecialAttacking)
        {
            if (ControllerManager.Instance.GetBButtonDown(playerOrder))
            {
                pestilenceAttack.transform.parent = null;
                isSpecialAttacking = true;
            }
        }
        else
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            pestilenceAttack.transform.Translate(Vector3.forward * Time.deltaTime * pestilenceAttackSpeed);

            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i]);
            }

            if (timer >= pestilenceAttackInterval || hits.Length > 0)
            {
                isSpecialAttacking = false;
                timer = 0.0f;

                pestilenceAttack.transform.position = transform.position;
                pestilenceAttack.transform.parent = transform;
                pestilenceAttack.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    private void WarAttack()
    {
        Collider[] hits = Physics.OverlapSphere(warAttack.transform.position, warAttackRange, layer);

        if (!isSpecialAttacking)
        {
            if (ControllerManager.Instance.GetBButtonDown(playerOrder))
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log(hits[i]);
                }

                isSpecialAttacking = true;
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
            if (ControllerManager.Instance.GetBButtonDown(playerOrder))
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log(hits[i]);
                }

                isSpecialAttacking = true;
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
            if (ControllerManager.Instance.GetBButtonDown(playerOrder))
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log(hits[i]);
                }

                isSpecialAttacking = true;
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

    private void OnDrawGizmosSelected()
    {
        //Vector3 boxWidth = new Vector3(1.0f, 5.0f, 12.0f);

        Gizmos.DrawWireSphere(basicAttack.transform.position, basicAttackRange);
        Gizmos.DrawWireSphere(warAttack.transform.position, warAttackRange);
        Gizmos.DrawWireSphere(famineAttack.transform.position, famineAttackRange);
        Gizmos.DrawWireCube(deathAttack.transform.position, deathAttack.transform.localScale);
    }
}
