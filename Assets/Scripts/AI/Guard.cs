using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Agent
{
    private void Start()
    {
        globalBlackboard?.InitializeAsTeam("Guard", transform);
    }
}
