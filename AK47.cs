using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AK47 : MonoBehaviour
{
    public float offset;

    public GameObject ammo;
    public Transform shotDir;

    public GameObject ammoPistol;
    public Pistols pistol;

    public Shotgun shotgun;
    public GameObject ammoShotgun;

    private float timeShot;
    public float startTime;

    public int currentAmmo = 30 ;
    public int allAmmo = 0;
    public int fullAmmo = 150;

    [SerializeField]
    public Text ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount.text= currentAmmo +" / " + allAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.facingRight == false){
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, (rotateZ + offset)-180f);
        }else if(player.facingRight == true){
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
        

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
        pistol.ammoCount.text= pistol.currentAmmo +" / " + pistol.allAmmo;
        shotgun.ammoCount.text= shotgun.currentAmmo +" / " + shotgun.allAmmo;
        

        if(Input.GetKeyDown(KeyCode.R) && allAmmo > 0){
            Invoke("Reload",4f);
        }

    }
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<AK47Clip>())
        {
        allAmmo += 30;
        Destroy(other.gameObject);
        }
        else if(other.GetComponent<ShotgunClip>())
        {
        shotgun.allAmmo += 8;
        Destroy(other.gameObject);
        }
        else if(other.GetComponent<PistolClip>())
        {
        pistol.allAmmo +=15;
        Destroy(other.gameObject);
        }
       
    }
    public void Reload(){

        int reason = 30 - currentAmmo;
        if(allAmmo >= reason){
            allAmmo = allAmmo - reason;
            currentAmmo = 30;
        }
        else{
            currentAmmo = currentAmmo + allAmmo;
            allAmmo = 0;
        }
        

       
    }
}
