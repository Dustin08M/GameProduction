using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject MarkerWaypoint;

    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint3;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private GameObject wayPoint5;
    [SerializeField] private GameObject wayPoint6;
    [SerializeField] private GameObject wayPoint7;
    [SerializeField] private GameObject wayPoint8;
    [SerializeField] private GameObject wayPoint9;
    [SerializeField] private GameObject wayPoint10;

    public int wayPointTracker;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPointTracker == 0)
            MarkerWaypoint.transform.position = wayPoint1.transform.position;
        if (wayPointTracker == 1)
            MarkerWaypoint.transform.position = wayPoint2.transform.position;
        if (wayPointTracker == 2)
            MarkerWaypoint.transform.position = wayPoint3.transform.position;
        if (wayPointTracker == 3)
            MarkerWaypoint.transform.position = wayPoint4.transform.position;
        if (wayPointTracker == 4)
            MarkerWaypoint.transform.position = wayPoint5.transform.position;
        if (wayPointTracker == 5)
            MarkerWaypoint.transform.position = wayPoint6.transform.position;
        if (wayPointTracker == 6)
            MarkerWaypoint.transform.position = wayPoint7.transform.position;
        if (wayPointTracker == 7)
            MarkerWaypoint.transform.position = wayPoint8.transform.position;
        if (wayPointTracker == 8)
            MarkerWaypoint.transform.position = wayPoint9.transform.position;
        if (wayPointTracker == 9)
            MarkerWaypoint.transform.position = wayPoint10.transform.position;
        if (wayPointTracker == 10)
        {
            MarkerWaypoint.transform.position = wayPoint10.transform.position; //it set to the same waypoint if its a sprint race
            //if you want circuit, set the waypoint again  back to wayPoint1 (see yt provided in discord thanks).
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AgentCar1"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            wayPointTracker += 1;

            if (wayPointTracker == 10)
            {
                wayPointTracker = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
