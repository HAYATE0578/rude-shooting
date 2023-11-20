using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class Rifle : Gun
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
        if (!anim.action.IsPlaying(anim.reload) && Input.GetMouseButtonDown(0))
        {
            Firing(muzzle.forward);

        }

        if (Input.GetMouseButtonDown(0) && nowDanYaKu <= 0)
        {
            adoGun.PlayOneShot(noBullet);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateAmmo();
        }
        if (helpTime < Time.time) muzzleSpecial.SetActive(false);
    }


}
