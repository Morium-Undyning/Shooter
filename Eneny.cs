using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneny : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    public bool movingRight;
    static public bool facingRight = true;

    public Transform player;
    public float stoppingDistance;

    public bool chill = false;
    public bool angry = false;
    public bool goBack = false;

    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Chill(){
        if(transform.position.x > point.position.x + positionOfPatrol){
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol){
            movingRight = true;
        }
        if(movingRight){
            transform.position = new Vector2(transform.position.x +speed*Time.deltaTime, transform.position.y);
        }else{
            transform.position = new Vector2(transform.position.x -speed*Time.deltaTime, transform.position.y);
        }
    }


    public void GoBack(){
    transform.position = Vector2.MoveTowards(transform.position,point.position,speed*Time.deltaTime);
    speed =1;
    }

    public void TakeDamage(int damage){
        health -=damage;
        if(health <=0 ){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
    public void Flip()
    {
        transform.localScale *= new Vector2(-1,1);
        facingRight = !facingRight;
        
    }
}
