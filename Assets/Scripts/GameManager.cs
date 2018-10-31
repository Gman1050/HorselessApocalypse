4using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextLevel;

    public void CompleteLevel()
    {
        Debug.Log("level complete");
        SceneManager.LoadScene(nextLevel);
    }
}
