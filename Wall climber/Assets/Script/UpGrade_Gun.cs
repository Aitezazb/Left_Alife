using UnityEngine.UI;
using UnityEngine;
using System;

public class UpGrade_Gun : MonoBehaviour {

    public Gun gun;
    public Text CoinAmountInGame;

    public Image UpGradeBar;
    public Text NextUpGradeAmount;
    public bool CurrentActive;
    public float Damagepower;

    public Button Upgradebtn;
	// Use this for initialization
	void Start ()
    {
        UpGradeBar.fillAmount = gun.CurrentUpGradeLevel;
        NextUpGradeAmount.text = gun.NextUpGradeCoinAmount.ToString();
        CurrentActive = gun.CurrentActived;
        Damagepower = gun.Damage;
        if (gun.CurrentUpGradeLevel >= 1)
        {
            Upgradebtn.interactable = false;
        }
    }
    public void Upgrade_Onclick()
    {
        if(int.Parse(CoinAmountInGame.text) >= int.Parse(NextUpGradeAmount.text) && gun.CurrentUpGradeLevel < 1)
        {
            TakeCoins(int.Parse(NextUpGradeAmount.text));
            gun.Damage += 0.1f;
            gun.NextUpGradeCoinAmount += 100;
            gun.CurrentUpGradeLevel += 0.1f;
            Start();
            
        }
    }
    private void TakeCoins(int Amount)
    {
        var s = int.Parse(CoinAmountInGame.text);
        s -= Amount;
        CoinAmountInGame.text = s.ToString();
    }
}
