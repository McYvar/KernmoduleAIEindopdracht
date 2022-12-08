using UnityEngine;

[CreateAssetMenu(menuName = "BT/Composite/Parallel")]
public class BTParallel : BTComposite
{
    public enum Policy { requireOne, requireAll }

    [SerializeField] protected Policy succesPolicy;
    [SerializeField] protected Policy failurePolicy;

    private int succesCount, failureCount;

    bool[] isActive;

    protected override void OnTerminate()
    {
        base.OnTerminate();
        foreach (BTNode child in children)
        {
            if (child.isInitialized) child.Abort();
        }
    }

    protected override void OnInitialze()
    {
        base.OnInitialze();

        succesCount = 0;
        failureCount = 0;

        isActive = new bool[children.Length];
        for (int i = 0; i < isActive.Length; i++) { isActive[i] = true; }
    }

    protected override BTStatus Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (!isActive[i]) continue;
            BTStatus tempStatus = children[i].Tick();
            if (tempStatus == BTStatus.SUCCESS)
            {
                succesCount++;
                isActive[i] = false;
                if (succesPolicy == Policy.requireOne) return BTStatus.SUCCESS;
            }

            if (tempStatus == BTStatus.FAILURE)
            {
                failureCount++;
                isActive[i] = false;
                if (failurePolicy == Policy.requireOne) return BTStatus.FAILURE;
            }
        }

        if (succesPolicy == Policy.requireAll && succesCount == children.Length) return BTStatus.SUCCESS;
        if (failurePolicy == Policy.requireAll && failureCount == children.Length) return BTStatus.FAILURE;

        return BTStatus.RUNNING;
    }
}
