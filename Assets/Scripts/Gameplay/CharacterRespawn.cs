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

    private void OnEnable()
    {
        if(characterStats.IsDead)
        {
            anim.SetBool("IsDead", true);
            skin.enabled = false;
            GetComponent<Attacks>().enabled = false;
            highlightSpawnSpot.SetActive(true);
        }
    }

    private void OnDisable()
    {
        anim.SetBool("Respawn", false);
        anim.SetBool("IsDead", false);
        
        skin.enabled = true;
        GetComponent<Attacks>().enabled = true;
        highlightSpawnSpot.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        characterStats = GetComponent<CharacterStats>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Respawn();

    }

    private void Respawn()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder))
        {
            anim.SetBool("Respawn", true);
            characterStats.ResetHealth();
            characterStats.IsDead = false;
        }
    }
}
