using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/CheckpointReached")]
public class BTCheckpointReached : BTNode
{
    [SerializeField] float maxDistanceToCheckpoint = 1f;

    protected override BTStatus Update()
    {
        if (Vector3.Distance(agent.transform.position, agent.waypoint) < maxDistanceToCheckpoint)
        {
            return BTStatus.SUCCESS;
        }
        return BTStatus.FAILURE;
    }
}
