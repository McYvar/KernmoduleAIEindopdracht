using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "BT/Action/TriggerEvent")]
public class BTTriggerEvent : BTNode
{
    [SerializeField] private UnityEvent trigger;

    protected override BTStatus Update()
    {
        trigger.Invoke();
        return BTStatus.SUCCESS;
    }
}
