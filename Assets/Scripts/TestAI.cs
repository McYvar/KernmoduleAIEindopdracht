using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    [SerializeField] private Blackboard blackboard;
    [SerializeField] private BTNode baseNode;

    private void Start()
    {
        blackboard.Initialize();
    }

    private void Update()
    {
        baseNode?.Tick();
    }
}
