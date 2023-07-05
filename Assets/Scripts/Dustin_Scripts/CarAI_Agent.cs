using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI_Agent : MonoBehaviour //don't use this as im still fixing on the pathfinding AI - Wind
{
    public Transform Tracker;
    NavMeshAgent carAgent;
    WayPoint _waypoint;

    private void Start()
    {
        carAgent = GetComponent<NavMeshAgent>();
        _waypoint = GetComponent<WayPoint>();
    }
    private void Update()
    {
        carAgent.SetDestination(Tracker.position);

        if (_waypoint.wayPointTracker == 10)
        {
            if (carAgent.remainingDistance <= carAgent.stoppingDistance && !carAgent.pathPending)
            {
                carAgent.isStopped = true;
            }
        }
    }
}
