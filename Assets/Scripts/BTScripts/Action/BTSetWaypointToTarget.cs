using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/SetWaypointToTarget")]
public class BTSetWaypointToTarget : BTNode
{
    protected override BTStatus Update()
    {
        if (agent.target == null) return BTStatus.FAILURE;
        agent.waypoint = agent.target.position;
        return BTStatus.SUCCESS;
    }
}
