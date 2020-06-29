using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignTransparency : MonoBehaviour
{
    public List<Room> rooms;
    
    private Camera mainCamera;
    private List<CharacterStats> playerList;

    [System.Serializable]
    public struct Room
    {
        public GameObject room;
        public List<Material> roomMaterial;
    };

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        var players = FindObjectsOfType<CharacterStats>();

        foreach(CharacterStats p in players)
            playerList.Add(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
