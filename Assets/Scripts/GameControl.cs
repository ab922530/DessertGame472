using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl S; // a private Singleton

    [Header("set in insepctor")]

    public Text uitLevel;  // The UIText_Level Text
    public Text uitPoints;  // The UIText_Points Text
    public Text uitHighScore; // The UIText_HighScore Text
    public Text uitLives; // The UIText_HighScore Text
    public Text uiGameOver; // The UIText_GameOver Text
    public GameObject buttonImage;

    public GameObject[] tables;   // An array of the levels


    [Header("Set Dynamically")]
    public int levelMax; // The number of levels
    public static int level; // The current level
    public static int lives; // Current Lives
    public static int score; // Current Score
    public GameObject table;

    // Start is called before the first frame update
    void Start()
    {
        S = this; // Define the Singleton
        level = 0;
        score = 0;
        levelMax = tables.Length;
        lives = 10;
        uiGameOver.enabled = false;
        buttonImage.SetActive(false);
        uitHighScore.text = "HighScore: " + PlayerPrefs.GetInt("UIText_HighScore", 10).ToString();

        StartLevel();
    }

    void UpdateUI()
    {
        // Show the data in the UITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitLives.text = "Lives: " + lives;
        uitPoints.text = "Points: " + score;

        if (score > PlayerPrefs.GetInt("UIText_HighScore", 10))
        {
            PlayerPrefs.SetInt("UIText_HighScore", score);
            uitHighScore.text = "HighScore: " + score;
        }
    }

    void Update()
    {
        UpdateUI();

        // End game if out of lives or levels
        if (lives <= 0)
        {
            GameOver();
            lives = 0;
            return;
        }

        // If goal met, start next level
        if (Finish.finishMet == true)
        {
            Invoke("NextLevel", 0f);
        }
    }

    void StartLevel()
    {
        // Get rid of the old table if one exists
        if (table != null)
            Destroy(table);

        // Instantiate the new table
        table = Instantiate<GameObject>(tables[level]);
        table.transform.position = Vector3.zero;

        Finish.finishMet = false;
    }

    void NextLevel()
    {
        //HighScore.CheckScoreBeaten();
        level++;

        if (level >= levelMax)
        {
            GameOver();
            return;
        }

        StartLevel();
    }

    void GameOver()
    {
        Destroy(table);
        buttonImage.SetActive(true);
        uiGameOver.enabled = true;
        uiGameOver.text = "Game Over!\n"
                        + "High Score: " + PlayerPrefs.GetInt("UIText_HighScore", 10).ToString();
    }
}
