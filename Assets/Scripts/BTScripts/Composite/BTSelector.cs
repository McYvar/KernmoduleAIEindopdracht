using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "BT/Composite/Selector")]
public class BTSelector : BTComposite
{
    public BTSelector(params BTNode[] nodes) : base(nodes) { }

    protected override BTStatus Update()
    {
        for (; currentChild < children.Length; currentChild++)
        {
            BTStatus result = children[currentChild].Tick();
            if (result != BTStatus.FAILURE) return result;
        }
        return BTStatus.FAILURE;
    }
}