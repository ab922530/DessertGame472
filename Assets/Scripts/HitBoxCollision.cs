﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCollision : MonoBehaviour
{
    EvilVeggie pscript;
    // Start is called before the first frame update
    void Start()
    {
        pscript = transform.parent.gameObject.GetComponent<EvilVeggie>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "chunkyKid")
        {
            pscript.Invoke("die", 0f);
        }
         
    }
}
