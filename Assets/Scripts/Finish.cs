using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static bool finishMet = false;

    void OnTriggerEnter(Collider other)
    {
        print("finish has been met");
        if (other.gameObject.tag == "chunkyKid")
        {
            finishMet = true;
        }
    }
}
