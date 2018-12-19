using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCoin : MonoBehaviour {

    public Transform[] coinPoints;
    public GameObject Coin;
	// Use this for initialization
	void Start () {
        

    }
	
    public void StartInvoking()
    {
        InvokeRepeating("MakeCoin",5f,12f);
    }

    private void MakeCoin()
    {
        int randomPoint = Random.Range(0, coinPoints.Length);
        var s=Instantiate(Coin, coinPoints[randomPoint].position, Quaternion.identity);
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
