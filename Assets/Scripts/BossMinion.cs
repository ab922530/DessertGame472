using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMinion : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 StartPos;
    public float speed = .1f;
    public GameObject OuchBox;
    public float deathDuration = 5.0f;

    public Vector3 StartScale;
    public Vector3 DeadScale;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;   
        this.Velocity = new Vector3(-speed, 0, 0);
        this.transform.position = new Vector3(65.9f, -9.4f, -9.6f);
        StartPos = this.transform.position;
        StartScale = this.transform.localScale;
        DeadScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 1);
        OuchBox = this.gameObject.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > -5)
        {
            this.transform.Translate(Velocity * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this);
        }
        checkDeath();
    }

    public void die()
    {    
        Destroy(OuchBox);
        this.dead = true;
    }

    public void checkDeath()
    {
        if (dead == true)
        {
            float timer = 0.0f;
            while (timer < deathDuration)
            {
                timer += Time.deltaTime;
                float t = timer / deathDuration;
                t = t * t * t * (t * (6f * t - 15f) + 10f);
                this.transform.localScale = Vector3.Lerp(StartScale, DeadScale, t);

            }

            Invoke("killVeggie", .1f);
        }
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
