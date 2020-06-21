using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource music_src;
    public AudioSource sfx_src;
    
    public AudioClip tap;
    public AudioClip appmusic;
    public AudioClip levelcomplete;
    public AudioClip gameover;
    
    private void Awake() {
        
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start() {
        // init 
        if (!PlayerPrefs.HasKey("sound")) {
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.SetInt("music", 1);
        }
        
        if(SceneManager.GetActiveScene().name == "Menu")
            PlayAppMusic();
    }

    public void PlayAppMusic() {
        if (PlayerPrefs.GetInt("music") == 0) {
            music_src.Stop();
            return;
        }
            
        if (!music_src.isPlaying) {
            music_src.loop = true;
            music_src.Play();
        }
    }    
    
    public void PlayTapSFX() {
        if(PlayerPrefs.GetInt("sound") == 0)
            return;
        
        sfx_src.clip = tap;
        sfx_src.Play();
    }

    public void PlayLevelCompleteSFX() {
        if(PlayerPrefs.GetInt("sound") == 0)
            return;
        
        sfx_src.clip = levelcomplete;
        sfx_src.Play();
    }
   

    public void PlayLoseSFX() {
        if(PlayerPrefs.GetInt("sound") == 0)
            return;
        
        sfx_src.clip = gameover;
        sfx_src.Play();
    }

   
   
}
