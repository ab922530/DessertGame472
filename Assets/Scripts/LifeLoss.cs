using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeLoss : MonoBehaviour
{
    [Header("Set in  Inspector")]
    int count;
    [Header("Set Dynamically")]
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "DeathBox")
        {
            count = GameControl.lives;
            count--;
            GameControl.lives = count;
        }

        if (col.tag == "EvilVeggie")
        {
            count = GameControl.lives;
            count--;
            GameControl.lives = count;
        }
        Destroy(this.gameObject);
        Instantiate(Player);
    }

}