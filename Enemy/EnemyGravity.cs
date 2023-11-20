using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ”³¤¬ÂäÏÂ¤¹¤ë¤«¤É¤¦¤«¤ò
/// <summary>

public class EnemyGravity : MonoBehaviour
{
    public CharacterController cc;
    public float gravitySpeed = 9.8f;
    public Vector3 velocity;
    public GroundCheck gc;

    public bool isMoving;

    public void Update()
    {
        GravityControl();
    }

    private void GravityControl()
    {
        velocity.y -= gravitySpeed * Time.deltaTime;
        if (gc.groundCheck == false)
        {
            GetComponentInParent<EnemyAI>().enabled = false;
            cc.Move(velocity * Time.deltaTime);
        }
        else if (gc.groundCheck == true)
        {
            velocity.y += gravitySpeed * Time.deltaTime;
            GetComponentInParent<EnemyAI>().enabled = true;
        }
    }
}
