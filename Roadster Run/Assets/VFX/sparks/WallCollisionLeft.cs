using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionLeft : MonoBehaviour
{
    private Transform pos;
    private GameObject player;
    private ParticleSystem sparks;
    void Start()
    {
        player = GameObject.Find("Player");
        sparks = GameObject.Find("sparksLeft").GetComponent<ParticleSystem>();
        pos = player.transform;
        sparks.Pause();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(pos.position.x - 3.2f, pos.position.y, pos.position.z);
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Road"){
            Debug.Log ("pushRight");
            sparks.Play();
            player.GetComponent<CarMovement>().FixBounce("left");
        }
    }
}
