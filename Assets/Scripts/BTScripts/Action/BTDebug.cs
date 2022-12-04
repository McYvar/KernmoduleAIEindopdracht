using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/BTDebug")]
public class BTDebug : BTNode
{
    public BTDebug(string _message)
    {
        debugMessage = _message;
    }

    [SerializeField] private string debugMessage;

    protected override BTStatus Update()
    {
        Debug.Log(debugMessage);
        return BTStatus.SUCCESS;
    }
}