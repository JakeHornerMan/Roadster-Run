using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public float damage = 50f;
    private float range = 100f;
    private GameObject shootingpoint;
    private Ray ray;
    private IEnumerator coroutine;
    //private WeaponsLogic weapon;
     public bool shootable;
    

    private void Awake()
    {
        shootable = true;
        //shooting object
        shootingpoint = GameObject.Find("testgun");

    }

    //Debugging rays to view them in the editor
    private void FixedUpdate()
    {
        //setting ray position as it changes
        ray = new Ray(shootingpoint.transform.position, -shootingpoint.transform.forward);
        //testing for range
        Debug.DrawRay(shootingpoint.transform.position, -shootingpoint.transform.forward * range, Color.green);
        //Shootlogic
    }

    public void canShoot(){
        if (shootable == true){
            Shoot();
        }
        else{

        }
    }

    public void Shoot()
    {
        shootable = false;
        WeaponSounds.PlaySound("snipershot");
        RaycastHit hitInfo; //info of raycast
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            Debug.Log(hitInfo.collider.name); // console log infor for development
            Health target = hitInfo.transform.GetComponent<Health>(); // finding health script on the hit target
            if (target != null) //if there was a health script attached to the object
            {
                target.takeDamage(damage); //run take damage on ray cast hit object
            }
        }
        else
        {
            //couldnt find objects with weaponry
            Debug.DrawLine(ray.origin, ray.direction * range, Color.green);
            Debug.Log("false");
        }
        coroutine = waitandReload(0.5f);
        StartCoroutine(coroutine);
    }
    IEnumerator waitandReload(float _waitTime) {
        //timer before reload noise
        yield return new WaitForSeconds(_waitTime);
        reload();
    }

    public void reload() {
        //reload noise
        WeaponSounds.PlaySound("reload");
        coroutine = waittoShoot(0.5f);
        StartCoroutine(coroutine);
    }

    IEnumerator waittoShoot(float _waitTime) {
        //wait befor allowing player to shoot again, when shootable = true
        yield return new WaitForSeconds(_waitTime);
        shootable = true;
    }
}
