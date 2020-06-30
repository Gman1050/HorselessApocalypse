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
    public ScreenFader screenFaderCanvas;
    public LivesSystem livesSystemPrefab;

    public int playerQuantity;              // Checks the quantity of players on the Main menu for Debugging purposes
    public PlayerDataContainer player_1, player_2, player_3, player_4;
    private Text playerLivesText;

    public Text PlayerLivesText { get { return playerLivesText; } }

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
        if (!LivesSystem.Instance)
            Instantiate(livesSystemPrefab, livesSystemPrefab.transform.position, transform.rotation);

        if (GameObject.Find("PlayerLivesText"))
        {
            playerLivesText = GameObject.Find("PlayerLivesText").GetComponent<Text>();
            playerLivesText.text = "";
        }

        screenFaderCanvas.CallScreenFadeToClearCouroutine();
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
                SetSpecials(order, name);
                break;
            case PlayerOrder.PLAYER_2:
                player_2.playerOrder = order;
                player_2.characterName = name;
                player_2.characterImage = image;
                SetSpecials(order, name);
                break;
            case PlayerOrder.PLAYER_3:
                player_3.playerOrder = order;
                player_3.characterName = name;
                player_3.characterImage = image;
                SetSpecials(order, name);
                break;
            case PlayerOrder.PLAYER_4:
                player_4.playerOrder = order;
                player_4.characterName = name;
                player_4.characterImage = image;
                SetSpecials(order, name);
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
                    Debug.Log(player.characterImage.sprite);
                    Debug.Log(player_1.characterImage);
                    player.characterImage.sprite = player_1.characterImage;
                    player.specialAttack = player_1.specialAttack;
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
                    player.specialAttack = player_2.specialAttack;
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
                    player.specialAttack = player_3.specialAttack;
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
                    player.specialAttack = player_4.specialAttack;
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
                player_1.specialAttack = SpecialAttacks.NONE;
                break;
            case PlayerOrder.PLAYER_2:
                player_2.playerOrder = order;
                player_2.characterName = null;
                player_2.characterImage = null;
                player_2.specialAttack = SpecialAttacks.NONE;
                break;
            case PlayerOrder.PLAYER_3:
                player_3.playerOrder = order;
                player_3.characterName = null;
                player_3.characterImage = null;
                player_3.specialAttack = SpecialAttacks.NONE;
                break;
            case PlayerOrder.PLAYER_4:
                player_4.playerOrder = order;
                player_4.characterName = null;
                player_4.characterImage = null;
                player_4.specialAttack = SpecialAttacks.NONE;
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
        CallChangeSceneCoroutine(scene);
    }

    public void CallChangeSceneCoroutine(string scene)
    {
        StartCoroutine(ChangeSceneCoroutine(scene));
    }

    private IEnumerator ChangeSceneCoroutine(string scene)
    {
        screenFaderCanvas.CallScreenFadeToSolidCouroutine();

        yield return new WaitUntil(() => screenFaderCanvas.IsScreenSolid); 
        SceneManager.LoadScene(scene);
        LivesSystem.Instance.ResetLives();
        Debug.Log("Change Scene");
    }

    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Restarts the current scene of the game
    /*******************************************************************************************************/
    public void RestartScene()
    {
        StartCoroutine(RestartSceneCoroutine());
    }

    private IEnumerator RestartSceneCoroutine()
    {
        screenFaderCanvas.CallScreenFadeToSolidCouroutine();

        yield return new WaitUntil(() => screenFaderCanvas.IsScreenSolid);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LivesSystem.Instance.ResetLives();
        Debug.Log("Restart Scene");
    }

    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Exits the game from the main menu
    /*******************************************************************************************************/
    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }
    private IEnumerator ExitGameCoroutine()
    {
        screenFaderCanvas.CallScreenFadeToSolidCouroutine();

        yield return new WaitUntil(() => screenFaderCanvas.IsScreenSolid);
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

    /*******************************************************************************************************/
    // Sets the specials for each character selected when saved
    /*******************************************************************************************************/
    private void SetSpecials(PlayerOrder playerOrder, string characterName)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                switch (characterName)
                {
                    case "Gregorio: The Horseman of War":
                        player_1.specialAttack = SpecialAttacks.WAR;
                        break;
                    case "Celestino: The Horseman of Famine":
                        player_1.specialAttack = SpecialAttacks.FAMINE;
                        break;
                    case "Falconi: The Horseman of Pestilence":
                        player_1.specialAttack = SpecialAttacks.PESTILENCE;
                        break;
                    case "Artesia: The Horseman of Death":
                        player_1.specialAttack = SpecialAttacks.DEATH;
                        break;
                }
                break;
            case PlayerOrder.PLAYER_2:
                switch (characterName)
                {
                    case "Gregorio: The Horseman of War":
                        player_2.specialAttack = SpecialAttacks.WAR;
                        break;
                    case "Celestino: The Horseman of Famine":
                        player_2.specialAttack = SpecialAttacks.FAMINE;
                        break;
                    case "Falconi: The Horseman of Pestilence":
                        player_2.specialAttack = SpecialAttacks.PESTILENCE;
                        break;
                    case "Artesia: The Horseman of Death":
                        player_2.specialAttack = SpecialAttacks.DEATH;
                        break;
                }
                break;
            case PlayerOrder.PLAYER_3:
                switch (characterName)
                {
                    case "Gregorio: The Horseman of War":
                        player_3.specialAttack = SpecialAttacks.WAR;
                        break;
                    case "Celestino: The Horseman of Famine":
                        player_3.specialAttack = SpecialAttacks.FAMINE;
                        break;
                    case "Falconi: The Horseman of Pestilence":
                        player_3.specialAttack = SpecialAttacks.PESTILENCE;
                        break;
                    case "Artesia: The Horseman of Death":
                        player_3.specialAttack = SpecialAttacks.DEATH;
                        break;
                }
                break;
            case PlayerOrder.PLAYER_4:
                switch (characterName)
                {
                    case "Gregorio: The Horseman of War":
                        player_4.specialAttack = SpecialAttacks.WAR;
                        break;
                    case "Celestino: The Horseman of Famine":
                        player_4.specialAttack = SpecialAttacks.FAMINE;
                        break;
                    case "Falconi: The Horseman of Pestilence":
                        player_4.specialAttack = SpecialAttacks.PESTILENCE;
                        break;
                    case "Artesia: The Horseman of Death":
                        player_4.specialAttack = SpecialAttacks.DEATH;
                        break;
                }
                break;
        }
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