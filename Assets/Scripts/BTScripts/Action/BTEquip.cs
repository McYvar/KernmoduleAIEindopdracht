using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/Equip")]
public class BTEquip : BTNode
{
    protected override BTStatus Update()
    {
        Weapon weapon = agent.target.GetComponent<Weapon>();
        if (weapon != null)
        {
            agent.SetCurrentEquipment(weapon);
            weapon.GetComponent<Renderer>().enabled = false;
            weapon.GetComponent<BoxCollider>().enabled = false;
            weapon.agent = agent;
            return BTStatus.SUCCESS;
        }

        SmokeBomb smokeBomb = agent.target.GetComponent<SmokeBomb>();
        if (smokeBomb != null)
        {
            agent.SetCurrentEquipment(smokeBomb);
            smokeBomb.GetComponent<Renderer>().enabled = false;
            smokeBomb.GetComponent<BoxCollider>().enabled = false;
            smokeBomb.agent = agent;
            return BTStatus.SUCCESS;
        }

        return BTStatus.FAILURE;
    }
}
