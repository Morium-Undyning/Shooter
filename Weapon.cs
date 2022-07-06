using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int WeaponSwithc = 0;

    static public int WeaponOpened = 2;

    static public bool akPickeUd = false;
    static public bool shotgunPickeUd = true;
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int cuuurentWeapon = WeaponSwithc;
       if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(WeaponSwithc >= transform.childCount - WeaponOpened)
            {
                WeaponSwithc = 0;
            }
            else
            {
                WeaponSwithc++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (WeaponSwithc <= 0)
            {
                WeaponSwithc =transform.childCount-WeaponOpened;
            }
            else
            {
                WeaponSwithc--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponSwithc = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && shotgunPickeUd == true)
        {
            WeaponSwithc = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && akPickeUd == true)
        {
            WeaponSwithc = 2;
        }
        if (cuuurentWeapon!=WeaponSwithc)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == WeaponSwithc)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="AK"){
            WeaponOpened --;
            akPickeUd = true;
            Destroy(other.gameObject);
        }
    }
}
