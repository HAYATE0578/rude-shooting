using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������ޤ�Ƥ������˹��η���Ҋ�롣
/// <summary>

public class MakeEnemyLookAtMe : MonoBehaviour
{
    private void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
    }
}
