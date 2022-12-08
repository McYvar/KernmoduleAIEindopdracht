using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/UseEquipment")]
public class BTUseEquipment : BTNode
{
    protected override BTStatus Update()
    {
        Weapon weapon = agent.GetCurrentEquipment() as Weapon;
        if (weapon != null)
        {
            weapon.UseEquipment(agent.target);
            return BTStatus.SUCCESS;
        }

        SmokeBomb smokeBomb = agent.GetCurrentEquipment() as SmokeBomb;
        if (smokeBomb != null)
        {
            smokeBomb.UseEquipment(agent.target);
            return BTStatus.SUCCESS;
        }

        agent.GetCurrentEquipment().UseEquipment(agent.target);

        return BTStatus.SUCCESS;
    }
}
