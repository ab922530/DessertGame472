using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("UIText_HighScore", 10).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //score.text = scoreValue.ToString();

        if (scoreValue > PlayerPrefs.GetInt("UIText_HighScore", 10))
        {
            PlayerPrefs.SetInt("UIText_HighScore", scoreValue);
            highScore.text = "HighScore: " + scoreValue;
        }
    }
}

