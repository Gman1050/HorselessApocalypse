using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignTransparency : MonoBehaviour
{
    private Camera mainCamera;
    private List<CharacterStats> playerList;

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
