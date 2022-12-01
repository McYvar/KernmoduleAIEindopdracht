using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/Debug", fileName = "Debug")]
public class BTDebug : BTNode
{
    [SerializeField] private string debugMessage;

    protected override BTStatus Update()
    {
        Debug.Log(debugMessage);
        return BTStatus.SUCCESS;
    }
}