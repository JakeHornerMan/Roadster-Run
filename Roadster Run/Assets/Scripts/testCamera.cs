using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCamera : MonoBehaviour
{
    private Transform pos;
    public GameObject player;
    public float yOffset = 2.5f;
    public float zOffset =5f;
    // Start is called before the first frame update
    void Start()
    {
        pos = player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, pos.position.y+yOffset, pos.position.z-zOffset);
    }
}
