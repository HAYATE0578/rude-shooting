using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����ϵ���ˤ��뤫�ɤ���������å���
/// <summary>

public class GroundCheck : MonoBehaviour
{
    public float marginGround = 0.1f;
    public bool groundCheck;

    private void Update()
    {
        groundCheck = Isground();
    }
    private bool Isground()
    {
        return Physics.Raycast(transform.position, -Vector3.up, marginGround);
    }

}
