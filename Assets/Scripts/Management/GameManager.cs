using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerQuantity;

    private bool characterDataSaved = false;

    public bool CharacterDataSaved { get { return characterDataSaved; } }

    void Awake()
    {
        Instance = this;    
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    
    public void SavePlayerData(PlayerOrder order, string character)
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerData data = new PlayerData();
        FileStream file;

        if (!File.Exists(Application.persistentDataPath + "/playerInfo.data"))
        {
            file = File.Create(Application.persistentDataPath + "/playerInfo.data");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/playerInfo.data", FileMode.Open);
        }

        data.playerOrder = order;
        data.character = character;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadPlayerData(PlayerOrder order, string character)
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.data", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            order = data.playerOrder;
            character = data.character;

            File.Delete(Application.persistentDataPath + "/playerInfo.data");
        }
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

[Serializable]
class PlayerData
{
    public PlayerOrder playerOrder;
    public string character;

}
