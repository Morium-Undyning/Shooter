using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistols : MonoBehaviour
{
    public float offset;

    public GameObject ammo;
    public Transform shotDir;

    private float timeShot;
    public float startTime;

    public int currentAmmo = 15 ;
    public int allAmmo = 0;
    public int fullAmmo = 45;

    [SerializeField]
    private Text ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeShot <= 0)
        {
            if (Input.GetMouseButton(0) && currentAmmo>0)
            {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
                currentAmmo --;
            }
            
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
        ammoCount.text= currentAmmo +" / " + allAmmo;

        if(Input.GetKeyDown(KeyCode.R) && allAmmo > 0){
            Invoke("Reload",2f);
        }

    }
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PistolClip>())
        {
        allAmmo += 15;
        Destroy(other.gameObject);
        }
       
    }
    public void Reload(){

        int reason = 15 - currentAmmo;
        if(allAmmo >= reason){
            allAmmo = allAmmo - reason;
            currentAmmo = 15;
        }
        else{
            currentAmmo = currentAmmo + allAmmo;
            allAmmo = 0;
        }
        

       
    }
}
