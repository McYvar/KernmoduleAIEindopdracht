using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/RemainStatusUntil")]
public class BTRemainStatusUntil : BTDecorator
{
    [Header("If the childnode of this node meets the required status, then this node keeps returning that status for some time")]
    [SerializeField] private float waitTime;
    [SerializeField] private BTStatus conditionStatus;

    private float currentTime;

    private void OnEnable()
    {
        currentTime = waitTime;
    }

    protected override BTStatus Update()
    {
        if (currentTime < waitTime)
        {
            currentTime += Time.deltaTime;
            return conditionStatus;
        }

        BTStatus result = child.Tick();

        if (result == conditionStatus)
        {
            currentTime = 0;
            return conditionStatus;
        }

        return result;
    }
}
