using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base node
public abstract class BTNode
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

// Composite
public abstract class BTComposite : BTNode
{
    public BTComposite(params BTNode[] nodes)
    {
        children = nodes;
    }

    protected BTNode[] children;
    protected int currentChild = 0;

    protected override void OnInitialze()
    {
        base.OnInitialze();
        currentChild = 0;
    }
}

// Sequence
public class BTSequence : BTComposite
{
    public BTSequence(params BTNode[] nodes) : base(nodes) { }

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

// Selector
public class BTSelector : BTComposite
{
    public BTSelector(params BTNode[] nodes) : base(nodes) { }

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

// Decorator
public abstract class BTDecorator : BTNode
{
    protected BTNode child;
    public BTDecorator(BTNode _child)
    {
        child = _child;
    }
}

#region Decorator nodes
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
#endregion

#region Action Nodes
public class BTWait : BTNode
{
    public BTWait(int _waitTime)
    {
        waitTime = _waitTime;
    }

    private float waitTime;
    private float currentTime;

    protected override BTStatus Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= waitTime)
        {
            currentTime = 0;
            return BTStatus.SUCCESS;
        }
        return BTStatus.RUNNING;

    }
}

public class BTDebug : BTNode
{
    public BTDebug(string _message)
    {
        debugMessage = _message;
    }

    private string debugMessage;

    protected override BTStatus Update()
    {
        Debug.Log(debugMessage);
        return BTStatus.SUCCESS;
    }
}

#endregion