using UnityEngine.UI;
using UnityEngine;

public class UpGrade_Gun2 : MonoBehaviour
{

    public Gun gun2;
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
        UpGradeBar.fillAmount = gun2.CurrentUpGradeLevel;
        NextUpGradeAmount.text = gun2.NextUpGradeCoinAmount.ToString();
        CurrentActive = gun2.CurrentActived;
        Damagepower = gun2.Damage;
        Debug.Log("Gun 2 " + gun2.Locked);
        if (gun2.Locked == false)
        {
            Debug.Log("in it");
            UpgradeManger.GetComponent<UpgradeGunManger>().Unlock_Gun2();
        }
        if (gun2.CurrentUpGradeLevel >= 1)
        {
            Upgradebtn.interactable = false;
        }
    }
    public void Upgrade_Onclick()
    {
        if (int.Parse(CoinAmountInGame.text) >= int.Parse(NextUpGradeAmount.text) && gun2.CurrentUpGradeLevel < 1)
        {
            TakeCoins(int.Parse(NextUpGradeAmount.text));
            gun2.Damage += 0.3f;
            gun2.NextUpGradeCoinAmount += 200;
            gun2.CurrentUpGradeLevel += 0.1f;
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
