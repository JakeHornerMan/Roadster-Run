using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsLogic : MonoBehaviour
{
    private Transform pos;
    public GameObject player;
    public string guntype;
    private Sniper sniper;
    //private MachineGun machinegun;
    //private Rocket rocket;
    
    void Start()
    {
        guntype = "sniper";
        pos = player.transform;
        sniper = GetComponent<Sniper>();
        
        // future plans for more waeponry
        //rocket = GetComponent<Rocket>();
        //machinegun = GetComponent<MachineGun>();
        
    }

    //this FixedUpdate allows testgun to follow the Player Car 
    void FixedUpdate()
    {
        transform.position = new Vector3(pos.position.x, pos.position.y + 0.5f, pos.position.z + 5);
    }

    //depending on the guntype the Shoot touch will select the right gun
    public void ShootTouch(){
        if(guntype == "sniper"){
            sniper.canShoot();
        }
    }
}
