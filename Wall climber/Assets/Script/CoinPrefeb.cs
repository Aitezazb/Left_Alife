using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefeb : MonoBehaviour {

    private GameObject gameManger;
	// Use this for initialization
	void Start () {
        gameManger = GameObject.Find("GameManger");
        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameManger.GetComponent<GameManger>().IncreaseCoin();
            Destroy(gameObject);
            

        }
        if (coll.gameObject.tag == "Emeny")
        {
            gameManger.GetComponent<GameManger>().DecreaseScore();
            Destroy(gameObject);
            
        }
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
