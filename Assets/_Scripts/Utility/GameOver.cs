using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;

    public Text highScore;
    
    // Start is called before the first frame update
    void Start() {
        int s = PlayerPrefs.GetInt("SCORE");
        int best = PlayerPrefs.GetInt("BEST");

        score.text = "Score : "+s.ToString();
        highScore.text = "Best Score : "+best.ToString();
        
        //PlayerPrefs.SetInt("SCORE", 0);
        PlayerPrefs.Save();
    }

    
}
