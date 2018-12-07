using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public GameObject Main1;
    public GameObject Player;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BackBtn_Onclick()
    {
        this.gameObject.SetActive(false);
        Main1.SetActive(true);
        Player.SetActive(true);
    }
}
