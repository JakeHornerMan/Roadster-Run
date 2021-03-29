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
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            Debug.Log(hitInfo.collider.name);
            Health target = hitInfo.transform.GetComponent<Health>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
        else
        {
            //missed shot
            Debug.DrawLine(ray.origin, ray.direction * range, Color.green);
            Debug.Log("false");
        }
        coroutine = waitandReload(0.3f);
        StartCoroutine(coroutine);
        
    }
    IEnumerator waitandReload(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        reload();
    }


    public void reload() {
        WeaponSounds.PlaySound("reload");
        coroutine = waittoShoot(0.5f);
        StartCoroutine(coroutine);
    }
    IEnumerator waittoShoot(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        shootable = true;
    }
}
