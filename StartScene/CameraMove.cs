using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ǰ���ƄӤ����롣
/// <summary>

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1;

    public void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
}
