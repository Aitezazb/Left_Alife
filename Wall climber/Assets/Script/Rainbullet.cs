using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbullet : MonoBehaviour {

    public int speed = 1;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
            this.transform.Translate(0,-speed * Time.deltaTime, 0);
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Emeny")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
