using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Gate : MonoBehaviour
{
    static public int k = 1;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (k==1) {
               
                SceneManager.LoadScene("Scene2");
                
            }
            else if (k == 2)
            {
                
                SceneManager.LoadScene("Scene3");
                
            }
            else if (k == 3)
            {
                SceneManager.LoadScene("Boss");
                
            }
            k++;
        }
    }
}
