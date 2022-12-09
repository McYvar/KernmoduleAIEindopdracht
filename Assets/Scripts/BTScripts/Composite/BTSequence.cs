using UnityEngine;

[CreateAssetMenu(menuName = "BT/Composite/Sequence")]
public class BTSequence : BTComposite
{
    protected override BTStatus Update()
    {
        for (; currentChild < children.Length; currentChild++)
        {
            BTStatus result = children[currentChild].Tick();
            if (result == BTStatus.FAILURE) currentChild = 0;
            if (result != BTStatus.SUCCESS) return result;
        }
        return BTStatus.SUCCESS;
    }
}