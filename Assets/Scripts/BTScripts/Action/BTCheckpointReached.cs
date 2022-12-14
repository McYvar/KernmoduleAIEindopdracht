using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/CheckpointReached")]
public class BTCheckpointReached : BTNode
{
    [SerializeField] private float maxDistanceToCheckpoint = 1f;

    protected override BTStatus Update()
    {
        bool condition = (Vector3.Distance(agent.transform.position, agent.waypoint) < maxDistanceToCheckpoint);
        if (condition)
        {
            return BTStatus.SUCCESS;
        }
        return BTStatus.FAILURE;
    }
}
