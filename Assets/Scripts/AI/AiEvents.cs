using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIEvents")]
public class AiEvents : BaseScriptableObject
{
    public bool playerWasSpotted;

    private void OnEnable()
    {
        playerWasSpotted = false;
    }

    public void TriggerOnSpottedPlayer()
    {
        playerWasSpotted = true;
    }

    public void TriggerNoLongerSpottedPlayer()
    {
        playerWasSpotted = false;
    }
}
