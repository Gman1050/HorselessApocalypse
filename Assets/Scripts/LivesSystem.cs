using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LivesSystem : MonoBehaviour
{
    public static LivesSystem Instance;

    public GameObject continueButton;
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
        if (GameManager.Instance.PlayerLivesText)
        {
            GameManager.Instance.PlayerLivesText.text = "Lives: " + livesCount;
        }

        if (gameOverScreen)
        {
            if (LivesCount <= 0)
            {
                gameOverScreen.SetActive(true);
                if (!EventSystem.current.currentSelectedGameObject == continueButton)
                {
                    EventSystem.current.SetSelectedGameObject(continueButton);
                }
                Time.timeScale = 0;
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

    public void BackToMainMenu()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.ChangeScene("Main Menu");
    }

    public void ResetScene()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().name);
    }

    public void PlayHighlightSound()
    {
        AudioManager.Instance.PlayUIAudioClip(2);
    }
    
    public void PlaySelectSound()
    {
        AudioManager.Instance.PlayUIAudioClip(1);
    }
}
