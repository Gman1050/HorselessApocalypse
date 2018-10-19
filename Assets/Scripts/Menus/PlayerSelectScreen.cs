using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public string characterName;
    private bool isReady = false;

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
            if (GameManager.Instance.playerQuantity < ControllerManager.Instance.controllers.Length && !isReady)
            {
                GameManager.Instance.playerQuantity++;
                isReady = true;
            }
        }
        else if (ControllerManager.Instance.GetBButtonDown(playerOrder))
        {
            if (GameManager.Instance.playerQuantity > 0 && isReady)
            {
                GameManager.Instance.playerQuantity--;
                isReady = false;
            }
        }

        if (isReady)
        {
            if (ControllerManager.Instance.GetStartButtonDown(playerOrder))
            {
                GameManager.Instance.SavePlayerData(playerOrder, characterName);
                GameManager.Instance.ChangeScene("MultiplayerTest");
            }
        }
    }
}
