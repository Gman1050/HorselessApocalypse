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
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (ControllerManager.Instance.GetLeftStick(playerOrder).y > 0.0f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
