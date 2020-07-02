using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public GameObject highlightSpawnSpot;
    public SkinnedMeshRenderer skin;
    public Animator anim;

    //public float mass = 18.0f;                      // Default mass will set player to 180 pounds approximately
    //public float speed = 5.0f;                      // Test variables for speed of the gameobject

    //private CharacterController control;            // Declares CharacterController for rotation and movement
    //private Vector3 gravityVector = Vector3.zero;   // Set an initial velocity for gravity
    private CharacterStats characterStats;
    private CharacterMovement characterMovement;
    private bool isRespawnCoroutineRunning = false;
    private bool isDieCoroutineRunning = false;
    private void OnEnable()
    {
        if(characterStats.IsDead)
        {
            StartCoroutine(DieCoroutine(1.0666f));
        }
    }

    private void OnDisable()
    {
        
    }

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Respawn();

    }

    private void Respawn()
    {
        if (LivesSystem.Instance.LivesCount > 0)
        {
            if (!isDieCoroutineRunning && !isRespawnCoroutineRunning)
            {
                if (ControllerManager.Instance.GetAButtonDown(playerOrder))
                {
                    StartCoroutine(RespawnCoroutine(0.833333f));
                }
            }
        }
    }

    private IEnumerator DieCoroutine(float seconds)
    {
        isDieCoroutineRunning = true;

        characterMovement.enabled = false;
        GetComponent<Attacks>().enabled = false;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsSpecial", false);
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsDead", true);

        yield return new WaitForSeconds(seconds);

        if (LivesSystem.Instance.LivesCount > 0)
        {
            characterMovement.enabled = true;
            highlightSpawnSpot.SetActive(true);
        }

        anim.SetBool("IsDead", false);
        skin.enabled = false;
        anim.enabled = false;

        if (LivesSystem.Instance.LivesCount <= 0)
        {
            // TODO: RePosition transform somewhere nearby other players just in case an extra life is gained

        }

        isDieCoroutineRunning = false;
    }

    private IEnumerator RespawnCoroutine(float seconds)
    {
        isRespawnCoroutineRunning = true;
        characterMovement.enabled = false;
        skin.enabled = true;
        anim.enabled = true;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdle", false);
        anim.SetBool("Respawn", true);
        highlightSpawnSpot.SetActive(false);

        yield return new WaitForSeconds(seconds);

        characterMovement.enabled = true;
        anim.SetBool("Respawn", false);
        GetComponent<Attacks>().enabled = true;
        characterStats.ResetHealth();
        characterStats.IsDead = false;
        isRespawnCoroutineRunning = false;
    }
}
