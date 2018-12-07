using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletfire : MonoBehaviour {
    public int speed = 1;

    public byte Dir;
   // Driection d;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Fire();
	}
    void Fire()
    {
        if (Dir == 0)
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Emeny")
        {
            Destroy(gameObject);
        }
    }



}
