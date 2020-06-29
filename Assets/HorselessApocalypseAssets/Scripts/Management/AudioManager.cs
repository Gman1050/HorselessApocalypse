using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("User Interface Audio:")]
    public AudioSource UIAudio;
    [Range(0, 1)] public float UIVolume = 0.5f;
    public List<AudioClip> UIClips = new List<AudioClip>();

    [Header("Player Audio:")]
    public AudioSource playerAudio;
    [Range(0, 1)] public float playerVolume = 0.75f;
    public List<AudioClip> playerClips = new List<AudioClip>();

    [Header("Enemy Audio:")]
    public AudioSource enemyAudio;
    [Range(0, 1)] public float enemyVolume = 0.75f;
    public List<AudioClip> enemyClips = new List<AudioClip>();

    [Header("Music Audio:")]
    public AudioSource musicAudio;
    [Range(0, 1)] public float musicVolume = 0.2f;
    public List<AudioClip> musicClips = new List<AudioClip>();

    private void Awake()
    {
        Instance = this;    
    }

    // Use this for initialization
    void Start ()
    {
        // Set Level music here
        MusicSetup();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void MusicSetup()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Main Menu":
                PlayMusicAudioClip(1);
                break;
            case "Level 1":
                PlayMusicAudioClip(1);
                break;
            case "Level 2":
                PlayMusicAudioClip(4);
                break;
        }
    }

    public void PlayUIAudioClip(int clip)
    {
        UIAudio.volume = UIVolume;
        UIAudio.PlayOneShot(UIClips[clip]);
    }

    public void PlayPlayerAudioClip2D(int clip)
    {
        playerAudio.volume = playerVolume;
        playerAudio.PlayOneShot(playerClips[clip]);
    }

    public void PlayPlayerAudioClip3D(AudioSource source, int clip)
    {
        source.volume = playerVolume;
        source.PlayOneShot(playerClips[clip]);
    }

    public void PlayEnemyAudioClip2D(int clip)
    {
        enemyAudio.volume = enemyVolume;
        enemyAudio.PlayOneShot(enemyClips[clip]);
    }

    public void PlayEnemyAudioClip3D(AudioSource source, int clip)
    {
        source.volume = enemyVolume;
        source.PlayOneShot(enemyClips[clip]);
    }

    public void PlayMusicAudioClip(int clip)
    {
        musicAudio.volume = musicVolume;
        musicAudio.loop = true;
        musicAudio.PlayOneShot(musicClips[clip]);
    }
}
