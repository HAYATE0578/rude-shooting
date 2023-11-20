using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class GunAnimation : MonoBehaviour
{
    //ファイヤー動画
    public string openFire = "openFire0578";

    //装弾動画
    public string reload = "reload0578";

    public AnimationAction action;

    public void Awake()
    {
        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
