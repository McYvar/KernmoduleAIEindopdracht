using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/IsTargetInFOV")]
public class BTIsTargetInFOV : BTNode
{
    [SerializeField] private string targetTeamName;
    [SerializeField] private float targetFOVAngle;
    [SerializeField] private float targetFOVRange;

    [SerializeField] private bool CheckAngle = true;

    [SerializeField] private LayerMask layer;

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

    private bool FOV(Transform target)
    {
        Debug.DrawLine(agent.transform.position, target.position);
        // If target is outside of the set FOV angle, return false
        if (CheckAngle)
        {
            float angle = Vector3.Angle(agent.transform.forward, target.position - agent.transform.position);
            if (angle > Mathf.Abs(targetFOVAngle / 2)) return false;
        }

        // Return true if sight to target is not blocked
        RaycastHit hit;
        //bool check = Physics.Raycast(agent.transform.position, target.position - agent.transform.position, out hit, targetFOVRange, layer);
        bool check = Physics.SphereCast(agent.transform.position, 0.3f, target.position - agent.transform.position, out hit, targetFOVRange, layer);
        if (hit.collider == null) return false;
        if (hit.collider.transform == target) return true;
        return false;
    }
}