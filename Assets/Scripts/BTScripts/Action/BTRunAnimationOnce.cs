using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BT/Action/RunAnimationOnce")]
public class BTRunAnimationOnce : BTNode
{
    [SerializeField] private string animationName;
    protected override BTStatus Update()
    {
        agent.PlayAnimationOnece(animationName);
        return BTStatus.SUCCESS;
    }
}
