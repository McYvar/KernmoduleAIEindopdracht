using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Base node
public abstract class BTNode : BaseScriptableObject
{
    public bool isInitialized { get; private set; }
    
    protected Agent agent;
    protected Blackboard globalBlackboard;
    protected TMP_Text stateText;
    
    [SerializeField, TextArea] private string stateName;

    private void OnEnable()
    {
        isInitialized = false;
    }

    public BTStatus Tick()
    {
        if (!isInitialized)
            OnInitialze();
        BTStatus status = Update();
        if (status != BTStatus.RUNNING)
            OnTerminate();
        //Debug.Log(name + " : " + status);
        return status;
    }

    protected abstract BTStatus Update();
    protected virtual void OnInitialze() { 
        isInitialized = true;
        stateText.text = stateName;
    }
    protected virtual void OnTerminate() { isInitialized = false; }
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

    public override void InitializeValues(Agent _agent, Blackboard _globalBlackboard, TMP_Text _stateText)
    {
        base.InitializeValues(agent,_globalBlackboard, _stateText);
        child?.InitializeValues(_agent, _globalBlackboard, _stateText);
    }
}
