using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneny : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool movingRight;

    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol&& angry == false ){
            chill=true;
        }
        if(Vector2.Distance(transform.position,player.position) < stoppingDistance){
            angry=true;
            chill=false;
            goBack=false;
        }
        else if(Vector2.Distance(transform.position,player.position) > stoppingDistance){
            goBack=true;
            angry =false;
        }

        if(chill == true){
            Chill();
        }
        else if(angry==true){
            Angry();
        }
        else if(goBack==true){
            GoBack();
        }
    }
    void Chill(){
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

    void Angry (){
        transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        speed=2;
    }

    void GoBack(){
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
}
