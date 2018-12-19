using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefeb : MonoBehaviour {

    private GameObject gameManger;
	// Use this for initialization
	void Start () {
        gameManger = GameObject.Find("GameManger");
        Destroy(gameManger, 3f);
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameManger.GetComponent<GameManger>().IncreaseCoin();

        }
        if (coll.gameObject.tag == "Emeny")
        {
            Destroy(gameObject);
            gameManger.GetComponent<GameManger>().DecreaseScore();
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
