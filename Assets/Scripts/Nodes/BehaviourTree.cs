using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode : ScriptableObject
{
    public BTStatus Tick()
    {
        if (!isInitialized)
            OnInitialze();
        BTStatus status = Update();
        if (status != BTStatus.RUNNING)
            OnTerminate();
        return status;
    }

    protected abstract BTStatus Update();
    protected virtual void OnInitialze() { isInitialized = true; }
    protected virtual void OnTerminate() { isInitialized = false; }

    private bool isInitialized;
}
public enum BTStatus { SUCCESS, FAILURE, RUNNING }

public abstract class Composite : BTNode
{
    [SerializeField] protected BTNode[] children;
    protected int currentChild = 0;

    protected override void OnInitialze()
    {
        base.OnInitialze();
        currentChild = 0;
    }
}

public abstract class Decorator : BTNode
{
    [SerializeField] private BTNode child;
    [Space(10) ,Header("If 'Usages' set to -1 means infinite")]
    [SerializeField] private int usages;

    protected override BTStatus Update()
    {

        return BTStatus.SUCCESS;
    }
}