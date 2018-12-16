using UnityEngine.UI;
using UnityEngine;

public class UpGrade_Gun1 : MonoBehaviour
{

    public Gun gun1;
    public Text CoinAmountInGame;
    public GameObject UpgradeManger;

    public Image UpGradeBar;
    public Text NextUpGradeAmount;
    public bool CurrentActive;
    public float Damagepower;

    public Button Upgradebtn;
    // Use this for initialization
    void Start()
    {
        UpGradeBar.fillAmount = gun1.CurrentUpGradeLevel;
        NextUpGradeAmount.text = gun1.NextUpGradeCoinAmount.ToString();
        CurrentActive = gun1.CurrentActived;
        Damagepower = gun1.Damage;
        if(gun1.Locked == false)
        {

            UpgradeManger.GetComponent<UpgradeGunManger>().Unlock_Gun1();
        }
        if(gun1.CurrentUpGradeLevel >= 1)
        {
            Upgradebtn.interactable = false;
        }
    }
    public void Upgrade_Onclick()
    {
        if (int.Parse(CoinAmountInGame.text) >= int.Parse(NextUpGradeAmount.text) && gun1.CurrentUpGradeLevel < 1)
        {
            TakeCoins(int.Parse(NextUpGradeAmount.text));
            gun1.Damage += 0.2f;
            gun1.NextUpGradeCoinAmount += 150;
            gun1.CurrentUpGradeLevel += 0.1f;
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
