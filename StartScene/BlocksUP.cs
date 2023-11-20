using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ³õ¤á¤ë¥·©`¥ó¤Ë¤Ï¡¢bolcksÉÏ•N¤¹¤ë
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
