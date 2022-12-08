using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/IsTargetInFOV")]
public class BTIsTargetInFOV : BTNode
{
    [Header("If the FOV angle is set >=360, then it's basically a function to check if something is in range")]
    [SerializeField] protected string targetTeamName;
    [SerializeField] protected float targetFOVAngle;
    [SerializeField] protected float targetFOVRange;

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

        // Check closest target in FOV
        if (FOV(target))
        {
            agent.SetCurrentTarget(target);
            return BTStatus.SUCCESS;
        }

        return BTStatus.FAILURE;
    }

    protected bool FOV(Transform target)
    {
        // If target is outside of the set FOV angle, return false
        float angle = Vector3.Angle(agent.transform.forward, target.position - agent.transform.position);
        if (angle > Mathf.Abs(targetFOVAngle / 2)) return false;

        // Return true if sight to target is not blocked
        RaycastHit hit;
        Physics.Raycast(agent.transform.position, target.position - agent.transform.position, out hit, targetFOVRange);

        if (hit.collider == null) return false;
        if (hit.collider.transform == target) return true;
        return false;
    }
}