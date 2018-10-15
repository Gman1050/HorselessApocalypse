using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerMovement : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public float speed = 5.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        ButtonTest();

    }

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
}
