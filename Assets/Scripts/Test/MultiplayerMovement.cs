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
        PlayerBoundaries();
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

        /*
        float actualDistance = Vector2.Distance(cam.GetCenterPoint(), transform.position);
        //float angle = Mathf.Atan2(transform.position.z, transform.position.x);
        //float x = Mathf.Cos(angle) * actualDistance;
        //float z = Mathf.Sin(angle) * actualDistance;

        if (actualDistance >= cam.CenterRadius)
        {
            //transform.position = new Vector3(x, transform.position.y, z);

            Vector3 centerToPosition = transform.position - cam.GetCenterPoint();
            centerToPosition.Normalize();
            transform.position = cam.GetCenterPoint() + centerToPosition * cam.CenterRadius;
        }

        //Vector3 v = transform.position - cam.GetCenterPoint();
        //v = Vector3.ClampMagnitude(v, cam.CenterRadius);
        //transform.position = cam.GetCenterPoint() + v;
        */
    }
}
//**********************************************************************************************************************//