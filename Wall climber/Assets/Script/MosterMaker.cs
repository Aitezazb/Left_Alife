using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterMaker : MonoBehaviour {

    public Transform MonsterPoint_Left;
    public Transform MonsterPoint_Right;
    public GameObject LeftMonster;
    public GameObject RightMonster;
	// Use this for initialization
	void Start ()
    {
        //MonsterPoint_Left = GameObject.Find("monsterpoint_Left").transform;
        //MonsterPoint_Right = GameObject.Find("monsterpoint_Right").transform;
        Make_Moster();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Make_Moster()
    {
        Instantiate(LeftMonster, MonsterPoint_Right.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Gameover
        }
    }
}
