using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
#region (health attribute)
    public int heal;
    public int numberOfLives;
    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLive;
#endregion

    public float speed;
    private float moveInput;
    private bool isGrouned;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    private Animator anim;
    private Rigidbody2D rb;
    static public bool facingRight = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        int i2;
    }

    // Update is called once per frame
    void Update()
    {
        #region (health system)
        if(heal > numberOfLives){
            heal = numberOfLives;
        }
        else if (heal <=0){
            SceneManager.LoadScene(Gate.k);
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
        #endregion

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
        Flip();
    }
    void Flip()
    {
        if (facingRight == false && moveInput > 0)
        {
           transform.localScale *= new Vector2(-1,1);
           facingRight = !facingRight;
        }
        else if (facingRight == true && moveInput < 0)
        {
            transform.localScale *= new Vector2(-1,1);
            facingRight = !facingRight;
        }
        
    }
    public  void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "health"){
            heal++;
            Destroy(other.gameObject);
        }
    }
}
