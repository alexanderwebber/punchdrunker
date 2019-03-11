using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TK wrote, using tutorials
// like this one: https://www.youtube.com/watch?v=6OT43pvUyfY

public class MusicPlayerScript : MonoBehaviour
{
    public static MusicPlayerScript bgmInstance;

    void Awake()
    {
        if (bgmInstance == null)
        {
            bgmInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}