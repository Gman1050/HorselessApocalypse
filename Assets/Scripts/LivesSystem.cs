using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour
{
    private int livesCount = 4;

    public int LivesCount { get { return livesCount; } }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            livesCount = 4;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoseLife()
    {
        livesCount -= 1;
    }

    public void GainLife()
    {
        livesCount += 1;
    }
}
