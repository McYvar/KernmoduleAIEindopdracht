using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/SetAsTarget")]
public class BTSetAsTarget : BTNode
{
    [SerializeField] private string targetTeamName;
    protected override BTStatus Update()
    {
        TransformListVariable temp = globalBlackboard.GetVariable<TransformListVariable>(targetTeamName);

        if (temp == null) return BTStatus.FAILURE;
        if (temp.Value.Count == 0) return BTStatus.FAILURE;

        Transform target = temp.Value[0];
        if (target == null) return BTStatus.FAILURE;

        // Check for the closest target
        float closestInRange = Vector3.Distance(target.position, agent.transform.position);
        foreach (Transform t in temp.Value)
        {
            float currentTargetRange = Vector3.Distance(t.position, agent.transform.position);
            if (currentTargetRange < closestInRange)
            {
                closestInRange = currentTargetRange;
                target = t;
            }
        }

        agent.SetCurrentTarget(target);
        return BTStatus.SUCCESS;
    }
}
