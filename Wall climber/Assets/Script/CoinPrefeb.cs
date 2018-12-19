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
    void OnTriggerEnter(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameManger.GetComponent<GameManger>().IncreaseCoin();
        }
        //spriteMove = -0.1f;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
