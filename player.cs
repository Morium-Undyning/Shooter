using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int heal;
    private float speed;

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
        
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (facingRight == false)
        {
            Flip();
        }
        else if (facingRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
