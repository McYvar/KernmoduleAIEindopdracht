using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Base node
public abstract class BTNode : BaseScriptableObject
{
    [SerializeField] private string stateName;

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
        stateText.text = stateName;
    }
    protected virtual void OnTerminate() { isInitialized = false; }
    
    protected Agent agent;
    protected Blackboard globalBlackboard;
    protected TMP_Text stateText;

    public bool isInitialized { get; private set; }

    public virtual void InitializeValues(Agent _agent, Blackboard _globalBlackboard, TMP_Text _stateText)
    {
        agent = _agent;
        globalBlackboard = _globalBlackboard;
        stateText = _stateText;
    }

    public void Abort() { OnTerminate(); }
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

    public override void InitializeValues(Agent _agent, Blackboard _globalBlackboard, TMP_Text _stateText)
    {
        base.InitializeValues(_agent, _globalBlackboard, _stateText);
        foreach (BTNode child in children)
        {
            child.InitializeValues(_agent,_globalBlackboard, _stateText);
        }
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

    public override void InitializeValues(Agent _agent, Blackboard _globalBlackboard, TMP_Text _stateText)
    {
        base.InitializeValues(agent,_globalBlackboard, _stateText);
        child?.InitializeValues(_agent, _globalBlackboard, _stateText);
    }
}
