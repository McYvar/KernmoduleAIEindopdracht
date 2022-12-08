using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/SetAgentMovementSpeed")]
public class BTSetAgentMovementSpeed : BTNode
{
    [SerializeField] private float newSpeed;

    protected override BTStatus Update()
    {
        agent.navAgent.speed = newSpeed;
        return BTStatus.SUCCESS;
    }
}
