using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource backgroundSound;
    public AudioSource effectSound;

    [Header("Audio Clip (Background)")]
    public AudioClip menu;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4;
    public AudioClip level5;

    [Header("Audio Clip (Effect)")]
    public AudioClip click;
    public AudioClip lazerShoot;
    public AudioClip boom;
    public AudioClip hurt;
    public AudioClip blackHoleOpen;
    public AudioClip blackHoleIn;

    // SINGLETON
    public static AudioManager Instance { get; private set; }
    //

    private void Awake()
    {
        // SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        //


    }

    private void Start()
    {
        backgroundSound.clip = menu;
        backgroundSound.Play();
    }

    public void PlayBackground(AudioClip sound)
    {
        backgroundSound.clip = sound;
        backgroundSound.Play();
    }

    public void PlayEffect(AudioClip sound)
    {
        effectSound.clip = sound;
        effectSound.Play();
    }

    public void Pause()
    {
        backgroundSound.Pause();
    }

    public void Continue()
    {
        backgroundSound.UnPause();
    }
}
