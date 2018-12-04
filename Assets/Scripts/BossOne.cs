using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossOne : MonoBehaviour
{
    public BossAnimationState animationState;
    public List<CharacterStats> players = new List<CharacterStats>();
    public int oneSwingDamage = 3, doubleSwingDamage = 6;
    public float speed;
    public float targetReach = 3.0f;
    
    private EnemyCombat combat;
    private NavMeshAgent agent; 
    private Animator animator;
    private bool bossFightBegins = false;

	// Use this for initialization
	void Start ()
    {
        combat = GetComponent<EnemyCombat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayers();

        BossMovement();

        BossAnimation();
    }

    private void FindPlayers()
    {
        var targetsFound = FindObjectsOfType<CharacterStats>();    // Replace with PlayerController script of some kind

        for (int count = 0; count < targetsFound.Length; count++)
        {
            if (!players.Contains(targetsFound[count]))
            {
                players.Add(targetsFound[count]);
            }
            else
            {
                GameObject target = players[count].gameObject;

                if (target.GetComponent<CharacterStats>().currentHealth <= 0)     // This can be used to check health from player (checking if gameobject is not active does not work)
                {
                    //Debug.Log(target.activeSelf);
                    //targets.Remove(targets[count].transform);
                    //target.SetActive(false);                                    // This can be rid of when player controller turns off player gameobject
                    //Debug.Log(target.activeSelf);
                }
            }
        }
    }

    private void BossMovement()
    {
        if (bossFightBegins)
        {
            agent.SetDestination(GetClosestEnemy(players).position);
        }

        float distance = Vector3.Distance(transform.position, GetClosestEnemy(players).position);

        if (distance <= targetReach)
        {
            StartCoroutine(DamageTimer(2.0f));
        }
    }

    private void SpeedMonitor()
    {
        if(agent.speed >= 5.0f)
        {

        }
        else if (agent.speed >= 0.2f && agent.speed < 5.0f)
        {

        }
        else if (agent.speed >= 0.0f && agent.speed < 0.2f)
        {

        }
    }

    private void BossAnimation()
    {
        switch(animationState)
        {
            case BossAnimationState.NONE:
                break;
            case BossAnimationState.IDLE:
                animator.SetTrigger("idle");
                break;
            case BossAnimationState.WALK:
                animator.SetTrigger("walk");
                break;
            case BossAnimationState.RUN:
                animator.SetTrigger("run");
                break;
            case BossAnimationState.LEFT_ATTACK:
                animator.SetTrigger("attack_01");
                break;
            case BossAnimationState.RIGHT_ATTACK:
                animator.SetTrigger("attack_02");
                break;
            case BossAnimationState.DOUBLE_ATTACK:
                animator.SetTrigger("attack_03");
                break;
            case BossAnimationState.DEAD:
                animator.SetTrigger("die");
                break;
        }
    }

    private Transform GetClosestEnemy(List<CharacterStats> playersList)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (CharacterStats potentialPlayerTarget in playersList)
        {
            Vector3 directionToTarget = potentialPlayerTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialPlayerTarget.transform;
            }
        }

        return bestTarget;
    }

    private IEnumerator DamageTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GetClosestEnemy(players).GetComponent<CharacterStats>().currentHealth -= oneSwingDamage;
    }
}

public enum BossAnimationState
{
    NONE,
    IDLE,
    WALK,
    RUN,
    LEFT_ATTACK,
    RIGHT_ATTACK,
    DOUBLE_ATTACK,
    DEAD
};