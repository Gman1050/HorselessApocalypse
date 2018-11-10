using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public PlayerOrder playerOrder;
    
    [Header("Basic Attack Settings: ")]
    [Range(0, 5)] public float basicAttackRange = 3.0f;
    [Range(0, 90)] public float basicAttackAngleLimit = 90.0f;
    [Range(0, 5)] public float basicAttackInterval = 5.0f;

    [Header("Pestilence Attack Settings: ")]
    [Range(0, 5)] public float pestilenceAttackRange = 3.0f;
    [Range(0, 90)] public float pestilenceAttackAngleLimit = 90.0f;

    [Header("War Attack Settings: ")]
    [Range(0, 5)] public float warAttackRange = 3.0f;
    [Range(0, 90)] public float warAttackAngleLimit = 90.0f;

    [Header("Famine Attack Settings: ")]
    [Range(0, 5)] public float famineAttackRange = 3.0f;
    [Range(0, 90)] public float famineAttackAngleLimit = 90.0f;

    [Header("Death Attack Settings: ")]
    [Range(0, 5)] public float deathAttackRange = 3.0f;
    [Range(0, 90)] public float deathAttackAngleLimit = 90.0f;

    private bool isAttacking = false;
    private bool hasPestilence = false, hasWar = false, hasFamine = false, hasDeath = false;

    public bool HasPestilence { get { return hasPestilence; } set { hasPestilence = value; } }
    public bool HasWar { get { return hasWar; } set { hasWar = value; } }
    public bool HasFamine { get { return hasFamine; } set { hasFamine = value; } }
    public bool HasDeath { get { return hasDeath; } set { hasDeath = value; } }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void AttackAction()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder))
        {

        }

        else if (ControllerManager.Instance.GetBButtonDown(playerOrder))
        {
            if (hasPestilence && !hasWar && !hasFamine && !hasDeath)
            {

            }
            else if (hasPestilence && !hasWar && !hasFamine && !hasDeath)
            {

            }
            else if (hasPestilence && !hasWar && !hasFamine && !hasDeath)
            {

            }
            else if (hasPestilence && !hasWar && !hasFamine && !hasDeath)
            {

            }
        }
    }

    private IEnumerator BasicAttack(GameObject enemy)
    {
        // Create boundaries for Attack range using trigonometry
        Vector3 targetDir = enemy.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float distance = Vector3.Distance(enemy.transform.position, transform.position);

        if (!isAttacking)
        {
            // Controller Input Check
            // Detect if enemy is within range of boundaries

            if (angle <= basicAttackAngleLimit && distance <= basicAttackRange)
            {
                print("Damage");
            }
            // Deal damage to enemy and perhaps stun time
        }
        else
        {
            yield return new WaitForSeconds(basicAttackInterval);
            isAttacking = true;
        }
    }

    private void PestilenceAttack()
    {

    }

    private void WarAttack()
    {

    }

    private void FamineAttack()
    {

    }

    private void DeathAttack()
    {

    }
}
