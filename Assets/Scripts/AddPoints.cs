using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{

    public int count = 0;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Cake")
        {
            count = GameControl.score;
            count = count + 100;
            GameControl.score = count;
        }

        if (col.tag == "HitBox")
        {
            count = GameControl.score;
            count = count + 50;
            GameControl.score = count;
        }
    }
}
