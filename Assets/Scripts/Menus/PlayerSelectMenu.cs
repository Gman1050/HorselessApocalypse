using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectMenu : MonoBehaviour
{
    public GameObject[] playerPanels;
    public Text[] controllerConnected;
    public Text[] controllerDisconnected;
    public Text[] playerReady;
    public Button startGame;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayers();

    }

    private void FindPlayers()
    {
        for (int count = 0; count < ControllerManager.Instance.controllers.Length; count++)
        {
            if (ControllerManager.Instance.controllers[count] == null || ControllerManager.Instance.controllers[count] == "")
            {
                playerReady[count].gameObject.SetActive(false);
                controllerConnected[count].gameObject.SetActive(false);
                controllerDisconnected[count].gameObject.SetActive(true);

                if (GameManager.Instance.playerQuantity > 0)
                {
                    GameManager.Instance.playerQuantity--;
                }
            }
            else
            {
                Debug.Log(count);
                JoinGame(count);

                controllerDisconnected[count].gameObject.SetActive(false);

                if (GameManager.Instance.playerQuantity < ControllerManager.Instance.controllers.Length)
                {
                    GameManager.Instance.playerQuantity++;
                }
            }
        }
    }

    private void JoinGame(int count)
    {
        if (playerPanels[count].GetComponent<PlayerSelectScreen>().IsReady)
        {
            playerReady[count].gameObject.SetActive(true);
            controllerConnected[count].gameObject.SetActive(false);
        }
        else
        {
            playerReady[count].gameObject.SetActive(false);
            controllerConnected[count].gameObject.SetActive(true);
        }
    }
}
