using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BT/Action/SimpleCondition")]
public class BTSimpleCondition : BTNode
{
    [SerializeField] Blackboard blackboard;

    [Header("Select variable type for value")]
    [SerializeField] VariableTypes type;
    [ContextMenuItem("Assign this type", "AssignVariable")]
    [SerializeReference] BaseSharedVariable value;

    enum ComparisonType { Equals = 0, NotEquals = 1}
    [Header("Select comparison type (Note: Some types may not work with a few types)")]
    [SerializeField] ComparisonType comparisonType;

    protected override BTStatus Update()
    {
        if (blackboard.dictionary.ContainsKey(value.name))
        {
            switch (comparisonType)
            {
                case ComparisonType.Equals:
                    break;
                case ComparisonType.NotEquals:
                    if (blackboard.dictionary[value.name] != value) return BTStatus.SUCCESS;
                    break;
            }
        }
        return BTStatus.FAILURE;
    }

    void AssignVariable()
    {
        value = VariableSelector.AssignVariable(type);
    }
}
