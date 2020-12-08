using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHitbox : MonoBehaviour
{
    BossMinion pscript;
    public BossScript bScript;
    public GameObject bigboi;
    int touched;
    // Start is called before the first frame update
    void Start()
    {
        touched = 0;
        bScript = bigboi.GetComponent<BossScript>();
        pscript = transform.parent.gameObject.GetComponent<BossMinion>();

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
                bScript.Invoke("hurt", 0f);
                pscript.Invoke("die", 0f);
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
