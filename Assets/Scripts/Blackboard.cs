using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blackboard")]
public class Blackboard : ScriptableObject
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

    public void AddVariable(string name, BaseSharedVariable variable)
    {
        dictionary.Add(name, variable);
    }

    [ContextMenu("Add FloatVariable")]
    public void AddFloatVariable()
    {
        baseSharedVariables.Add(new FloatVariable());
    }

    public void Initialize()
    {
        foreach (var variable in baseSharedVariables)
        {
            AddVariable(variable.name, variable);
        }
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


public enum VariableTypes { floatVariable = 0 }

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