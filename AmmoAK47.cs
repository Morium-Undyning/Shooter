using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAK47 : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public SpriteRenderer sr;

    public int damage;
    bool a = true;
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        Invoke("DestroyAmmo", destroyTime);
        if(player.facingRight == false){
            b=false;
        }else{
            a=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
         if(b==false){
            
           transform.Translate(Vector2.left * speed * Time.deltaTime);
           sr.flipX = true;
        }
         if(a==false){
 
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        }
    }
    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Eneny enemy = collision.GetComponent<Eneny>();

        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
