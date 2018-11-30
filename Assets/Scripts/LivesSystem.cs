using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour
{
    public static LivesSystem Instance;

    public GameObject gameOverScreen;
    public int startingLives = 4;

    private int livesCount = 4;

    public int LivesCount { get { return livesCount; } }

    void Awake()
    {
        Instance = this;

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            livesCount = startingLives;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (gameOverScreen)
        {
            if (LivesCount <= 0)
            {
                gameOverScreen.SetActive(true);
            }
        }
    }

    public void ResetLives()
    {
        livesCount = startingLives;
    }

    public void LoseLife()
    {
        if (LivesCount > 0)
        {
            livesCount -= 1;
        }
    }

    public void GainLife()
    {
        livesCount += 1;
    }
}
