using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ”³¤Î„Ó»­
/// <summary>

public class EnemyAnimation : MonoBehaviour
{

    public string enemyMove= "move";

    public string enemyIdle = "idle";


    public string enemyAttack = "attack";

    public string enemyDeath = "death";

    public AnimationAction action;

    public void Awake()
    {
        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
