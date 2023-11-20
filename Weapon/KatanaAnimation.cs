using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class KatanaAnimation : MonoBehaviour
{

    public string leftAttack = "leftAttack";

    public AnimationAction action;

    public void Awake()
    {
        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
