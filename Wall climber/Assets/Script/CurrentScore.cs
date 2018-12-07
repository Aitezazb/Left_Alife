using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowHide_CurrentScore(bool state)
    {
        this.gameObject.SetActive(true);
    }
}
