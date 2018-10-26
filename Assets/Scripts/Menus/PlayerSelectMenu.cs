using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*******************************************************************************************************/
// This class is used to control the UI in the MainMenu scene
/*******************************************************************************************************/
public class PlayerSelectMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;       // Used in the PlayerSelectScreen script
    public GameObject[] playerPanels;       // The sections for each player to select characters and join game
    public Text[] controllerConnected;      // User message to show if controller is connected
    public Text[] controllerDisconnected;   // User message to show if controller is disconnected
    public Text[] playerReady;              // User message to show if controller is connected and player is ready
    public Image startGame;                 // An image that only appears if at least one player is ready

    /*******************************************************************************************************/
    // Use this for initialization
    /*******************************************************************************************************/
    void Start()
    {

    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Update is called once per frame
    /*******************************************************************************************************/
    void Update()
    {
        FindPlayers();  // Used to find player and check connectivity of controllers
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to find player and check connectivity of controllers
    /*******************************************************************************************************/
    private void FindPlayers()
    {
        for (int count = 0; count < ControllerManager.Instance.controllers.Length; count++)     // Used to check through each controller connected
        {
            if (ControllerManager.Instance.controllers[count] == null || ControllerManager.Instance.controllers[count] == "")   // Checks to see if controller is connected or disconnected
            {
                playerReady[count].gameObject.SetActive(false);             // Sets player ready message to off
                controllerConnected[count].gameObject.SetActive(false);     // Sets controller connected message to off
                controllerDisconnected[count].gameObject.SetActive(true);   // Sets controller disconnected message to on
            }
            else
            {
                JoinGame(count);                                                // Used to set the player as ready to play
                controllerDisconnected[count].gameObject.SetActive(false);      // Sets controller disconnected message to off
            }
        }

        if (playerPanels[0].GetComponent<PlayerSelectScreen>().IsReady || playerPanels[1].GetComponent<PlayerSelectScreen>().IsReady ||
            playerPanels[2].GetComponent<PlayerSelectScreen>().IsReady || playerPanels[3].GetComponent<PlayerSelectScreen>().IsReady)       // Checks to see if at least one player is ready
        {
            startGame.gameObject.SetActive(true);                               // Sets start game image to on
        }
        else
        {
            startGame.gameObject.SetActive(false);                              // Sets start game image to off
        }
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to set the player as ready to play
    /*******************************************************************************************************/
    private void JoinGame(int count)
    {
        if (playerPanels[count].GetComponent<PlayerSelectScreen>().IsReady)     // Checks to see if the player is ready or not
        {
            playerReady[count].gameObject.SetActive(true);                      // Sets player ready message to on
            controllerConnected[count].gameObject.SetActive(false);             // Sets controller connected message to off

        }
        else
        {
            playerReady[count].gameObject.SetActive(false);                     // Sets player ready message to off
            controllerConnected[count].gameObject.SetActive(true);              // Sets controller connected message to on
        }
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Resets UI when this is setactive to false and mainmenu is setactive to true
    /*******************************************************************************************************/
    public void ResetUI()
    {
        foreach(GameObject panel in playerPanels)
        {
            panel.GetComponent<PlayerSelectScreen>().IsReady = false;
        }
    }
    /*******************************************************************************************************/
}
/*******************************************************************************************************/
