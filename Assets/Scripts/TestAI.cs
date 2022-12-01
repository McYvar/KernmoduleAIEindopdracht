using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    [SerializeField] private BTNode baseNode;

    private void Update()
    {
        baseNode?.Tick();
    }
}
