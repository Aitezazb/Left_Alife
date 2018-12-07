using System;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeGunManger : MonoBehaviour {

    public byte ActiveGun { private set; get; }

    public Text AmountOfCoins;
    private int RequiredCoins_Gun1;
    private int RequiredCoins_Gun2;

    public Image LockGun1;
    public Image LockGun2;

    public GameObject UpGradebtn_Gun1;
    public GameObject UpGradebtn_Gun2;

    public GameObject Unlockbtn_Gun1;
    public GameObject Unlockbtn_Gun2;

    public GameObject Selectedbtn_Gun;
    public GameObject Selectedbtn_Gun1;
    public GameObject Selectedbtn_Gun2;

    public GameObject Gun;
    public GameObject Gun1;
    public GameObject Gun2;

    public Gun gun;
    public Gun gun1;
    public Gun gun2;

    public GameObject GameManger;
    public GameObject UpGradePage;
	// Use this for initialization
	void Start ()
    {
        RequiredCoins_Gun1 = 100; //changethis
        RequiredCoins_Gun2 = 100; //changethis
        if (gun.CurrentActived == true) { SelectedGun_OnClick(); }
        else if(gun1.CurrentActived== true) { SelectedGun1_OnClick(); }
        else if(gun2.CurrentActived == true) { SelectedGun2_OnClick(); }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public float Get_CurrentGun()
    {
        if (gun.CurrentActived == true) { return gun.Damage; }
        else if (gun1.CurrentActived == true) { return gun1.Damage; }
        else if (gun2.CurrentActived == true) { return gun2.Damage; }
        else { return 0; }
    }
   public void UnlockedGun1_Onclick()
    {
        if(int.Parse(AmountOfCoins.text) >= RequiredCoins_Gun1)
        {
            TakingCoins( RequiredCoins_Gun1);
            Unlock_Gun1();
            gun1.Locked = false;
        }
    }

    public void Unlock_Gun1()
    {
        LockGun1.enabled = false;
        UpGradebtn_Gun1.SetActive(true);
        Unlockbtn_Gun1.SetActive(false);
        Selectedbtn_Gun1.SetActive(true);
    }

    public void UnlockedGun2_Onclick()
    {
        if(int.Parse(AmountOfCoins.text) >= RequiredCoins_Gun2)
        {
            TakingCoins(RequiredCoins_Gun2);
            Unlock_Gun2();
            gun2.Locked = false;
        }
    }

    public void Unlock_Gun2()
    {
        LockGun2.enabled = false;
        UpGradebtn_Gun2.SetActive(true);
        Unlockbtn_Gun2.SetActive(false);
        Selectedbtn_Gun2.SetActive(true);
    }

    public void SelectedGun_OnClick()
    {
        switch (ActiveGun)
        {
            case 1: { Selectedbtn_Gun1.GetComponent<Button>().interactable = true; Gun1.SetActive(false);gun1.CurrentActived = false; break; }
            case 2: { Selectedbtn_Gun2.GetComponent<Button>().interactable = true; Gun2.SetActive(false);gun2.CurrentActived = false; break; }

        }
        ActiveGun = 0;
        Selectedbtn_Gun.GetComponent<Button>().interactable = false;
        gun.CurrentActived = true;
        Gun.SetActive(true);
        
        
    }
    public void SelectedGun1_OnClick()
    {
        switch (ActiveGun)
        {
            case 0: { Selectedbtn_Gun.GetComponent<Button>().interactable = true; Gun.SetActive(false);gun.CurrentActived = false; break; }
            case 2: { Selectedbtn_Gun2.GetComponent<Button>().interactable = true; Gun2.SetActive(false);gun2.CurrentActived = false; break; }

        }
        ActiveGun = 1;
        Selectedbtn_Gun1.GetComponent<Button>().interactable = false;
        gun1.CurrentActived = true;
        Gun1.SetActive(true);
    }
    public void SelectedGun2_OnClick()
    {
        switch (ActiveGun)
        {
            case 0: { Selectedbtn_Gun.GetComponent<Button>().interactable = true; Gun.SetActive(false); gun.CurrentActived = false; break; }
            case 1: { Selectedbtn_Gun1.GetComponent<Button>().interactable = true; Gun1.SetActive(false); gun1.CurrentActived = false; break; }

        }
        ActiveGun = 2;
        Selectedbtn_Gun2.GetComponent<Button>().interactable = false;
        gun2.CurrentActived = true;
        Gun2.SetActive(true);
    }


    public void TakingCoins(int SubAmount)
    {
        var s = int.Parse(AmountOfCoins.text);
        s -= SubAmount;
        AmountOfCoins.text = s.ToString();
    }
    public void BackToMain()
    {
        GameManger.GetComponent<GameManger>().ShowMainMenu();
        this.UpGradePage.SetActive(false);
    }
    
}
