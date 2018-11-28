using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************************************************//
// This is merely a test class for multiplayer (It can be useful for setting up a player controller script for multiplayer)
//**********************************************************************************************************************//
public class MultiplayerMovement : MonoBehaviour
{
    public PlayerOrder playerOrder;         // Used to set which player is which in the inspector
    public float health = 100.0f;           // Test for Camera Control
    public float speed = 5.0f;              // Test variables for speed of the gameobject
    public string characterName;            // Initialized using the PlayerSelectScreen script's characterName variable value
    private CharacterController control;    // Declares CharacterController for rotation and movement

    //**********************************************************************************************************************//
    // Use this before scene loads
    //**********************************************************************************************************************//
    void Awake()
    {
        GameManager.Instance.LoadPlayerData(playerOrder, gameObject.GetComponent<CharacterStats>());   // Always have this in awake to set the player data before game begins
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Use this for initialization
    void Start ()
    {
        control = GetComponent<CharacterController>();  // Gets the reference to the CharacterController component
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Update is called once per frame
    //**********************************************************************************************************************//
    void Update ()
    {
        Movement();     // Test movement for all players

        ButtonTest();   // Test to check each button's functionality
    }
    //**********************************************************************************************************************//

    void LateUpdate()
    {
        PlayerBoundaries();
    }

    //**********************************************************************************************************************//
    // Test movement for all players
    //**********************************************************************************************************************//
    void Movement()
    {
        Attacks attacks = GetComponent<Attacks>();

        if (!attacks.IsSpecialAttack)
        {
            float targetX = ControllerManager.Instance.GetLeftStick(playerOrder).x;
            float targetZ = ControllerManager.Instance.GetLeftStick(playerOrder).y;
            float movement = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(targetX, 0.0f, targetZ), movement, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);
            control.Move(new Vector3(targetX, 0.0f, targetZ) * movement);
        }
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Test to check each button's functionality
    //**********************************************************************************************************************//
    void ButtonTest()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (ControllerManager.Instance.GetBButtonDown(playerOrder))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (ControllerManager.Instance.GetXButtonDown(playerOrder))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (ControllerManager.Instance.GetYButtonDown(playerOrder))
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Checks for player boundaries in a rectangular area
    //**********************************************************************************************************************//
    private void PlayerBoundaries()
    {
        CameraControl cam = Camera.main.GetComponent<CameraControl>();

        if (transform.position.x <= cam.GetCenterPoint().x - cam.XLimitFromCenter)
        {
            transform.position = new Vector3(cam.GetCenterPoint().x - cam.XLimitFromCenter, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= cam.GetCenterPoint().x + cam.XLimitFromCenter)
        {
            transform.position = new Vector3(cam.GetCenterPoint().x + cam.XLimitFromCenter, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= cam.GetCenterPoint().z - cam.ZLimitFromCenter)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cam.GetCenterPoint().z - cam.ZLimitFromCenter);
        }
        else if (transform.position.z >= cam.GetCenterPoint().z + cam.ZLimitFromCenter)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cam.GetCenterPoint().z + cam.ZLimitFromCenter);
        }
    }
    //**********************************************************************************************************************//
}
//**********************************************************************************************************************//