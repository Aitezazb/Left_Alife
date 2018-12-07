using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCoin : MonoBehaviour {

    public GameObject BuyCoinsMainPage;
    public GameObject GameManger;

    private int Coin;

    public int coins
    {
        get { return Coin; }
        set { Coin = value; }
    }

    // Use this for initialization
    void Start () {
	}

    public void BuyCoinsbtn_Onclick()
    {
        GameManger.GetComponent<GameManger>().CloseAllPages();
        BuyCoinsMainPage.SetActive(true);

    }
    public void BuyCoin_BackBtn_Onclick()
    {
        BuyCoinsMainPage.SetActive(false);
        GameManger.GetComponent<GameManger>().ShowMainMenu();
    }
}
