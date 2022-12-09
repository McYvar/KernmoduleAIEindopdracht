using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/RunAnimation")]
public class BTRunAnimation : BTNode
{
    [SerializeField] private string animationName;
    [SerializeField] private float fadeTime;

    protected override BTStatus Update()
    {
        agent.ChangeAnimation(animationName, fadeTime);
        return BTStatus.SUCCESS;
    }
}
