using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************************************/
// This class is used to set the player data into the game
/*******************************************************************************************************/
public class PlayerSelectScreen : MonoBehaviour
{
    public PlayerOrder playerOrder;     // Used to set which player is which in the inspector
    public string characterName;        // Used to set the name of the selected character into the game
    private bool isReady = false;       // Used to check if the player has selected which character and is set to play

    public bool IsReady { get { return isReady; } }     // This property is used to check in the PlayerSelectMenu if the player has selected which character and is set to play

    /*******************************************************************************************************/
    // Use this for initialization
    /*******************************************************************************************************/
    void Start ()
    {
		
	}
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Update is called once per frame
    /*******************************************************************************************************/
    void Update ()
    {
        SelectionInput();   // Used to make selections for the player or to go back

    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to make selections for the player or to go back
    /*******************************************************************************************************/
    private void SelectionInput()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder))     // Checks if A button is pressed on X-Input controller
        {
            if (GameManager.Instance.playerQuantity < ControllerManager.Instance.controllers.Length && !isReady)    // Checks if the player quantity is less than the number of controllers connected
            {
                SetPlayerData();    // Used to set the player data after the player is ready to play

                GameManager.Instance.playerQuantity++;  // Increase player quantity by one when player is ready
                isReady = true;                         // Player is ready to play
            }
        }
        else if (ControllerManager.Instance.GetBButtonDown(playerOrder))    // Checks if B button is pressed on X-Input controller
        {
            if (GameManager.Instance.playerQuantity > 0 && isReady)         // Checls if player quantity is greater than 0 and if the player is ready or not
            {
                GameManager.Instance.DeletePlayerData(playerOrder);         // Deletes existing player data that was already set after being ready

                GameManager.Instance.playerQuantity--;                      // Decreases player quantity by one when player goes back
                isReady = false;                                            // Player is not ready to play
            }
        }

        if (isReady)    // Checks to see if player is ready
        {
            if (ControllerManager.Instance.GetStartButtonDown(playerOrder))     // Checks to see if Start button is pressed on X-Input controller
            {
                GameManager.Instance.ChangeScene("MultiplayerTest");            // Changes to the scene where the game begins
            }
        }
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to set the player data after the player is ready to play
    /*******************************************************************************************************/
    private void SetPlayerData()
    {
        switch (playerOrder)    // Checks to see which player is this
        {
            case PlayerOrder.PLAYER_1:                                                  
                GameManager.Instance.SavePlayerData(playerOrder, characterName);    // Saves player 1 data
                //Debug.Log("Saved Player 1 Data");
                break;
            case PlayerOrder.PLAYER_2:
                GameManager.Instance.SavePlayerData(playerOrder, characterName);    // Saves player 2 data
                break;
            case PlayerOrder.PLAYER_3:
                GameManager.Instance.SavePlayerData(playerOrder, characterName);    // Saves player 3 data
                break;
            case PlayerOrder.PLAYER_4:
                GameManager.Instance.SavePlayerData(playerOrder, characterName);    // Saves player 4 data
                break;
        }
    }
    /*******************************************************************************************************/
}
/*******************************************************************************************************/
