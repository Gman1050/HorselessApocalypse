using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSelectMenu : MonoBehaviour
{
    public GameObject[] playerPanels;
    public Text[] controllerConnected;
    public Text[] controllerDisconnected;
    public Text[] playerReady;
    public Image startGame;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            }
            else
            {
                JoinGame(count);
                controllerDisconnected[count].gameObject.SetActive(false);
            }
        }

        if (playerPanels[0].GetComponent<PlayerSelectScreen>().IsReady || playerPanels[1].GetComponent<PlayerSelectScreen>().IsReady ||
            playerPanels[2].GetComponent<PlayerSelectScreen>().IsReady || playerPanels[3].GetComponent<PlayerSelectScreen>().IsReady)
        {
            startGame.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(startGame.gameObject);
        }
        else
        {
            startGame.gameObject.SetActive(false);
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
