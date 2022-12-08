using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/LookAtTarget")]
public class BTLookAtTarget : BTNode
{
    protected override BTStatus Update()
    {
        if (agent.target == null) return BTStatus.FAILURE;
        Vector3 target = new Vector3(agent.target.position.x, agent.transform.position.y, agent.target.position.z);
        agent.transform.rotation = Quaternion.LookRotation(target - agent.transform.position);
        return BTStatus.SUCCESS;
    }
}
