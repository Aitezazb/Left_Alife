using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    //public Canvas MainPageCanvas;
    public GameObject MainPage_UI;
    public GameObject Player;
    public GameObject PlayerPosition_Startmenu;
    public GameObject GameEnviroment;
    public GameObject CurrentScore;
    public GameObject BuyCoinsPage;
    public GameObject UpgradeGuns;

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
        StartGame();
        Player.SetActive(true);
    }

    private void StartGame()
    {
        DisableStartPage();
        AddPlayerComponents();
        EnableGameEnviroment();
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
