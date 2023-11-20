using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class BulletCount : MonoBehaviour
{
    public int nowCapacity;
    public int restBullet;
    public GameObject thisGun;

    public void Update()
    {
        GetCountOfBullet();
    }

    public void GetCountOfBullet()
    {

        nowCapacity = thisGun.GetComponent<Gun>().nowAmmo;
        restBullet = thisGun.GetComponent<Gun>().sumAmmo;
        this.GetComponent<Text>().text = (nowCapacity + "/" + restBullet);
    }

}
