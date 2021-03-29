using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour
{
    public WheelCollider frontLeftW, frontRightW;
    public WheelCollider backLeftW, backRightW;

    public float maxSteerAngle;
    public float motorForce;

    private void Accelerate()
    {

        backLeftW.motorTorque = 1 * motorForce;
        backRightW.motorTorque = 1 * motorForce;
        //frontLeftW.motorTorque = m_verticalInput * motorForce;
        //frontRightW.motorTorque = m_verticalInput * motorForce;

        ApplyLocalPositionToVisuals(backLeftW);
        ApplyLocalPositionToVisuals(backRightW);
        ApplyLocalPositionToVisuals(frontLeftW);
        ApplyLocalPositionToVisuals(frontRightW);

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

        rotation = rotation * Quaternion.Euler(0f, -90f, 3f);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        //GetInput();
        //Steer();
        Accelerate();
        //UpdateWheelPoses();
    }
}
