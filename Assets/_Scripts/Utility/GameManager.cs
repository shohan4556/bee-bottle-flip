using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    
    public void GameOver() {
        
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    
    public void NextLevel() {
        
    }
    
    public void ResetPlayer() {
        
    }

    public void PauseGame() {
        
    }
    
}
