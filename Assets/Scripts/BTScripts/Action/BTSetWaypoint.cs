using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/SetCheckpoint")]
public class BTSetWaypoint : BTNode
{
    [SerializeField] private Vector3[] waypoints;

    [Header("If 'Search In Range' is true, only first two waypoints are taken into account")]
    [Space(20), SerializeField] private bool searchInRange;

    [Space(10), SerializeField] private bool setWaypointToSelf;

    protected override BTStatus Update()
    {
        agent.waypoint = SeekNewWaypoint();
        return BTStatus.SUCCESS;
    }

    private Vector3 SeekNewWaypoint()
    {
        if (setWaypointToSelf) return agent.transform.position;

        Vector3 waypoint = agent.transform.position;
        if (searchInRange && waypoints.Length > 2)
        {
            float randX, randZ;
            if (waypoints[0].x < waypoints[1].x)
                randX = Random.Range(waypoints[0].x, waypoints[1].x);
            else
                randX = Random.Range(waypoints[1].x, waypoints[0].x);
            if (waypoints[0].z < waypoints[1].z)
                randZ = Random.Range(waypoints[0].z, waypoints[1].z);
            else
                randZ = Random.Range(waypoints[1].z, waypoints[0].z);

            waypoint = new Vector3(randX, agent.transform.position.y, randZ);
        }
        else
        {
            int rand = Random.Range(0, waypoints.Length);
            if (waypoints[rand] == agent.waypoint) SeekNewWaypoint();
            waypoint = waypoints[rand];
        }
        return waypoint;
    }
}
