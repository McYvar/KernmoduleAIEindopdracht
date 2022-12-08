using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/CheckForEvent")]
public class BTCheckEvent : BTNode
{
    [SerializeField] private AiEvents aiEvents;
    [SerializeField] private bool checkForBool;

    protected override BTStatus Update()
    {
        if (aiEvents.playerWasSpotted == checkForBool) return BTStatus.SUCCESS;
        return BTStatus.FAILURE;
    }
}
