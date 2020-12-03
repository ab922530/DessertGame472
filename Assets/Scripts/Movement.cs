using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Set in Inspector")]
    Rigidbody rb;
    public float runSpeed = 10f;
    public float jumpPower = 10f;

    public Vector3 VelocityRight;
    public Vector3 VelocityLeft;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Movement");
        rb = GetComponent<Rigidbody>();
        VelocityRight = new Vector3(runSpeed, 0, 0);
        VelocityLeft = new Vector3(-runSpeed, 0, 0);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        run();
    }

    void run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            rb.MovePosition(rb.position + VelocityRight * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LEft");
            rb.MovePosition(rb.position + VelocityLeft * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
        }
    }
}
