﻿using System;
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
    public GameObject killAll;
    public GameObject FreeCoin;
    public Text currentCoin;
   

    public CameraShake cameraShake;

    public GameObject TiggerDialogue;

    public GameObject MonsterManager;

    public void DecreaseScore()
    {
        var s = int.Parse(Score.text);
        if(s > 0)
        {
            s -= 1;
        }
        Score.text = s.ToString();
    }

    public Text HighScore;
    public Text Score;

    public bool InGame;
    // Use this for initialization
    void Start() {
        InGame = false;
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameEnviroment.SetActive(false);
        CurrentScore.SetActive(false);
    }
    public void GameOver()
    {
        StartCoroutine(cameraShake.Shake(.35f,.10f));
        MonsterManager.GetComponent<MonsterManger>().GameOver();
        Start();
        ShowMainMenu();
        BuyCoinsPage.SetActive(true);
        ResetScore();
        FreeCoin.GetComponent<FreeCoin>().CancelInvoke();
    }
    public void ShowMainMenu()
    {
        InGame = false;
        CloseAllPages();
        Player.SetActive(true);
        Destroy(Player.GetComponent<Rigidbody2D>());
        ResetPlayer();
        Player.transform.position = PlayerPosition_Startmenu.transform.position;
        MainPage_UI.SetActive(true);
    }

    private void ResetPlayer()
    {
        Player.GetComponent<PlayerMovment>().Reset();

    }

    // Update is called once per frame
    void Update() {

    }
    private void ResetScore()
    {
        var score = int.Parse(Score.text);

        if(score > int.Parse(HighScore.text))
        {
            HighScore.text = score.ToString();
            PlayerPrefs.SetInt("HighScore",score);
        }
        Score.text = "0";
    }
    public void StartGame_Onclick()
    {
        TiggerDialogue.GetComponent<DialogTrigger>().TriggerDialog();
        CloseAllPages();
        Player.SetActive(true);
    }

    public void StartGame()
    {
        InGame = true;
        MonsterManager.GetComponent<MonsterManger>().GameStarted();
        //StartGame();
        DisableStartPage();
        AddPlayerComponents();
        EnableGameEnviroment();
        Player.SetActive(true);
        BuyCoinsPage.SetActive(true);
        FreeCoin.GetComponent<FreeCoin>().StartInvoking();
    }

    public void UpdateScore()
    {
        Score.text = (int.Parse(Score.text) + 1).ToString();
        MonsterManager.GetComponent<MonsterManger>().ScoreChanged(int.Parse(Score.text));
        killAll.GetComponent<KillAll>().IncreaseAmount();
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
    public void IncreaseCoin()
    {
        currentCoin.text = (int.Parse(currentCoin.text) + 1).ToString();
    }
}
