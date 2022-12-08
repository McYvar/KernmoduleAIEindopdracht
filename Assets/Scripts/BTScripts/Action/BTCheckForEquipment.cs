using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/CheckForEquipment")]
public class BTCheckForEquipment : BTNode
{
    protected override BTStatus Update()
    {
        Weapon weapon = agent.GetCurrentEquipment() as Weapon;
        if (weapon != null) return BTStatus.SUCCESS;

        SmokeBomb smokeBom = agent.GetCurrentEquipment() as SmokeBomb;
        if (smokeBom != null) return BTStatus.SUCCESS;

        return BTStatus.FAILURE;
    }
}
