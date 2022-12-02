using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    private BTNode baseNode;

    private void Start()
    {
        baseNode = new BTSelector(
            //new BTInvertor(
                new BTDebug("hallo"),
            new BTWait(2));
    }

    private void Update()
    {
        baseNode?.Tick();
    }
}
