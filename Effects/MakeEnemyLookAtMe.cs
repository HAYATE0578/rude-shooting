using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵が生まれてから主人公の方へ見る。
/// <summary>

public class MakeEnemyLookAtMe : MonoBehaviour
{
    private void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
    }
}
