using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
     public int score = 0;

    public string scoreName = "Score";

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

   

    public void UpdateScore(int givenChange = 1) {
        score += givenChange;
        scoreText.text = scoreName + ": " + score;
        PlayerPrefs.SetInt("Score", score);
    }


}

