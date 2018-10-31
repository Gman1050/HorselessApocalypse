﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*******************************************************************************************************/
// This class will have management controls of the game
/*******************************************************************************************************/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     // Static variable that can be used to call public variables and functions from other classes
    public int playerQuantity;              // Checks the quantity of players on the Main menu for Debugging purposes

    public string nextLevel;

    public void CompleteLevel()
    {
        Debug.Log("level complete");
        SceneManager.LoadScene(nextLevel);
    }
    /*******************************************************************************************************/
    // Use this before scene loads
    /*******************************************************************************************************/
    void Awake()
    {
        Instance = this;    // Sets instance of the static variable before scenes loads
    }
    /*******************************************************************************************************/

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
        
	}
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to save player data after player joins the game and selects character
    /*******************************************************************************************************/
    public void SavePlayerData(PlayerOrder order, string character)
    {
        BinaryFormatter bf = new BinaryFormatter();     // Used to create save file for player data
        PlayerData data = new PlayerData();             // Declare and initialize data as new
        FileStream file;                                


        if (!File.Exists(GetDataPath(order)))           // Checks if file with name does or doesn't exists
        {
            file = File.Create(GetDataPath(order));     // Creates a new file with name
        }
        else
        {
            file = File.Open(GetDataPath(order), FileMode.Open);    // Opens existing file with name
        }

        data.playerOrder = order;       // Saves playerOrder so it knows which player to assign which data to
        data.character = character;     // Saves the character name of the selected character

        bf.Serialize(file, data);       // Saves the file with saved data into binaray
        file.Close();                   // Closes the file
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to load player data just before the game initiates
    /*******************************************************************************************************/
    public void LoadPlayerData(PlayerOrder order, GameObject player)
    {
        if (File.Exists(GetDataPath(order)))                                    // Checks if file with name does or doesn't exists
        {
            BinaryFormatter bf = new BinaryFormatter();                         // Used to create save file for player data
            FileStream file = File.Open(GetDataPath(order), FileMode.Open);     // Declares File for loading the player data

            PlayerData data = (PlayerData)bf.Deserialize(file);                 // Declare and initialize data as the saved file after being deserialized from binary format

            if (player.GetComponent<MultiplayerMovement>().playerOrder == data.playerOrder)     // Checks the playerOrder from the player controller script for the correct player to assign data to
            {
                player.GetComponent<MultiplayerMovement>().characterName = data.character;      // Initializes the character name string from the player controller script
                //Debug.Log("Loaded Player 1 Data");
            }

            file.Close();   // Cloeses the file
        }
        else
        {
            player.SetActive(false);    // Turns player off
        }
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Deletes the player data (use when you go back from after selecting character)
    /*******************************************************************************************************/
    public void DeletePlayerData(PlayerOrder order)
    {
        File.Delete(GetDataPath(order));
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Changes the scene of the game using the name of the scene
    /*******************************************************************************************************/
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Exits the game from the main menu
    /*******************************************************************************************************/
    public void ExitGame()
    {
        Application.Quit();
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Gets that data path for each player for player data saving and loading purposes
    /*******************************************************************************************************/
    private string GetDataPath(PlayerOrder order)
    {
        switch(order)
        {
            case PlayerOrder.PLAYER_1:
                return Application.persistentDataPath + "/player1Info.data";
            case PlayerOrder.PLAYER_2:
                return Application.persistentDataPath + "/player2Info.data";
            case PlayerOrder.PLAYER_3:
                return Application.persistentDataPath + "/player3Info.data";
            case PlayerOrder.PLAYER_4:
                return Application.persistentDataPath + "/player4Info.data";
        }

        return null;
    }
    /*******************************************************************************************************/
}
/*******************************************************************************************************/

/*******************************************************************************************************/
// This class will be used to store player data for saving and loading purposes between scenes
/*******************************************************************************************************/
[Serializable]
class PlayerData
{
    public PlayerOrder playerOrder;     // Save and load playerOrder from
    public string character;            // Save and load character's name from
    // Adding more soon
}
/*******************************************************************************************************/
