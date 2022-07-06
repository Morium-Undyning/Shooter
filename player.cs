using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public int heal;
    public int numberOfLives;
    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLive;

    public float speed;
    private float moveInput;
    private bool isGrouned;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    private Animator anim;
    private Rigidbody2D rb;
    private bool facingRight = true;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        int i2;
    }

    // Update is called once per frame
    void Update()
    {
        if(heal > numberOfLives){
            heal = numberOfLives;
        }


        for(int i=0; i < lives.Length;i++){
            if(i< heal){
                lives[i].sprite = fullLive;
            }else{
                lives[i].sprite = emptyLive;
            }


            if(i < numberOfLives){
                lives[i].enabled =true; 
            }else{
                lives[i].enabled =false;
            }
        }

        isGrouned = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrouned == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}
