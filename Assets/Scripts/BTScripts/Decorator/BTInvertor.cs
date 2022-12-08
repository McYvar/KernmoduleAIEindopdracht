using UnityEngine;

[CreateAssetMenu(menuName = "BT/Decorator/Invertor")]
public class BTInvertor : BTDecorator
{
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