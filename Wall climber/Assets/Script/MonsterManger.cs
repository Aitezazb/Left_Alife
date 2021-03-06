﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManger: MonoBehaviour {

    public Transform MonsterPoint_Left;
    public Transform MonsterPoint_Right;
    public Transform bigMonsterPoint_Left;
    public Transform bigMonsterPoint_Right;

    public GameObject Left_SmallMonster;
    public GameObject Right_SmallMonster;



    public GameObject Left_BigMonster;
    public GameObject Right_BigMonster;

    public Text Currentscore;
    public GameObject Gamemanger;

    

    //private int score;

    public bool inGame { get; internal set; }
    

    private float BigMonster_ReapeatTime;
    private float SmallMonster_ReapeatTime;
	// Use this for initialization
	void Start ()
    {
        inGame = false;
        SmallMonster_ReapeatTime = 9f;
        BigMonster_ReapeatTime = 20f;
        
    }

    internal void GameOver()
    {
        CancelInvoke();
        var clones = GameObject.FindGameObjectsWithTag("Emeny");
         foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

    // Update is called once per frame
    void Update ()
    {
       
	}

    public void ScoreChanged(int s)
    {
        if (inGame == true)
        {
            switch (s)
            {
                //case 0: { Start_SmallMonster(); break; } //SmallMonsterstart
                case 10: { Start_BigMonster(); break; } //BigMonsterstart
                case 30: { ReapeatFaster_SmallMonster(); break; } //SmallRepeatIncrease
                case 50: { ReapeatFaster_BigMonster(); break; } //BiglRepeatIncrease
                case 70: { ReapeatFaster_SmallMonster(); break; } //SmallRepeatIncrease
                case 60: { ReapeatFaster_BigMonster(); break; } //BigRepeatIncrease
                case 100: { ReapeatFaster_BigMonster(); break; } //BigRepeatIncrease
                default: { break; }
            }
        }
    }

    public void GameStarted()
    {
        inGame = true;
        Start_SmallMonster();
    }

    public void Start_SmallMonster()
    {
        InvokeRepeating("MakeLeft_SmallMonster", 5f, SmallMonster_ReapeatTime);
        InvokeRepeating("MakeRight_SmallMonster", 7f, (SmallMonster_ReapeatTime + 1f));
    }
    public void Start_BigMonster()
    {
        //Debug.Log("this is called");
        InvokeRepeating("MakeLeft_BigMonster", 1f, BigMonster_ReapeatTime);
        InvokeRepeating("MakeRight_BigMonster", 11f, (BigMonster_ReapeatTime + 1f));
    }
    public void MakeLeft_BigMonster()
    {
        //Instantiate(Left_BigMonster, MonsterPoint_Left.position, Quaternion.identity);
        Instantiate(Left_BigMonster,new Vector3(bigMonsterPoint_Left.position.x, bigMonsterPoint_Left.position.y,Left_BigMonster.transform.position.z), Quaternion.identity);
    }
    public void MakeRight_BigMonster()
    {
        //Instantiate(Right_BigMonster, MonsterPoint_Right.position, Quaternion.identity);
        Instantiate(Right_BigMonster, new Vector3(bigMonsterPoint_Right.position.x, bigMonsterPoint_Right.position.y, Right_BigMonster.transform.position.z), Quaternion.identity);
    }
     
    public void MakeLeft_SmallMonster()
    {
       Instantiate(Left_SmallMonster, MonsterPoint_Left.position, Quaternion.identity);
    }
    public void MakeRight_SmallMonster()
    {
        Instantiate(Right_SmallMonster, MonsterPoint_Right.position, Quaternion.identity);
    }

    public void ReapeatFaster_SmallMonster()
    {
        if (SmallMonster_ReapeatTime > 1)
        {
            SmallMonster_ReapeatTime -= 1f;
        }
    }
    public void ReapeatFaster_BigMonster()
    {
        if (BigMonster_ReapeatTime > 2)
        {
            BigMonster_ReapeatTime -= 1f;
        }
    }
    
}
