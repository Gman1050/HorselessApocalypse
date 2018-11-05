using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************************************************//
// This is merely a test class for multiplayer (It can be useful for setting up a player controller script for multiplayer)
//**********************************************************************************************************************//
public class MultiplayerMovement : MonoBehaviour
{
    public PlayerOrder playerOrder;     // Used to set which player is which in the inspector
    public float health = 100.0f;       // Test for Camera Control
    public float speed = 5.0f;          // Test variables for speed of the gameobject
    public string characterName;        // Initialized using the PlayerSelectScreen script's characterName variable value

    //**********************************************************************************************************************//
    // Use this before scene loads
    //**********************************************************************************************************************//
    void Awake()
    {
        GameManager.Instance.LoadPlayerData(playerOrder, gameObject);   // Always have this in awake to set the player data before game begins
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Use this for initialization
    void Start ()
    {
        
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
        TargetBoundaries();
    }

    //**********************************************************************************************************************//
    // Test movement for all players
    //**********************************************************************************************************************//
    void Movement()
    {
        if (ControllerManager.Instance.GetLeftStick(playerOrder).x < 0.0f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (ControllerManager.Instance.GetLeftStick(playerOrder).x > 0.0f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (ControllerManager.Instance.GetLeftStick(playerOrder).y < 0.0f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (ControllerManager.Instance.GetLeftStick(playerOrder).y > 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
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

    private void TargetBoundaries()
    {
        CameraControl cam = Camera.main.GetComponent<CameraControl>();

        Vector3 pos = transform.position;
        float distance = Mathf.Clamp(pos.magnitude, cam.GetCenterPoint().magnitude, cam.CenterRadius);

        if (distance >= cam.CenterRadius)
        {
            float angle = Mathf.Atan2(pos.z, pos.x);
            pos.x = Mathf.Cos(angle) * distance;
            pos.z = Mathf.Sin(angle) * distance;
            transform.position = pos;
        }
    }
}
//**********************************************************************************************************************//