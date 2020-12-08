using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilVeggie : MonoBehaviour
{
    public static EvilVeggie S;
    [Header("Set in Inspector")]
    public float moveRange = 9.0f;
    public float moveSpeed = 5.0f;
    public float jumpHeight = 0.0f;
    public float deathDuration = 5.0f;
    public GameObject Veggie;
    [Header("Set Dynmically")]
    public Vector3 StartingPos;
    public Vector3 CurrentPos;
    public Vector3 VelocityRight;
    public Vector3 VelocityLeft;
    public bool dead;

    public Vector3 StartScale;
    public Vector3 DeadScale;
   // public GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        dead = false;
        StartingPos = this.transform.position;
        CurrentPos = StartingPos; 
        VelocityRight = new Vector3(moveSpeed, 0, 0);
        VelocityLeft = new Vector3(-moveSpeed, 0, 0);
        StartScale = this.transform.localScale;
        DeadScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // CurrentPos = this.transform.position;
        
        this.move();   
    }

    void move()
    {

        if (dead == false)
        {
            //Mathf.Lerp(min, max, Mathf.Pingpong(Time.time, 1));
            this.CurrentPos.x = Mathf.Lerp(this.StartingPos.x, this.StartingPos.x+ moveRange,Mathf.PingPong(Time.time, 1));
            this.transform.position = this.CurrentPos;

            if (jumpHeight > 0)
            {
                //jump script
            }
        }
        else
        {
            dead = true;
          
            float timer = 0.0f;
            while (timer < deathDuration)
            {
                timer += Time.deltaTime;
                float t = timer / deathDuration;
                t = t * t * t * (t * (6f * t - 15f) + 10f);
                this.transform.localScale = Vector3.Lerp(StartScale, DeadScale, t);
               
            }
        
            Invoke("killVeggie",.1f);
        }
        
    }

    public void die()
    {
        this.dead = true;
    }
   
    public void killVeggie()
    {
        
        dead = true;
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        this.transform.position = new Vector3(1000, 1000, 1000);
    }


}
