using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossOne : MonoBehaviour
{
    public LayerMask layer;
    public BossAnimationState animationState;
    public List<CharacterStats> players = new List<CharacterStats>();
    public int singleSwingDamage = 1, doubleSwingDamage = 2;
    public float speed;
    public float targetReach = 3.0f, beginFight = 10.0f;
    
    private EnemyCombat combat;
    private BossStats bossStats;
    private NavMeshAgent agent; 
    private Animator animator;
    private bool bossFightBegins = false;
    private bool attackCheck = false;
    private float animationMovementTimer = 0.0f;
    private float animationMaxTime = 0.0f;

    // Index Finger Velocity Tracking
    private float currentSpeed;
    private Vector3 lastPosition;

    // Use this for initialization
    void Start ()
    {
        bossStats = GetComponent<BossStats>();
        combat = GetComponent<EnemyCombat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayers();

        BossMovement();
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

    void OnGUI()
    {
        //GUI.Label(new Rect(0, 0, 1000, 1000), currentSpeed.ToString());
    }

    private void BossMovement()
    {
        // Set the value of the lastContentScrolled to a new value relative to the velocity of the index finger.
        currentSpeed = ((transform.position - lastPosition).magnitude) / Time.deltaTime;
        lastPosition = transform.position;

        if (!bossStats.IsDead)
        {
            Transform newTargetPosition = GetClosestEnemy(players);
            //Debug.Log("newTargetPosition: " + newTargetPosition);

            if (newTargetPosition)
            {
                float distance = Vector3.Distance(transform.position, newTargetPosition.position);

                if (distance <= beginFight)
                {
                    bossFightBegins = true;
                }

                if (distance <= targetReach)
                {
                    animationMovementTimer = 0.0f;

                    if (!attackCheck)
                    {
                        StartCoroutine(DamageTimer(1.0f));
                    }
                }
                else
                {
                    SpeedMonitor();

                    if (bossFightBegins)
                    {
                        if (agent.destination == null || Vector3.Distance(transform.position, agent.destination) < 3f)
                            agent.destination = newTargetPosition.position;

                    }
                }

                
            }
            else
            {
                SpeedMonitor();
            }
        }
        else
        {
            if (GetComponent<BoxCollider>().enabled)
            {
                StartCoroutine(Die(1.0f));
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void SpeedMonitor()
    {
        if (animationMovementTimer == 0.0f)
        {
            //Debug.Log("currentSpeed: " + currentSpeed);

            if (currentSpeed >= 3.2f)
            {
                animationState = BossAnimationState.RUN;
            }
            else if (currentSpeed >= 0.2f && currentSpeed < 3.2f)
            {
                animationState = BossAnimationState.WALK;
            }
            else if (currentSpeed >= 0.0f && currentSpeed < 0.2f)
            {
                animationState = BossAnimationState.IDLE;
            }

            //Debug.Log("animationState: " + animationState);

            BossAnimation();
        }

        //Debug.Log("animationMovementTimer: " + animationMovementTimer);

        animationMovementTimer += Time.deltaTime;

        if (animationMovementTimer >= animationMaxTime)
            animationMovementTimer = 0.0f;
    }

    public void BossAnimation()
    {
        switch(animationState)
        {
            case BossAnimationState.NONE:
                break;
            case BossAnimationState.IDLE:
                animator.SetTrigger("idle");
                animationMaxTime = 1.6666666f;
                break;
            case BossAnimationState.WALK:
                animator.SetTrigger("walk");
                animationMaxTime = 1.6333333f;
                break;
            case BossAnimationState.RUN:
                animator.SetTrigger("run");
                animationMaxTime = 0.8f;
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
            case BossAnimationState.DAMAGED:
                animator.SetTrigger("damage");
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
            if (!potentialPlayerTarget.IsDead)
            {
                Vector3 directionToTarget = potentialPlayerTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialPlayerTarget.transform;
                }
            }
        }

        if (!bestTarget)
        {
            animationState = BossAnimationState.IDLE;
            BossAnimation();
        }

        return bestTarget;
    }

    private IEnumerator DamageTimer(float seconds)
    {
        attackCheck = true;

        if (animationState != BossAnimationState.LEFT_ATTACK && animationState != BossAnimationState.RIGHT_ATTACK && animationState != BossAnimationState.DOUBLE_ATTACK)
            animationState = BossAnimationState.LEFT_ATTACK;
        else if (animationState == BossAnimationState.LEFT_ATTACK)
            animationState = BossAnimationState.RIGHT_ATTACK;
        else if (animationState == BossAnimationState.RIGHT_ATTACK)
            animationState = BossAnimationState.DOUBLE_ATTACK;
        else if (animationState == BossAnimationState.DOUBLE_ATTACK)
            animationState = BossAnimationState.LEFT_ATTACK;

        BossAnimation();

        yield return new WaitForSeconds(seconds);

        if (animationState == BossAnimationState.LEFT_ATTACK || animationState == BossAnimationState.RIGHT_ATTACK)
        {
            AudioManager.Instance.PlayEnemyAudioClip3D(GetComponent<AudioSource>(), Random.Range(2,3));
            GetClosestEnemy(players).GetComponent<CharacterStats>().TakeDamage(singleSwingDamage);
        }
        else if (animationState == BossAnimationState.DOUBLE_ATTACK)
        {
            AudioManager.Instance.PlayEnemyAudioClip3D(GetComponent<AudioSource>(), 1);
            GetClosestEnemy(players).GetComponent<CharacterStats>().TakeDamage(doubleSwingDamage);
        }

        attackCheck = false;
    }

    private IEnumerator Die(float seconds)
    {
        animationState = BossAnimationState.DEAD;
        BossAnimation();
        yield return new WaitForSeconds(seconds);
        StartCoroutine(EndLevel(5.0f));
    }

    private IEnumerator EndLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.ChangeScene("Main Menu");
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
    DAMAGED,
    DEAD
};