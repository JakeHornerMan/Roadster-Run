using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform t;
   
    // This script deleteds objects that are below a certain height. 
    // to not not over populate the scene creating to optimise performance. 
    void FixedUpdate()
    {
        t = gameObject.GetComponent<Transform>();
        if(t.position.y <= -10){
            Destroy(gameObject);
        }
    }
}
