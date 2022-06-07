using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Gate : MonoBehaviour
{
    int k;
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
                k++;
                SceneManager.LoadScene("Scene2");
            }
            if (k == 2)
            {
                k++;
                SceneManager.LoadScene("Scene3");
            }
            if (k == 3)
            {
                k++;
                SceneManager.LoadScene("Boss");
            }
        }
    }
}
