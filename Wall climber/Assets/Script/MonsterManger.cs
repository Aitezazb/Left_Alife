using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManger: MonoBehaviour {

    public Transform MonsterPoint_Left;
    public Transform MonsterPoint_Right;

    public GameObject Left_SmallMonster;
    public GameObject Right_SmallMonster;
    public GameObject Left_BigMonster;
    public GameObject Right_BigMonster;

    public Text Currentscore;
    public GameObject Gamemanger;

    private int score;
    private bool Ingame;

    private float BigMonster_ReapeatTime;
    private float SmallMonster_ReapeatTime;
	// Use this for initialization
	void Start ()
    {
        SmallMonster_ReapeatTime = 4f;
        BigMonster_ReapeatTime = 10f;
        Ingame = Gamemanger.GetComponent<GameManger>().InGame;
        score = int.Parse(Currentscore.text);
        
        Start_SmallMonster();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Ingame)
        {
            switch (score)
            {
                case 0: { Start_SmallMonster();break; } //SmallMonsterstart
                case 10: { Start_BigMonster(); break; } //BigMonsterstart
                case 30: { ReapeatFaster_SamllMonster(); break; } //SmallRepeatIncrease
                case 50: { ReapeatFaster_BigMonster(); break; } //BiglRepeatIncrease
                case 70: { ReapeatFaster_SamllMonster(); break; } //SmallRepeatIncrease
                case 60: { ReapeatFaster_BigMonster(); break; } //BigRepeatIncrease
                case 100: { ReapeatFaster_BigMonster(); break; } //BigRepeatIncrease
                default: { break; }
            }
        }
	}
    public void Start_SmallMonster()
    {
        InvokeRepeating("MakeLeft_SmallMonster", 3f, SmallMonster_ReapeatTime);
        InvokeRepeating("MakeRight_SmallMonster", 4f, (SmallMonster_ReapeatTime + 1f));
    }
    public void Start_BigMonster()
    {
        InvokeRepeating("MakeLeft_SmallMonster", 1f, BigMonster_ReapeatTime);
        InvokeRepeating("MakeRight_SmallMonster", 11f, (BigMonster_ReapeatTime + 1f));
    }
    public void MakeLeft_BigMonster()
    {
        Instantiate(Left_BigMonster, MonsterPoint_Left.position, Quaternion.identity);
    }
    public void MakeRight_BigMonster()
    {
        Instantiate(Left_BigMonster, MonsterPoint_Right.position, Quaternion.identity);
    }
     
    public void MakeLeft_SmallMonster()
    {
       Instantiate(Left_SmallMonster, MonsterPoint_Left.position, Quaternion.identity);
    }
    public void MakeRight_SmallMonster()
    {
        Instantiate(Right_SmallMonster, MonsterPoint_Right.position, Quaternion.identity);
    }

    public void ReapeatFaster_SamllMonster()
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
