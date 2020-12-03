using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    //public Animator animator;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSprite;
    //public RangedWeapon rangedWeapon;
    //public Transform firepoint;

    public float movementSpeed = 2;
    public float jumpForce = 2.5f;
    //private Vector2 _mousePos;
    private Vector3 defaultPlayerPos;

    private bool _isDead;

    private void Start()
    {
        defaultPlayerPos = transform.position;
    }

    private void Update()
    {

        if (_isDead)
        {
            return;
        }
   
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
     
        // Movement
        //float movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

       //animator.SetBool("Moving", movement != 0);
        
        //playerSprite.flipX = movement < 0; // Flips the sprite depending od direction of movement


        if (Input.GetButtonDown("Jump") && Math.Abs(playerRigidbody.velocity.y) < 0.001)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
        // Death
                if (transform.position.y < -20)
                {
                    Death();
                }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("dead");
        //_isDead = true;
        transform.position = defaultPlayerPos;
    }
}