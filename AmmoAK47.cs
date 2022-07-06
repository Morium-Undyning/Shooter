using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAK47 : MonoBehaviour
{
    public float speed;
    public float destroyTime;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
