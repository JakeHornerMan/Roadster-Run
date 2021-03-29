using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float m_horizontalInput;
    public float m_verticalInput;
    public float m_steeringAngle;

    public WheelCollider frontLeftW, frontRightW;
    public WheelCollider backLeftW, backRightW;

    public float maxSteerAngle;
    public float motorForce;
    public float handling;
    public float currentspeed;
    public float maxspeed;
    private float dx;

    private bool steerable;

    private Rigidbody rb;
    private AudioSource ac;

    private bool accellerationAllow;
    private IEnumerator coroutine;
    public float accelTime;
    public GameObject carbody;

    public Vector3 rRight;
    public Vector3 rLeft;
    public Vector3 rNeutral;
    public float t =0.5f;
    private bool fixwallhit= false;



    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioSource>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        ac.pitch = 0.5f;
        steerable = true;
    }
    /*public void Update()
    {
        dx = Input.acceleration.x * handling;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }*/
    public void FixedUpdate()
    {
        GetInput();
        //Steer();
        Accelerate();
        if(steerable == true){
            MoveTilt();
            //Movebuttons();
        }        
    }

    void MoveTilt() {
        float temp = Input.acceleration.x;
        if (0.001 < temp || temp < -0.001) {
            rb.velocity = new Vector3(temp * handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        else if (0.001 > temp || temp > -0.001)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        /*else
        {
            rb.velocity = new Vector3(temp * handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        /*else if (temp > 1)
        {
            rb.velocity = new Vector3(-handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        else if (temp < -1){
            rb.velocity = new Vector3(handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }*/
    }
    void Movebuttons()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            LerpLeft();

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(handling, rb.velocity.y, rb.velocity.z);
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            LerpRight();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            LerpNeutral();
        }
    }
    public void LerpNeutral(){
        carbody.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rNeutral), t);
    }
    public void LerpLeft(){
        carbody.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rLeft), t);
    }
    public void LerpRight(){
        carbody.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rRight), t);
    }

    public void FixBounce(string hitside){
        coroutine = wallhitfix(0.3f);
        if(hitside == "left"){
            steerable = false;
            fixwallhit = true;
            if(fixwallhit == true){
                rb.velocity = new Vector3(-1000f, rb.velocity.y, rb.velocity.z);
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                rb.constraints = RigidbodyConstraints.FreezeRotationY;
            }
            StartCoroutine(coroutine);
        }
        else if(hitside == "right"){
            steerable = false;
            fixwallhit = true;
            if(fixwallhit == true){
                rb.velocity = new Vector3(1000f, rb.velocity.y, rb.velocity.z);
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                rb.constraints = RigidbodyConstraints.FreezeRotationY;
            }
            StartCoroutine(coroutine);
        }
    }
    IEnumerator wallhitfix(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        steerable = true;
        fixwallhit = false;
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        //m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontLeftW.steerAngle = m_steeringAngle;
        frontRightW.steerAngle = m_steeringAngle;
        //backLeftW.steerAngle = -m_steeringAngle/4;
        //backRightW.steerAngle = -m_steeringAngle/4;
    }

    private void Accelerate()
    {

        currentspeed = 2 * 22 / 7 * backLeftW.radius * backLeftW.rpm * 60 / 1000;
        if (currentspeed <= maxspeed)
        {
            backLeftW.motorTorque = 1 * motorForce;
            backRightW.motorTorque = 1 * motorForce;
        }
        else if (currentspeed >= maxspeed)
        {
            backLeftW.motorTorque = 0 * motorForce;
            backRightW.motorTorque = 0 * motorForce;
        }
        //frontLeftW.motorTorque = m_verticalInput * motorForce;
        //frontRightW.motorTorque = m_verticalInput * motorForce;

        ApplyLocalPositionToVisuals(backLeftW);
        ApplyLocalPositionToVisuals(backRightW);
        ApplyLocalPositionToVisuals(frontLeftW);
        ApplyLocalPositionToVisuals(frontRightW);

        if (currentspeed <= 100)
        {
            ac.pitch = 0.5f;
        }
        else if (currentspeed <= 200 && currentspeed >= 100)
        {
            ac.pitch = 0.65f;
        }
        else if (currentspeed >=200)
        {
            ac.pitch = .72f;
        }
        /*else if (currentspeed <= 250)&& currentspeed >= 200)
        {
            ac.pitch = .85f;
        }
        else if (currentspeed >= 250)
        {
            ac.pitch = .9f;
        }*/
            
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        //rotation =rotation * Quaternion.Euler(0f, -90f, 3f);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    
}
