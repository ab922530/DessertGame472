using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchBoxScript : MonoBehaviour
{
    EvilVeggie pscript;
    // Start is called before the first frame update
    void Start()
    {
        //pscript = transform.parent.gameObject.GetComponent<InsertLifeLostScriptHere>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "chunkyKid")
        {
          //  pscript.Invoke("livelostmethod", 0f);
        }

    }
}
