using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/Invertor")]
public class BTInvertor : BTDecorator
{
    public BTInvertor(BTNode _child) : base(_child) { }

    protected override BTStatus Update()
    {
        if (child.Tick() == BTStatus.SUCCESS) return BTStatus.FAILURE;
        if (child.Tick() == BTStatus.RUNNING) return BTStatus.RUNNING;
        return BTStatus.SUCCESS;
    }
}