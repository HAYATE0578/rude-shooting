using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Éú¤Þ¤ì¤¿¤Ð¤«¤ê¤Î”³¤òÒÆ„Ó¤µ¤»¤ë¡£
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
