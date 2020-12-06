using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl S; // a private Singleton

    [Header("set in insepctor")]
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
}
