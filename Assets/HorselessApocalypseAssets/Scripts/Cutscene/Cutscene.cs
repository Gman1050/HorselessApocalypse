using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class Cutscene : MonoBehaviour
{
    //[Range(0,1)] public float startDelay = 0.1f;

    private VideoPlayer videoPlayer;
    private StandaloneInputModule inputModule;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        inputModule = EventSystem.current.GetComponent<StandaloneInputModule>();
    }

    // Use this for initialization
    void Start ()
    {
        //StartCoroutine(DelayStart(startDelay));
        StartCoroutine(CutsceneEnd());
	}
	
	// Update is called once per frame
	void Update ()
    {
        SkipCutscene();

    }

    private void SkipCutscene()
    {
        if (inputModule.input.GetButtonDown(inputModule.submitButton))
        {
            GameManager.Instance.ChangeScene("Main Menu");
        }
    }

    private IEnumerator DelayStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        videoPlayer.Play();
    }

    private IEnumerator CutsceneEnd()
    {
        yield return new WaitForSeconds((float)videoPlayer.clip.length);
        GameManager.Instance.ChangeScene("Main Menu");
    }
}
