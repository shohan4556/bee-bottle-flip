using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    
    [Space(15)] 
    public Sprite musicOn;
    public Sprite musicOff;

    [Header("UI")] 
    public Image soundImg;
    public Image musicImg;
    
    private bool sss = true;
    private bool mmm = true;
    
    // Start is called before the first frame update
    void Start()
    {
          sss = true;
          mmm = true;
          
          Init();
    }

    void Init() {

        sss = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
        mmm = Convert.ToBoolean(PlayerPrefs.GetInt("music"));

        if (sss)
            soundImg.sprite = soundOn;
        else
            soundImg.sprite = soundOff;
        
        
        if (mmm)
            musicImg.sprite = musicOn;
        else
            musicImg.sprite = musicOff;
    }

    public void TapOnSound() {
        //print("sound");
        sss = !sss;
        if (!sss) {
            //print("on");
            soundImg.sprite = soundOff;
        }
        if (sss) {
           // print("off");
            soundImg.sprite = soundOn;
        }
        PlayerPrefs.SetInt("sound", Convert.ToInt32(sss));
        PlayerPrefs.Save();
        SoundManager.Instance.PlayTapSFX();
    }

   
    public void TapOnMusic() {
        SoundManager.Instance.PlayTapSFX();
        //print("music");
        mmm = !mmm;
        if (!mmm) {
            musicImg.sprite = musicOff;
        }
        else if (mmm) {
            musicImg.sprite = musicOn;
        }
        PlayerPrefs.SetInt("music", Convert.ToInt32(mmm));
        PlayerPrefs.Save();
        SoundManager.Instance.PlayAppMusic();
    }

   
}
