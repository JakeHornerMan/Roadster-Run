using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDeath : MonoBehaviour
{
    private Transform pos;
    public GameObject player;
    private bool noCollision;

    // find player, set no collision to true
    void Start()
    {
        pos = player.transform; //finding player position
        noCollision = false;
    }

    //follow player object
    void FixedUpdate()
    {
        //follow player position
        transform.position = new Vector3(pos.position.x, pos.position.y -1f, pos.position.z + 5.5f);
    }

    //On collision with another collison component objecct
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Enemy" && noCollision == false){ // is the object tagged as an 'Enemy'
            noCollision = true;
            float damage = player.GetComponent<PlayerHealth>().health; //taking the health value from the player
            player.GetComponent<PlayerHealth>().takeDamage(damage); //remeoving all health from the player and proking the gameover state
            col.gameObject.GetComponent<Health>().DeathReations(); //Collision object playing all the death state functions
        }
    }
}
