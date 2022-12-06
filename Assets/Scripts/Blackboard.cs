using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blackboard")]
public class Blackboard : BaseScriptableObject
{
    [SerializeReference] public List<BaseSharedVariable> baseSharedVariables = new List<BaseSharedVariable>();

    public Dictionary<string, object> dictionary = new Dictionary<string, object>();

    public T GetVariable<T>(string name) where T : BaseSharedVariable
    {
        if (dictionary.ContainsKey(name))
        {
            return dictionary[name] as T;
        }
        return null;
    }

    public void AddVariable(string _name, BaseSharedVariable _variable)
    {
        dictionary.Add(_name, _variable);
    }

    public void Initialize()
    {
        foreach (var variable in baseSharedVariables)
        {
            AddVariable(variable.name, variable);
        }
    }

    public void InitializeAsTeam(string _team, Transform _unit)
    {
        if (dictionary.ContainsKey(_team))
        {
            TransformListVariable t = GetVariable<TransformListVariable>(_team);
            t.name = _team;
            t.Value.Add(_unit);
            return;
        }

        AddTransformListVariable();
        AddVariable(_team, baseSharedVariables[baseSharedVariables.Count - 1]);
        InitializeAsTeam(_team, _unit);
    }

    [ContextMenu("Add FloatVariable")]
    public void AddFloatVariable()
    {
        baseSharedVariables.Add(new FloatVariable());
    }

    [ContextMenu("Add TransformListVariable")]
    public void AddTransformListVariable()
    {
        baseSharedVariables.Add(new TransformListVariable());
    }
}

[System.Serializable]
public class BaseSharedVariable 
{
    public string name;
}

public class SharedVariable<T> : BaseSharedVariable
{
    public event System.Action<T> OnValueChanged;

    [SerializeField] protected T value;
    public T Value 
    { 
        get { return value; }
        set 
        {
            if (!value.Equals(this.value))
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
            else
            {
                this.value = value;
            }
        }
    }
}

public enum VariableTypes { floatVariable = 0, transformListVariable = 1 }

public class VariableSelector
{
    public static BaseSharedVariable AssignVariable(VariableTypes type)
    {
        switch (type)
        {
            case VariableTypes.floatVariable:
                return new FloatVariable();
        }

        return null;
    }
}

[System.Serializable]
public class FloatVariable : SharedVariable<float> { }

[System.Serializable]
public class TransformListVariable : SharedVariable<List<Transform>> 
{
    public TransformListVariable()
    {
        value = new List<Transform>();
    }
}