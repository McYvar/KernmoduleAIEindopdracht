using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/BTWait")]
public class BTWait : BTNode
{
    public BTWait(int _waitTime)
    {
        waitTime = _waitTime;
    }

    [SerializeField] private float waitTime;
    private float currentTime;

    protected override BTStatus Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= waitTime)
        {
            currentTime = 0;
            return BTStatus.SUCCESS;
        }
        return BTStatus.RUNNING;
    }
}
