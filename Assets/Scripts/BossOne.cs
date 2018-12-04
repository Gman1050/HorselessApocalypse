using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossOne : MonoBehaviour
{
    public BossAnimationState animationState;
    public List<CharacterStats> players = new List<CharacterStats>();
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
            combat.Attack(GetClosestEnemy(players).GetComponent<CharacterStats>());
        }
    }

    private void BossAnimation()
    {
        switch(animationState)
        {
            case BossAnimationState.NONE:
                break;
            case BossAnimationState.IDLE:
                break;
            case BossAnimationState.WALK:
                break;
            case BossAnimationState.RUN:
                break;
            case BossAnimationState.LEFT_ATTACK:
                break;
            case BossAnimationState.RIGHT_ATTACK:
                break;
            case BossAnimationState.DOUBLE_ATTACK:
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
}

public enum BossAnimationState
{
    NONE,
    IDLE,
    WALK,
    RUN,
    LEFT_ATTACK,
    RIGHT_ATTACK,
    DOUBLE_ATTACK
};