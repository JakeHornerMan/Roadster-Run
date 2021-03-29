using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionRight : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform pos;
    private GameObject player;
    private ParticleSystem sparks;
    void Start()
    {
        player = GameObject.Find("Player");
        sparks = GameObject.Find("sparksRight").GetComponent<ParticleSystem>();
        pos = player.transform;
        sparks.Pause();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(pos.position.x + 3.2f, pos.position.y, pos.position.z);
    }
    void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.tag == "Road"){
            Debug.Log ("pushLeft");
            sparks.Play();
            player.GetComponent<CarMovement>().FixBounce("right");
        }
    }
}