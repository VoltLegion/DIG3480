﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private Animator AnimatePlayer;
    public AudioSource Jump;

   
    

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        AnimatePlayer = GetComponent<Animator>();
	}

    void Awake()
    {

       Jump = GetComponent<AudioSource>();

    }

    private void Update(){
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    
    // Update is called once per frame
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        if(moveHorizontal !=0 && isOnGround)
        {
            AnimatePlayer.SetBool("Walk", true);
            AnimatePlayer.SetBool("Idle", false);
            AnimatePlayer.SetBool("Jump", false);
        } 
        else if (moveHorizontal == 0 && isOnGround)
        {
            AnimatePlayer.SetBool("Walk", false);
            AnimatePlayer.SetBool("Idle", true);
            AnimatePlayer.SetBool("Jump", false);
        }
        else
        {
            AnimatePlayer.SetBool("Walk", false);
            AnimatePlayer.SetBool("Idle", false);
            AnimatePlayer.SetBool("Jump", true);
        }

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

       // Debug.Log(isOnGround);



        //stuff I added to flip my character
        if(facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
               rb2d.velocity = Vector2.up * jumpforce;


                Jump.Play();
              
                
                
            }
        }
      if(collision.collider.tag =="Goomba" && isOnGround)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
            other.gameObject.SetActive(false);
    }
}
