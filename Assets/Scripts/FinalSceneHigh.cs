using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneHigh : MonoBehaviour
{
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        t.text = "High Score: " + PlayerPrefs.GetInt("UIText_HighScore", 10).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "High Score: " + PlayerPrefs.GetInt("UIText_HighScore", 10).ToString();
    }
}

