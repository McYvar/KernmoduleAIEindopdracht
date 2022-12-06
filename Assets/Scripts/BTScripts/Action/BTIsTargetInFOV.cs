using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/IsTargetInFOV")]
public class BTIsTargetInFOV : BTNode
{
    [SerializeField] protected string targetTeamName;
    [SerializeField] protected float targetFOVAngle;
    [SerializeField] protected float targetFOVScale;

    protected override BTStatus Update()
    {
        TransformListVariable temp = globalBlackboard.GetVariable<TransformListVariable>(targetTeamName);
        foreach (Transform t in temp.Value)
        {
            if (FOV(t))
            {
                agent.SetCurrentEnemy(t);
                agent.transform.LookAt(t);
                return BTStatus.SUCCESS;
            }
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
        Physics.Raycast(agent.transform.position, target.position - agent.transform.position, out hit, targetFOVScale);

        if (hit.collider == null) return false;
        if (hit.collider.transform == target) return true;
        return false;
    }
}