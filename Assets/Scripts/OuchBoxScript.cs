using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchBoxScript : MonoBehaviour
{
    //EvilVeggie pscript;
    // Start is called before the first frame update
    int count;
    void Start()
    {
        //pscript = transform.parent.gameObject.GetComponent<LifeLoss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "chunkyKid")
        {
            Debug.Log("OUCH");
            count = GameControl.lives;
            count--;
            GameControl.lives = count;

        }

    }
}
