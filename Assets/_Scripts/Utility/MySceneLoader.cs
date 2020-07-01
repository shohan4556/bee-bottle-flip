using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next) {
        //print("scene changed");
        
        if (next.name == "Infinity_Level") {
            SoundManager.Instance.PlayAppMusic();
        }

        if (next.name != "Infinity_Level") {
            SoundManager.Instance.music_src.Stop();
        }
    }

    public void LoadScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void RestartLevel() {
        //todo get last played level 
        int idx = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(idx);
    }
}
