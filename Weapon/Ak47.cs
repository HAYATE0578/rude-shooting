using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class Ak47 : Gun
{


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        FireAndReload();
    }

    public void FireAndReload()
    {
        if (!anim.action.IsPlaying(anim.reload)&&Input.GetMouseButton(0))
        {            
            Firing(muzzle.forward);//ファイヤー
            Debug.Log("ファイヤー");
        }

        if(Input.GetMouseButtonDown(0) && nowDanYaKu <= 0)
        {
            adoGun.PlayOneShot(noBullet);//弾薬なしの音
            Debug.Log("弾薬なし");
        }

        if (Input.GetKeyDown(KeyCode.R))//装弾
        {
            UpdateAmmo();
        }
        if (helpTime < Time.time) muzzleSpecial.SetActive(false);
    }


}
