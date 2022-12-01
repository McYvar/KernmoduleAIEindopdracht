using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    private BTNode tree;
    public void Start()
    {
        tree =
            new Sequence(
                new BTWait(2f),
                new BTDebug("Hoi"),
                new BTWait(0.4f),
                new BTDebug("Spammmmm")
            );
    }

    private void Update()
    {
        tree?.Tick();
    }
}
