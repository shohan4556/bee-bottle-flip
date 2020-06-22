using System;
using System.Collections;
using System.Collections.Generic;
using GM_Infinity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Pause UI")] 
    public GameObject pauseUI;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private PlayerController _playerController;

    public int SCORE = 0;
    
    private void Awake() {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start() {
        pauseUI.SetActive(false);
    }

    public void UpdateScore(int s) {
        SCORE += s;
        scoreTxt.text = SCORE.ToString();
    }
    
    public void LevelComplete() {
        // todo coins collect animations 
        print("level completed");
    }
    
    public void GameOver(string name) {
        SaveScore();
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    private void SaveScore() {
        int best_score = PlayerPrefs.GetInt("BEST");
        if (SCORE > best_score) {
            PlayerPrefs.SetInt("BEST", SCORE);
        }
        PlayerPrefs.SetInt("SCORE", SCORE);
        PlayerPrefs.Save();
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
