using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {

    //public Canvas MainPageCanvas;
    public GameObject MainPage_UI;
    public GameObject Player;
    public GameObject PlayerPosition_Startmenu;
    public GameObject GameEnviroment;
    public GameObject CurrentScore;
    public GameObject BuyCoinsPage;
    public GameObject UpgradeGuns;
    public GameObject MonsterManager;

    public Text Score;

    public bool InGame;
    // Use this for initialization
    void Start() {
        InGame = false;
        GameEnviroment.SetActive(false);
        CurrentScore.SetActive(false);
    }

    public void ShowMainMenu()
    {
        InGame = false;
        CloseAllPages();
        Player.SetActive(true);
        Player.transform.position = PlayerPosition_Startmenu.transform.position;
        MainPage_UI.SetActive(true);
    }

    // Update is called once per frame
    void Update() {

    }
    public void StartGame_Onclick()
    {
        InGame = true;
        MonsterManager.GetComponent<MonsterManger>().GameStarted();
        StartGame();
        Player.SetActive(true);
    }

    private void StartGame()
    {
        DisableStartPage();
        AddPlayerComponents();
        EnableGameEnviroment();
    }

    public void UpdateScore()
    {
        Score.text = (int.Parse(Score.text) + 1).ToString();
        MonsterManager.GetComponent<MonsterManger>().ScoreChanged();
    }

    void DisableStartPage()
    {
        MainPage_UI.SetActive(false);
    }
    void AddPlayerComponents()
    {
        Player.AddComponent<Rigidbody2D>();
        var rd = Player.GetComponent<Rigidbody2D>();
        rd.freezeRotation = true;
        Player.GetComponent<PlayerMovment>().RigidBody_Add();
    }
    void EnableGameEnviroment()
    {
        CurrentScore.SetActive(true);
        GameEnviroment.SetActive(true);
    }

    public void CloseAllPages()
    {
        GameEnviroment.SetActive(false);
        CurrentScore.SetActive(false);
        MainPage_UI.SetActive(false);
        Player.SetActive(false);
        BuyCoinsPage.SetActive(false);
        UpgradeGuns.SetActive(false);
    }
}
