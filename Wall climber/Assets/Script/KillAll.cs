using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillAll : MonoBehaviour {

    public Button killAll;

    public GameObject bullet;

    public Transform[] bulletPoint;

    // Use this for initialization
    void Start () {
        killAll.interactable = false;
        killAll.image.fillAmount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseAmount()
    {
        if (killAll.image.fillAmount < 1)
        {
            killAll.image.fillAmount += 0.2f;
            if(killAll.image.fillAmount >= 1)
            {
                killAll.interactable = true;
            }
        }
    }

    public void KillAll_OnClick()
    {
        foreach (var bp in bulletPoint)
        {
            Instantiate(bullet, bp.position, Quaternion.identity);
        }
        Start();

    }
}
