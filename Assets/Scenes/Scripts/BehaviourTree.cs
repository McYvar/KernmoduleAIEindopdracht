using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTStatus {  SUCCESS, FAILURE, RUNNING }

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

public abstract class Composite : BTNode
{
    protected BTNode[] children;
    protected int currentChild = 0;
    public Composite(params BTNode[] _children)
    {
        children = _children;
    }

    protected override void OnInitialze()
    {
        base.OnInitialze();
        currentChild = 0;
    }
}

public class Sequence : Composite
{
    public Sequence(params BTNode[] _children) : base(_children) { }

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

public class Selector : Composite
{
    public Selector(params BTNode[] _children) : base(_children) { }

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

//Action node
public class BTWait : BTNode
{
    private float waitTime;
    private float currentTime;
    public BTWait(float _waitTime)
    {
        waitTime = _waitTime;
    }

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

//Action node
public class BTDebug : BTNode
{
    private string debugMessage;
    public BTDebug(string _debugMessage)
    {
        debugMessage = _debugMessage;
    }

    protected override BTStatus Update()
    {
        Debug.Log(debugMessage);
        return BTStatus.SUCCESS;
    }
}