using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [Header("set in insepctor")]
    public GameObject[] levels;   // An array of the levels
    public static int levelNum; // The current level
    private int levelMax; // The number of levels
    private GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        levelNum = 0;
        levelMax = levels.Length;
           
    StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartLevel()
    {
        // Get rid of the old maze if one exists
        if (level != null)
            Destroy(level);

        // Instantiate the new maze
        level = Instantiate<GameObject>(levels[levelNum]);
        level.transform.position = Vector3.zero;

        //Finish.finishMet = false;
       // RewriteUI();
    }
}
