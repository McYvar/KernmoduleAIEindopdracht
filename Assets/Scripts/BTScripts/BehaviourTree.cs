using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base node
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
    protected virtual void OnInitialze() { 
        isInitialized = true; 
    }
    protected virtual void OnTerminate() { isInitialized = false; }

    private bool isInitialized;
}
public enum BTStatus { SUCCESS, FAILURE, RUNNING }

// Composite
public abstract class BTComposite : BTNode
{
    public BTComposite(params BTNode[] nodes)
    {
        children = nodes;
    }

    [SerializeReference] protected BTNode[] children;
    protected int currentChild = 0;

    protected override void OnInitialze()
    {
        base.OnInitialze();
        currentChild = 0;
    }
}

// Decorator
public abstract class BTDecorator : BTNode
{
    [SerializeField] protected BTNode child;
    public BTDecorator(BTNode _child)
    {
        child = _child;
    }
}
