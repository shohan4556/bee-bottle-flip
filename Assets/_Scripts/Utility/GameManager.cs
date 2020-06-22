using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Pause UI")] 
    public GameObject pauseUI;
    
    private void Awake() {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start() {
        
    }

    public void LevelComplete() {
        // todo coins collect animations 
        print("level completed");
        RestartLevel();
    }
    
    public void GameOver(string name) {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    
    public void NextLevel() {
        
    }
    
    public void ResetPlayer() {
        
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
