using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 伏まれたばかりの�海鰔��咾気擦襦�
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
