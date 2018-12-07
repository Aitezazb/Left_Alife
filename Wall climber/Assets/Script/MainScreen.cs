using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour {
    
    public GameObject Main1;
    public GameObject Player;
    public GameObject Settings;

    public GameObject UpgradeGun_Page;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowHide_MainScreen(bool state)
    {
        this.gameObject.SetActive(state);
    }

    public void SettingbtN_Onclick()
    {
        Player.SetActive(false);
        Main1.SetActive(false);
        Settings.SetActive(true);
    }
    public void UpGradeGun_OnClick()
    {
        this.Player.SetActive(false);
        this.gameObject.SetActive(false);
        this.UpgradeGun_Page.SetActive(true);
    }
}
