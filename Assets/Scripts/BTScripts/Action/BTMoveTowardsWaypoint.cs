using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/MoveTowardsWaypoint")]
public class BTMoveTowardsWaypoint : BTNode
{
    protected override BTStatus Update()
    {
        agent.navAgent.SetDestination(agent.waypoint);
        agent.navAgent.isStopped = false;
        return BTStatus.SUCCESS;
    }
}
