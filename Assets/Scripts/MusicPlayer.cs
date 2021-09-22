using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public AudioClip StartClip;
    public AudioClip GameClip;
    public AudioClip EndClip;

    private AudioSource music;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Music is dipplicated");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = StartClip;
            music.loop = true;
            music.Play();
        }
    }
    void OnLevelWasLoaded(int level)
    {
        Debug.Log("music player:" + level);
        music.Stop();
        if(level == 0)
        {
            music.clip = StartClip;
        }
        if (level == 1)
        {
            music.clip = GameClip;
        }
        if (level == 2)
        {
            music.clip = EndClip;
        }
        music.loop = true;
        music.Play();

    }
    
}
