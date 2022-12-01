using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/Wait", fileName = "Wait")]
public class BTWait : BTNode
{
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
