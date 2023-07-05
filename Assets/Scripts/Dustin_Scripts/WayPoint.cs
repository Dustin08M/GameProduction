using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject MarkerWaypoint;
    [SerializeField] private GameObject[] waypoints;
    public int wayPointTracker;

    private void Start()
    {
        wayPointTracker = 0;
    }

    private void Update()
    {
        MarkerWaypoint.transform.position = waypoints[wayPointTracker].transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AgentCar1"))
        {
            wayPointTracker++;
            if (wayPointTracker >= waypoints.Length)
                wayPointTracker = 0;
        }
    }

    public Vector3 GetNextWaypointPosition()
    {
        if (wayPointTracker < waypoints.Length)
            return waypoints[wayPointTracker].transform.position;
        else
            return waypoints[0].transform.position;
    }
}
