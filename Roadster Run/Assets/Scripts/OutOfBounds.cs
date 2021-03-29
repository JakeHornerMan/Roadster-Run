using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform t;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        t = gameObject.GetComponent<Transform>();
        if(t.position.y <= -10){
            Destroy(gameObject);
        }
    }
}
