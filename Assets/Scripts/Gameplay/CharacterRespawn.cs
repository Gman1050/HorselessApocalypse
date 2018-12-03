using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public GameObject highlightSpawnSpot;
    public float mass = 18.0f;                      // Default mass will set player to 180 pounds approximately
    public float speed = 5.0f;                      // Test variables for speed of the gameobject

    private CharacterController control;            // Declares CharacterController for rotation and movement
    private Vector3 gravityVector = Vector3.zero;   // Set an initial velocity for gravity
    private CharacterStats characterStats;

    private void OnEnable()
    {
        highlightSpawnSpot.SetActive(true);
    }

    private void OnDisable()
    {
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
        gravityVector += mass * Physics.gravity * Time.deltaTime;
        Vector3 deltaPosition = gravityVector * Time.deltaTime;
        Vector3 move = Vector3.up * deltaPosition.y;

        float targetX = ControllerManager.Instance.GetLeftStick(playerOrder).x;
        float targetZ = ControllerManager.Instance.GetLeftStick(playerOrder).y;
        float movement = speed * Time.deltaTime;
        
        control.Move(new Vector3(targetX, move.y, targetZ) * movement);

        if (ControllerManager.Instance.GetAButtonDown(playerOrder))
        {
            characterStats.IsDead = true;
        }
    }
}
