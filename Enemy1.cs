using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Eneny
{
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
            if (facingRight == false && movingRight == false)
        {
           Flip();
        }
        else if (facingRight == true && movingRight == true)
        {
           Flip();
        }
        }
        if(Vector2.Distance(transform.position,player.position) < stoppingDistance){
            angry=true;
            chill=false;
            goBack=false;
            if(player.position.x-transform.position.x<=0&&facingRight==false){
                Flip();
            }else if(player.position.x-transform.position.x>0&&facingRight==true){
                Flip();
            }
        }
        else if(Vector2.Distance(transform.position,player.position) > stoppingDistance){
            goBack=true;
            angry =false;
            if (facingRight == false && movingRight == false)
        {
           Flip();
        }
        else if (facingRight == true && movingRight == true)
        {
           Flip();
        }
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
}
