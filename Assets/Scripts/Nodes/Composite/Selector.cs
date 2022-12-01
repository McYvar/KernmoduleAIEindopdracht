using UnityEngine;

[CreateAssetMenu(menuName = "BT/Composite/Selector", fileName = "Selector")]
public class Selector : Composite
{
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
