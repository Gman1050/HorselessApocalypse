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
    private bool isGameOver = false;
    private Scene lastScene;

    public int LivesCount { get { return livesCount; } }

    void Awake()
    {
        Instance = this;

        livesCount = startingLives;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        // Keep track of lives on display
        if (GameManager.Instance.PlayerLivesText)
            GameManager.Instance.PlayerLivesText.text = "Lives: " + livesCount;

        // Keeps the Time.timeScale from being stuck at 0 until the a scene is loaded.
        if (SceneManager.GetActiveScene() == lastScene)
            return;

        // Load game over screen.
        if (!isGameOver)
        {
            if (LivesCount <= 0)
            {
                gameOverScreen.SetActive(true);
                EventSystem.current.SetSelectedGameObject(continueButton);
                Time.timeScale = 0;
                isGameOver = true;
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
        lastScene = SceneManager.GetActiveScene();
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.Instance.ChangeScene("Main Menu");
        isGameOver = false;
    }

    public void ResetScene()
    {
        lastScene = SceneManager.GetActiveScene();
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.Instance.RestartScene();
        isGameOver = false;
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
