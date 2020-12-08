using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Set in Inspector")]
    Rigidbody rb;
    public Movement S;
    public GameObject legR;
    public GameObject legL;
    public float runSpeed = 10f;
    public float jumpPower = 50f;
    public int count;
    public Vector3 VelocityRight;
    public Vector3 VelocityLeft;
    public Vector3 VelocityUp;
    public Vector3 maxVelocity;
    public Vector3 startPos;
    public float maxAngleR = 45f;
    public float maxAngleL = 45f;
    public float legSpeed = 10f;
    public bool hitSpike;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        hitSpike = false;
        startPos = this.transform.position;
        Debug.Log("Movement");
        rb = GetComponent<Rigidbody>();
        VelocityRight = new Vector3(runSpeed, 0, 0);
        VelocityLeft = new Vector3(-runSpeed, 0, 0);
        VelocityUp = new Vector3(0, 12f, 0);
        maxVelocity = new Vector3(0, 12f, 0);
        legR = this.gameObject.transform.GetChild(2).GetChild(0).gameObject;
        legL = this.gameObject.transform.GetChild(2).GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // legR.transform.rotation = Quaternion.Euler(0, 0, 45);
        run();
        checkPos();
        //checkSpikes();
    }
    void checkPos()
    {
        //Debug.Log(hitSpike);
        if (this.transform.position.y < -25 || hitSpike == true)
        {
            count = GameControl.lives;
            count--;
            GameControl.lives = count;
            this.transform.position = startPos;
        }

    }
  
 
    void run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //character movement
            rb.MovePosition(rb.position + VelocityRight * Time.fixedDeltaTime);

           /* if (this.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }*/

            //leg animation
            float angle = maxAngleR * Mathf.Sin(Time.time * legSpeed);
            legR.transform.rotation = Quaternion.Euler(0, 0, angle);
            float angleL = maxAngleL * Mathf.Sin(Time.time * legSpeed);
            legL.transform.rotation = Quaternion.Euler(0, 0, -angleL);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //reset leg pos
        {
            legR.transform.rotation = Quaternion.Euler(0, 0, 0);
            legL.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //flip direction
           /* if (this.transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }*/
            //character movement
            rb.MovePosition(rb.position + VelocityLeft * Time.fixedDeltaTime);

           
            //leg animation
            float angle = maxAngleR * Mathf.Sin(Time.time * legSpeed);
            legR.transform.rotation = Quaternion.Euler(0, 0, angle);
            float angleL = maxAngleL * Mathf.Sin(Time.time * legSpeed);
            legL.transform.rotation = Quaternion.Euler(0, 0, -angleL);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) //reset leg pos
        {
            legR.transform.rotation = Quaternion.Euler(0, 0, 0);
            legL.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            if (rb.velocity.y < maxVelocity.y)
            {
                
                rb.AddForce(VelocityUp, ForceMode.Impulse);
            }
            
           
           
            //rb.MovePosition(rb.position + VelocityUp * Time.fixedDeltaTime);
        }

    }

    void OnCollisionStay()
    {
        //Debug.Log("hello");
        isGrounded = true;
    }
}
