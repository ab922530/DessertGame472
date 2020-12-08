using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public int blives;
   // public var rend;
   int Counter = 0;
    public GameObject minion;
    public GameObject cake;
    Material m;
    Material m1;
    bool make;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        make = true;
        InvokeRepeating("makeMinion", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Time.time > 25f)
        {
            make = false;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }

            this.transform.position = new Vector3(1000, 1000, 1000);
            Invoke("finish", 3f) ;
        }
    }
   

void makeMinion()
    {
        if(make)
        Instantiate(minion);
        
    }

    void finish()
    {

        SceneManager.LoadScene("Win", LoadSceneMode.Single);

    }
}
