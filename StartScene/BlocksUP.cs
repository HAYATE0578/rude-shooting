using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����륷�`��ˤϡ�bolcks�ϕN����
/// <summary>

public class BlocksUP : MonoBehaviour
{
    public float deleteTime = 6;

    public float upSpeed = 1;

    public void Update()
    {

        if (transform.position.y < 0)
        {
            transform.Translate(transform.up * upSpeed * Time.deltaTime);
        }

        Destroy(this.gameObject, deleteTime);

    }
}
