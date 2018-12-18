using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovment : MonoBehaviour {
    

    public Transform LeftGunPoint;
    public Transform RightGunPoint;

    public GameObject BulletGameObject;
    public GameObject fireSmoke;

    private Rigidbody2D rd;
    private Animator anim;
    public int Movespeed;
    public int JumpSpeed;

    public bool InGame;
    public bool clicked_Left;
    public bool clicked_Right;

    [Range(0,1)]
    public int Driection; //0 for left; and 1 for right
    private bool OnGround;
	void Start () {
        JumpSpeed = 360;
        InGame = false;
        OnGround = true;
        Driection = 1;
        clicked_Left = false;
        clicked_Right = false;
        anim =gameObject.GetComponent<Animator>();
	}
   
	void Update ()
    {
        if (InGame)
        {
            if (clicked_Left && rd != null)
            {
                rd.velocity = new Vector2(-Movespeed * Time.deltaTime, rd.velocity.y);
            }
            if (clicked_Right && rd != null)
            {
                rd.velocity = new Vector2(Movespeed * Time.deltaTime, rd.velocity.y);
            }
            //For mobile input

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft_OnClickDown();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                MoveLeft_OnclickUP();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight_OnClickDown();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                MoveRight_OnClickUp();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jumb_OnClickDown();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Jumb_onClickUp();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Shoot_OnClick();
            }
        }
    }

    public void Reset()
    {
        InGame = false;
        OnGround = true;
        Driection = 1;
        clicked_Left = false;
        clicked_Right = false;
    }

    public void RigidBody_Add()
    {
        InGame = true;
        rd = this.gameObject.GetComponent<Rigidbody2D>();
    }

   public void MoveLeft_OnClickDown()
    {
        //this.transform.Translate(-Movespeed * Time.deltaTime, 0, 0);
        //rd.velocity = new Vector2(-Movespeed * Time.deltaTime, rd.velocity.y);
        Driection = 0;
        anim.SetInteger("State", 3);
        clicked_Left = true;
    }
    public void MoveLeft_OnclickUP()
    {
        anim.SetInteger("State", 1);
        clicked_Left = false;
        Driection = 0;
    }
    public void MoveRight_OnClickDown()
    {
        //this.transform.Translate(Movespeed * Time.deltaTime, 0, 0);
       // rd.velocity = new Vector2(Movespeed * Time.deltaTime, rd.velocity.y);
        Driection = 1;
        clicked_Right = true;
        anim.SetInteger("State", 2);
    }
    public void MoveRight_OnClickUp()
    {
        clicked_Right = false;
        anim.SetInteger("State", 0);
        Driection = 1;
    }
    public void Jumb_OnClickDown()
    {
        if (OnGround)
        {
            rd = gameObject.GetComponent<Rigidbody2D>();
            rd.AddForce(new Vector2(0, JumpSpeed), ForceMode2D.Force);
            OnGround = false;
            if(Driection==0)
            { anim.SetInteger("State", 5);
            }
            else if(Driection==1)
            { anim.SetInteger("State", 4);
            }
        }
    }

    

    public void Jumb_onClickUp()
    {
        if (Driection == 0)
        {
            anim.SetInteger("State", 1);
        }
        else if (Driection == 1)
        {
            anim.SetInteger("State", 0);
        }
    }
    public void Shoot_OnClick()
    {
        var bulletCount = GameObject.FindGameObjectsWithTag("Bullet");
        
        if(bulletCount.Length <= 5)
        {
            switch (Driection)
            {
                case 0:
                    {
                        var s = Instantiate(BulletGameObject, LeftGunPoint.position, Quaternion.identity);
                        s.GetComponent<Bulletfire>().Dir = 0;
                        Instantiate(fireSmoke, LeftGunPoint.position, Quaternion.identity);
                        break;
                    }
                case 1:
                    {
                        var s = Instantiate(BulletGameObject, RightGunPoint.position, Quaternion.identity);
                        s.GetComponent<Bulletfire>().Dir = 1;
                        Instantiate(fireSmoke, new Vector3(RightGunPoint.position.x, RightGunPoint.position.y,-0.5f), Quaternion.identity);
                        break;
                    }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        { OnGround = true; }

    }
}
