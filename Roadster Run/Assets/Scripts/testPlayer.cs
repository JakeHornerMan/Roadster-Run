using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    public float forewardSpeed = 0.5f;
    public float turnSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * turnSpeed/2;
        float vMovement = Input.GetAxis("Vertical") * forewardSpeed;

        transform.Translate(new Vector3(hMovement, 0, vMovement));
    }
}
