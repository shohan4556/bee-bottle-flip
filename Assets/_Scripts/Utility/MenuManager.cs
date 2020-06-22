using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text best_score_Text;
    // Start is called before the first frame update
    void Start()
    {
        int best = PlayerPrefs.GetInt("BEST");
        best_score_Text.text = "BEST SCORE : "+best.ToString();
    }

    
}
