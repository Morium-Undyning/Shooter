using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public float offset;

    public GameObject ammo;
    public Transform shotDir;

    public GameObject ammoPistol;
    public Pistols pistol;

    public GameObject ammoAK47;
    public AK47 ak47;

    private float timeShot;
    public float startTime;

    public int currentAmmo = 8 ;
    public int allAmmo = 0;
    public int fullAmmo = 24;

    [SerializeField]
    public Text ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount.text= currentAmmo + " / " + allAmmo;
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
        ak47.ammoCount.text= ak47.currentAmmo +" / " + ak47.allAmmo;

        if(Input.GetKeyDown(KeyCode.R) && allAmmo > 0){
            StartCoroutine(Reload());
        }

    }
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<ShotgunClip>())
        {
        allAmmo += 8;
        Destroy(other.gameObject);
        }
        else if(other.GetComponent<PistolClip>())
        {
        pistol.allAmmo +=15;
        Destroy(other.gameObject);
        }
        else if(other.GetComponent<AK47Clip>())
        {
        ak47.allAmmo +=30;
        Destroy(other.gameObject);
        }
       
    }
    public IEnumerator Reload(){

        int reason = 8 - currentAmmo;

        
        if(allAmmo >= reason)
        {
            for (int i = 0; i < reason; i++)
            {
               yield return new WaitForSeconds(1);
               currentAmmo +=1;
               allAmmo -=1;
            }
        }else{
            for (int i = 0; i < allAmmo; i++)
            {
               yield return new WaitForSeconds(1);
               currentAmmo +=1;
               allAmmo -=1;
            }
        }

       
    }
}
