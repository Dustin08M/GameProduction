using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustin_CarController : MonoBehaviour
{
    private Rigidbody rb;
    public WheelMeshes _wheelMeshes;
    public WheelColliders _wheelCollider;
    public float gasInput;
    public float brakeInput;
    public float SteerInput;
    public float motorPower;
    public float brakePower;
    public float slipAngle;
    private float speed;
    public AnimationCurve steeringCurve;

    [System.Serializable]
    public class WheelMeshes
    {
        public MeshRenderer FLWheel;
        public MeshRenderer FRWheel;
        public MeshRenderer RLWheel;
        public MeshRenderer RRWheel;
    }

    [System.Serializable]
    public class WheelColliders
    {
        public WheelCollider FLWheel;
        public WheelCollider FRWheel;
        public WheelCollider RLWheel;
        public WheelCollider RRWheel;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        checkInput();
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
        GetWheelPosition();
    }

    void ApplyMotor()
    {
        _wheelCollider.RRWheel.motorTorque = motorPower * gasInput;
        _wheelCollider.RLWheel.motorTorque = motorPower * gasInput;
    }

    void ApplySteering()
    {
        float steeringAngle = SteerInput * steeringCurve.Evaluate(speed);
        _wheelCollider.FRWheel.steerAngle = steeringAngle;
        _wheelCollider.FLWheel.steerAngle = steeringAngle;
    }
    
    void checkInput()
    {
        gasInput = Input.GetAxis("Vertical");
        SteerInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward, rb.velocity-transform.forward);

        float movingDirection = Vector3.Dot(transform.forward, rb.velocity);
        if (movingDirection < -0.5f && gasInput > 0)
        {
            brakeInput = Mathf.Abs(gasInput);
        }
        else if (movingDirection > 0.5f && gasInput < 0)
        {
            brakeInput = Mathf.Abs(gasInput);
        }
        else
        {
            brakeInput = 0;
        }
    }

    void ApplyBrake()
    {
        _wheelCollider.FRWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        _wheelCollider.FLWheel.brakeTorque = brakeInput * brakePower * 0.7f;

        _wheelCollider.RRWheel.brakeTorque = brakeInput * brakePower * 0.3f;
        _wheelCollider.RLWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    }

    void GetWheelPosition()
    {
        UpdateWheels(_wheelCollider.FRWheel, _wheelMeshes.FRWheel);
        UpdateWheels(_wheelCollider.FLWheel, _wheelMeshes.FLWheel);
        UpdateWheels(_wheelCollider.RRWheel, _wheelMeshes.RRWheel);
        UpdateWheels(_wheelCollider.RLWheel, _wheelMeshes.RLWheel);
    }

    public void UpdateWheels(WheelCollider col, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        col.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }
}
