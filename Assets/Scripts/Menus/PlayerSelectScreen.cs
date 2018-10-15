using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public bool isReady = false;

    public bool IsReady { get { return isReady; } }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SelectionInput();

    }

    private void SelectionInput()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder))
        {
            isReady = true;
        }
        else if (ControllerManager.Instance.GetBButtonDown(playerOrder))
        {
            isReady = false;
        }
    }
}
