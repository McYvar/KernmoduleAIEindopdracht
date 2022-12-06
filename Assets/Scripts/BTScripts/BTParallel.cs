using UnityEngine;

[CreateAssetMenu(menuName = "BT/Composite/Parallel")]
public class BTParallel : BTComposite
{
    public enum Policy { requireOne, requireAll }

    [SerializeField] protected Policy succesPolicy;
    [SerializeField] protected Policy failurePolicy;

    protected override void OnTerminate()
    {
        base.OnTerminate();
        foreach (BTNode child in children)
        {
            if (child.isInitialized) child.Abort();
        }
    }

    protected override BTStatus Update()
    {
        int succesCount = 0, failureCount = 0;
        foreach (BTNode child in children)
        {
            BTStatus tempStatus = child.Tick();
            if (tempStatus == BTStatus.SUCCESS)
            {
                succesCount++;
                if (succesPolicy == Policy.requireOne) return BTStatus.SUCCESS;
            }

            if (tempStatus == BTStatus.FAILURE)
            {
                failureCount++;
                if (failurePolicy == Policy.requireOne) return BTStatus.FAILURE;

            }
        }

        if (succesPolicy == Policy.requireAll && succesCount == children.Length) return BTStatus.SUCCESS;
        if (failurePolicy == Policy.requireAll && failureCount == children.Length) return BTStatus.FAILURE;

        return BTStatus.RUNNING;
    }
}
