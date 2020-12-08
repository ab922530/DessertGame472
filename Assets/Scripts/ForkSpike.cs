using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkSpike : MonoBehaviour
{
    int touched;
    int count;
    public GameObject chunker;
    public Movement move;
    public Vector3 startPos;
    void Start()
    {
        touched = 0;
        startPos = chunker.transform.position;
    }
    void OnTriggerEnter(Collider col)
    {
    
        if (col.tag == "chunkyKid")
        {
          
            if (touched == 0)
            {
                chunker.transform.position = startPos;
                touched = 1;
                Debug.Log("OUCH");
                count = GameControl.lives;
                count--;
                GameControl.lives = count;
                
                
               
            }

        }

    }
    void OnTriggerExit(Collider col)
    {
        if (touched == 1)
        {
            touched = 0;
        }
    }
}

