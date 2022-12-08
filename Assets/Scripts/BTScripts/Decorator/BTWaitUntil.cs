using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/WaitUntil")]
public class BTWaitUntil : BTDecorator
{
    [Header("This node runs until the childnode meets the expected status or until the time has ran out")]
    [SerializeField] private float waitTimeCap;
    [SerializeField] private BTStatus expectedStatus;

    private float currentTime;

    private void OnEnable()
    {
        currentTime = 0;
    }

    protected override BTStatus Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= waitTimeCap)
        {
            currentTime = 0;
            return BTStatus.FAILURE;
        }

        BTStatus result = child.Tick();
        if (result == expectedStatus)
        {
            return BTStatus.SUCCESS;
        }

        return BTStatus.RUNNING;
    }

    protected override void OnTerminate()
    {
        base.OnTerminate();
        currentTime = 0;
    }
}
