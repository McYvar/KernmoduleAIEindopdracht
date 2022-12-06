using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Agent
{
    private void Start()
    {
        globalBlackboard?.InitializeAsTeam("Ninja", transform);
    }
}
