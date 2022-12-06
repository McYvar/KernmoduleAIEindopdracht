using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/RunAnimation")]
public class BTRunAnimation : BTNode
{
    [SerializeField] string animationName;
    [SerializeField] float fadeTime;

    protected override BTStatus Update()
    {
        agent.ChangeAnimation(animationName, fadeTime);
        return BTStatus.SUCCESS;
    }
}
