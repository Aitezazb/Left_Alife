using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Animations;
public class PlayerMoves : MonoBehaviour
{
    private Animator anim;
    private byte Facingdir = 1; // 0 for left and 1 for right

    float dirX;
    public float moveSpeed = 5f, jumpforce = 700f;
    Rigidbody2D rb;
    bool facingRight = true;
    Vector3 localScale;

    public GameObject gamemanger;
    

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        anim = gameObject.GetComponent<Animator>();
    }
    public void Addrigidbody()
    {
        
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }
    }

    void FixedUpdate()
    {
        if (dirX < 0)
        {
            Debug.Log("it is neg");
            anim.SetInteger("State", 3);
            Facingdir = 0;
        }
        else if (dirX > 0)
        {
            Debug.Log("it is pos");
            anim.SetInteger("State", 2);
            Facingdir = 1;
        }
        else
        {
            Debug.Log("its netrul");
            switch (Facingdir)
            {
                case 0: { anim.SetInteger("State", 1); break; }
                case 1: { anim.SetInteger("State", 0); break; }
            }
        }
        if (gamemanger.GetComponent<GameManger>().InGame)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
    public void DoJump()
    {
        rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Force);
        switch (Facingdir)
        {
            case 0: { anim.SetInteger("State", 5); break; }
            case 1: { anim.SetInteger("State", 4); break; }
        }
    }

}
