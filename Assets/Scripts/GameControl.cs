using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl S; // a private Singleton

    [Header("set in insepctor")]

    //public Text uitLevel;  // The UIText_Level Text
    //public Text uitPoints;  // The UIText_Points Text
    //public Text uitHighScore; // The UIText_HighScore Text
    public GameObject[] tables;   // An array of the levels


    [Header("Set Dynamically")]
    public int levelMax; // The number of levels
    public static int level; // The current level
    public GameObject table;

    // Start is called before the first frame update
    void Start()
    {
        S = this; // Define the Singleton
        level = 0;
        levelMax = tables.Length;
        StartLevel();
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
    }

    void Update()
    {
        UpdateGUI();

        // If goal met, start next level
        //if (Goal.goalMet)
        //    Invoke("NextLevel", 2f);
    }

    void StartLevel()
    {
        // Get rid of the old maze if one exists
        if (table != null)
            Destroy(table);

        // Instantiate the new maze
        table = Instantiate<GameObject>(tables[level]);
        table.transform.position = Vector3.zero;

       //Finish.finishMet = false;
    }

    void NextLevel()
    {
        //HighScore.CheckScoreBeaten();
        level++;

        if (level == levelMax)
        {
            level = 0;
        }

        StartLevel();
    }
}
