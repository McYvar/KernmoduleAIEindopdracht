using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/WaitRandom")]
public class BTWaitRandom : BTNode
{
    [SerializeField] private float waitMin;
    [SerializeField] private float waitMax;
    private float waitTime;
    private float currentTime;

    protected override void OnInitialze()
    {
        base.OnInitialze();
        currentTime = 0;
        waitTime = Random.Range(waitMin, waitMax);
    }

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
