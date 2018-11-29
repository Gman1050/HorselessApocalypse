using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*******************************************************************************************************/
// This class will have management controls of the game
/*******************************************************************************************************/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     // Static variable that can be used to call public variables and functions from other classes
    public int playerQuantity;              // Checks the quantity of players on the Main menu for Debugging purposes
    public PlayerDataContainer player_1, player_2, player_3, player_4;
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
        Debug.Log(name);
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
    public void SavePlayerData(PlayerOrder order, string name, Sprite image)
    {
        switch (order)
        {
            case PlayerOrder.PLAYER_1:
                player_1.playerOrder = order;
                player_1.characterName = name;
                player_1.characterImage = image;
                break;
            case PlayerOrder.PLAYER_2:
                player_2.playerOrder = order;
                player_2.characterName = name;
                player_2.characterImage = image;
                break;
            case PlayerOrder.PLAYER_3:
                player_3.playerOrder = order;
                player_3.characterName = name;
                player_3.characterImage = image;
                break;
            case PlayerOrder.PLAYER_4:
                player_4.playerOrder = order;
                player_4.characterName = name;
                player_4.characterImage = image;
                break;
        }

        /*
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

        data.playerOrder = order;               // Saves playerOrder so it knows which player to assign which data to
        data.characterName = name;              // Saves the character name of the selected character
        Debug.Log(image);
        data.characterImage = image;     // Saves the character image of the selected character
        Debug.Log(data.characterImage.sprite);
        bf.Serialize(file, data);               // Saves the file with saved data into binaray
        file.Close();                           // Closes the file
        */
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to load player data just before the game initiates
    /*******************************************************************************************************/
    public void LoadPlayerData(PlayerOrder order, CharacterStats player)
    {
        switch (order)
        {
            case PlayerOrder.PLAYER_1:
                Debug.Log(player_1);
                //player.playerOrder = player_1.playerOrder;
                if (player_1.characterName != null && player_1.characterImage != null)
                {
                    player.characterName = player_1.characterName;
                    player.characterImage.sprite = player_1.characterImage;
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                break;
            case PlayerOrder.PLAYER_2:
                Debug.Log(player_2);
                //player.playerOrder = player_2.playerOrder;
                if (player_2.characterName != null && player_2.characterImage != null)
                {
                    player.characterName = player_2.characterName;
                    player.characterImage.sprite = player_2.characterImage;
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                break;
            case PlayerOrder.PLAYER_3:
                Debug.Log(player_3);
                //player.playerOrder = player_3.playerOrder;
                if (player_3.characterName != null && player_3.characterImage != null)
                {
                    player.characterName = player_3.characterName;
                    player.characterImage.sprite = player_3.characterImage;
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                break;
            case PlayerOrder.PLAYER_4:
                Debug.Log(player_4);
                //player.playerOrder = player_4.playerOrder;
                if (player_4.characterName != null && player_4.characterImage != null)
                {
                    player.characterName = player_4.characterName;
                    player.characterImage.sprite = player_4.characterImage;
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                break;
        }

        /*
        if (File.Exists(GetDataPath(order)))                                    // Checks if file with name does or doesn't exists
        {
            BinaryFormatter bf = new BinaryFormatter();                         // Used to create save file for player data
            FileStream file = File.Open(GetDataPath(order), FileMode.Open);     // Declares File for loading the player data

            PlayerData data = (PlayerData)bf.Deserialize(file);                 // Declare and initialize data as the saved file after being deserialized from binary format

            if (player.GetComponent<CharacterStats>().playerOrder == data.playerOrder)     // Checks the playerOrder from the player controller script for the correct player to assign data to
            {
                player.GetComponent<CharacterStats>().characterName = data.characterName;                       // Initializes the character name string from the player controller script
                player.GetComponent<CharacterStats>().characterImage.sprite = data.characterImage.sprite;       // Initializes the character name string from the player controller script
                //Debug.Log("Loaded Player 1 Data");
            }

            file.Close();   // Cloeses the file
        }
        else
        {
            player.SetActive(false);    // Turns player off
        }
        */
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Deletes the player data (use when you go back from after selecting character)
    /*******************************************************************************************************/
    public void DeletePlayerData(PlayerOrder order)
    {
        switch (order)
        {
            case PlayerOrder.PLAYER_1:
                player_1.playerOrder = order;
                player_1.characterName = null;
                player_1.characterImage = null;
                break;
            case PlayerOrder.PLAYER_2:
                player_2.playerOrder = order;
                player_2.characterName = null;
                player_2.characterImage = null;
                break;
            case PlayerOrder.PLAYER_3:
                player_3.playerOrder = order;
                player_3.characterName = null;
                player_3.characterImage = null;
                break;
            case PlayerOrder.PLAYER_4:
                player_4.playerOrder = order;
                player_4.characterName = null;
                player_4.characterImage = null;
                break;
        }

        //File.Delete(GetDataPath(order));
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
    // Restarts the current scene of the game
    /*******************************************************************************************************/
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    public string characterName;        // Save and load character's name from
    public Image characterImage;        // Save and load character's image
}
/*******************************************************************************************************/