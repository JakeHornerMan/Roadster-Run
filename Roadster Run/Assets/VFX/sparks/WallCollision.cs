using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    [SerializeField] public ParticleSystem sparks;
    public void Start(){
        sparks.Stop();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Road" && this.gameObject.tag == "sparks"){
            sparks.Play();
        }
    }
   void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Road" && this.gameObject.tag == "sparks"){
            sparks.Stop();
        }
    }
}
