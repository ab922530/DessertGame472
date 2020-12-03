using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Set in Inspector")]
    Rigidbody rb;
    Rigidbody rbR;
    Rigidbody rbL;
    public GameObject legR;
    public GameObject legL;
    public float runSpeed = 10f;
    public float jumpPower = 20f;

    public Vector3 VelocityRight;
    public Vector3 VelocityLeft;
    public Vector3 VelocityUp;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Movement");
        rb = GetComponent<Rigidbody>();
        VelocityRight = new Vector3(runSpeed, 0, 0);
        VelocityLeft = new Vector3(-runSpeed, 0, 0);
        VelocityUp = new Vector3(0, jumpPower, 0);
        legR = this.gameObject.transform.GetChild(2).GetChild(0).gameObject;
        legL = this.gameObject.transform.GetChild(2).GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // legR.transform.rotation = Quaternion.Euler(0, 0, 45);
        run();
    }

    void run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            rb.MovePosition(rb.position + VelocityRight * Time.fixedDeltaTime);

            legR.transform.rotation = Quaternion.Euler(0, 0, 45);
            legL.transform.rotation = Quaternion.Euler(0, 0, -45);
            if (legR.transform.eulerAngles.z == -45)
            {
                legR.transform.rotation = Quaternion.Euler(0, 0, 45);
                legL.transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            if (legR.transform.eulerAngles.z == 45)
            {
                legR.transform.rotation = Quaternion.Euler(0, 0, -45);
                legL.transform.rotation = Quaternion.Euler(0, 0, 45);
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LEft");
            rb.MovePosition(rb.position + VelocityLeft * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + VelocityUp * Time.fixedDeltaTime);
        }
    }
}
