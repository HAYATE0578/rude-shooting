using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ޤ줿�Ф���Δ����ƄӤ����롣
/// <summary>

public class MakeEnemyMoveForward : MonoBehaviour
{
    public float rotateSpeed=65;

    private void Update()
    {
        this.transform.Rotate
            (transform.forward, rotateSpeed * Time.deltaTime,Space.World);
    }
}
