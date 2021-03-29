using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDeath : MonoBehaviour
{
    private Transform pos;
    public GameObject player;
    private bool noCollision;

    // Start is called before the first frame update
    void Start()
    {
        pos = player.transform;
        noCollision = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position = new Vector3(pos.position.x, pos.position.y -1f, pos.position.z + 5.5f);
    }
    void OnCollisionEnter(Collision col){
        //Collider deathCollision = col.gameObject.GetComponent<Collider>();
        if(col.gameObject.tag == "Enemy" && noCollision == true){//col.gameObject.GetComponent<Collider>().isTrigger == false){
            noCollision = true;
            float damage = player.GetComponent<PlayerHealth>().health;
            player.GetComponent<PlayerHealth>().takeDamage(damage);
            col.gameObject.GetComponent<Health>().DeathReations();
        }
    }
}
