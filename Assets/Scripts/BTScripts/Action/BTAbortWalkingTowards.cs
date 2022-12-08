using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/AbortWalkingTowards")]
public class BTAbortWalkingTowards : BTNode
{
    protected override BTStatus Update()
    {
        agent.navAgent.isStopped = true;
        return BTStatus.SUCCESS;
    }
}
