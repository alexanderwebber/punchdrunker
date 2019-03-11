using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Unless denoted by a commented out link, TK wrote literally everything here

// This is not being used anymore
// Using AudioManagerScript instead
// Kept for posterity/reference

public class AudioManager : MonoBehaviour
{
/*

    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioSource soundFX;

    public AudioClip MainMenuBGM;
    public AudioClip GameOverBGM;
    public AudioClip VictoryBGM;
    public AudioClip GymBGM;
    public AudioClip RankTwoMatchBGM;

    public float volumeMAX = 0.5f;

    void Start()
    {
//        audioSource = gameObject.GetComponent<AudioSource>();
        Scene s = SceneManager.GetActiveScene();

        if (s.name == "0MainMenu")
        {
            StartBGMNoLoop(MainMenuBGM);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Awake()
    {
        Scene s = SceneManager.GetActiveScene();

        if (instance == null)
        {
                instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void checkCurrentBGM(AudioClip bgm)
    {
        if (audioSource.isPlaying)
        {
            if (audioSource.clip != bgm) // change to correct BGM
            {
                StartBGMLoop(bgm);
            }
            else
            {
                Debug.Log("correct clip playing!!1");
            }
        }
        else // not playing anything
        {
            StartBGMLoop(bgm);
        }

    }



    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "0MainMenu" || scene.name == "3Credits")
        {
            checkCurrentBGM(MainMenuBGM);
        }
        if (scene.name == "1GameOver")
        {
            checkCurrentBGM(GameOverBGM);
        }
        if (scene.name == "4GymMenu" || scene.name == "8SpendEXP")
        {
            checkCurrentBGM(GymBGM);
        }
    }


    public void StartBGMLoop(AudioClip bgm)
    {
        StopBGM();
        audioSource.loop = true;
        audioSource.volume = volumeMAX;
//        audioSource.PlayOneShot(bgm);
        audioSource.clip = bgm;
        audioSource.Play();
    }

    public void StartBGMNoLoop(AudioClip bgm)
    {
        StopBGM();
        audioSource.loop = false;
        audioSource.volume = volumeMAX;
//        audioSource.PlayOneShot(bgm);
        audioSource.clip = bgm;
        audioSource.Play();
    }

    public void StopBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }


    public void newFunction()
    {
        Debug.Log("new function yo0");
    }



    public void FadeOutChange(int secNum)
    {
        float time = 1.5f;
        StartCoroutine(FadeOut(audioSource, time));
    }

    // https://medium.com/@wyattferguson/how-to-fade-out-in-audio-in-unity-8fce422ab1a8
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.volume = 0;
        audioSource.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
