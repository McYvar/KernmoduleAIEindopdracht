using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/Invertor")]
public class BTInvertor : BTDecorator
{
    public BTInvertor(BTNode _child) : base(_child) { }

    protected override BTStatus Update()
    {
        BTStatus result = child.Tick();
        switch (result)
        {
            case BTStatus.SUCCESS:
                return BTStatus.FAILURE;

            case BTStatus.FAILURE:
                return BTStatus.SUCCESS;
        }

        return result;
    }
}