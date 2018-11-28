using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour {

    private Animator anim;

    public float lookRadius = 10f;

    Transform target;

    NavMeshAgent agent;

    CharacterCombat combat;

	// Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        combat = GetComponent<CharacterCombat>();

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("IsWalking", true);

            if(distance <= agent.stoppingDistance)
            {
                //attack
                anim.SetBool("IsWalking", false);
                CharacterStats targetStats = target.GetComponent<CharacterStats>();

                if (targetStats.currentHealth != 0)
                {

                    combat.Attack(targetStats);
                    anim.SetBool("IsAttacking", true);
                }
                else
                    anim.SetBool("IsAttacking", false);
                FaceTarget();
            }
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
