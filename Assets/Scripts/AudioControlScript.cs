using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// TK wrote, got started by using tutorials
// like this one: https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioControlScript : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioClip battleMusic;
    public AudioClip menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        Scene s = SceneManager.GetActiveScene();

        GameObject go = GameObject.Find("MusicPlayer");
        musicPlayer = go.GetComponent<AudioSource>();

        if (s.name == "5Match")
        {
            Debug.Log("YOU ARE IN MATCH SCENE!");
            musicPlayer.Stop();
            musicPlayer.clip = battleMusic;
            musicPlayer.Play();
        }
        else
        {
            if (musicPlayer.clip == battleMusic)
            {
                musicPlayer.Stop();
                musicPlayer.clip = menuMusic;
                musicPlayer.Play();
            }
            else
            {
                if(!musicPlayer.isPlaying)
                {
                    musicPlayer.clip = menuMusic;
                    musicPlayer.Play();
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
