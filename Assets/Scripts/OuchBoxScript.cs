using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchBoxScript : MonoBehaviour
{
    //EvilVeggie pscript;
    // Start is called before the first frame update
    int count;
    int touched;
    void Start()
    {
        touched = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "chunkyKid")
        {
            if (touched == 0)
            {
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
