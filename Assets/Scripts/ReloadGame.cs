using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadGame : MonoBehaviour
{
    public Button but;
    public void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick()
    {
        SceneManager.LoadScene("Scene_1", LoadSceneMode.Single);
    }

}
