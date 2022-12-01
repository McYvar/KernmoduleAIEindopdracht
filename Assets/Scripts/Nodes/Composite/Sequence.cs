using UnityEngine;

[CreateAssetMenu(menuName = "BT/Composite/Sequence", fileName = "Sequence")]
public class Sequence : Composite
{
    protected override BTStatus Update()
    {
        for (; currentChild < children.Length; currentChild++)
        {
            BTStatus result = children[currentChild].Tick();
            if (result != BTStatus.SUCCESS) return result;
        }
        return BTStatus.SUCCESS;
    }
}
