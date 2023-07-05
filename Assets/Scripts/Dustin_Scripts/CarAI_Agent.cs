using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI_Agent : MonoBehaviour //don't use this as im still fixing on the pathfinding AI - Wind
{
    public WayPoint waypointManager;
    private Dustin_CarController carController;

    private void Start()
    {
        carController = GetComponent<Dustin_CarController>();
    }

    private void FixedUpdate()
    {
        // Get the next waypoint position from the WayPoint script
        Vector3 nextWaypoint = waypointManager.GetNextWaypointPosition();

        // Calculate steering input based on the angle between car's forward direction and the next waypoint
        Vector3 relativeVector = transform.InverseTransformPoint(nextWaypoint);
        float steerInput = relativeVector.x / relativeVector.magnitude;

        // Apply steering input to the car controller
        carController.SteerInput = steerInput;

        // Set gas input to accelerate towards the waypoint
        carController.gasInput = 1f;

        // Apply the modified car controller inputs
        carController.ApplyMotor();
        carController.ApplySteering();
        carController.ApplyBrake();
        carController.GetWheelPosition();
    }
}
