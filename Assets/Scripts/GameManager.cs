﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string[] players;

    void Awake()
    {
        players = Input.GetJoystickNames();
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

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
