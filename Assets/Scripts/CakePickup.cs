using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePickup : MonoBehaviour
{
    Rigidbody rb;
    Vector3 angleturn;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angleturn = new Vector3(0, 360, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRot = Quaternion.Euler(angleturn * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "chunkyKid")
        {
            count = GameControl.score;
            count = count + 100;
            GameControl.score = count;
            Debug.Log("hit");
            Destroy(this.gameObject);
        }
    }
}
