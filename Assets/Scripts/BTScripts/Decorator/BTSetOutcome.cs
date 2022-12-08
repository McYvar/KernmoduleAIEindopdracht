using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/SetOutcome")]
public class BTSetOutcome : BTDecorator
{
    // Method, regardless of the child status, alsways returns the set status
    [SerializeField] BTStatus setStatus;
    protected override BTStatus Update()
    {
        child.Tick();
        return setStatus;
    }
}
