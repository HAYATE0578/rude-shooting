using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class Gun : MonoBehaviour
{
    public int nowAmmoCount = 10;
    public int ammoCapacity = 10;
    public int sumAmmo = 30;


    public AudioSource adoGun;//
    public AudioClip clpGun;//ファイヤー
    public AudioClip recharge;//装弾
    public AudioClip noBullet;//弾薬なし
    public AudioClip fallBulet;

    public bool isFire;

    public GameObject thisBullet;
    public Transform muzzle;

    public GameObject muzzleSpecial;
    
    public float atk = 10;//攻撃力 
    public float armorAtk = 10;//防御力削減
    public float bulletMoveSpeed = 400;

    public float helpTime;
    public float atkIntervalTime = 0.5f;//ファイヤー間隔時間

    public GunAnimation anim;// fire reload



    protected virtual void Start()
    {
        muzzleSpecial.SetActive(false);
        anim = GetComponent<GunAnimation>();
    }

    protected virtual void Update()
    {
        ReloadOverCanChangeWeapon();
        AutoAmmo();
    }

    protected bool Ready()
    {
        if (anim == false || nowAmmoCount <= 0) return false;
        if (anim != false && Time.time >= helpTime)//间隔
        {
            nowAmmoCount--;
            Debug.Log("弾薬減少");
        }
        return true;
    }
    public void Firing(Vector3 vec)
    {

        if (nowAmmoCount <= 0 && Ready() == false) return;
        if (nowAmmoCount > 0 && Ready() == true && Time.time >= helpTime)
        {
            isFire = true;

            adoGun.PlayOneShot(clpGun);
            anim.action.PlayQueued(anim.openFire);
            muzzleSpecial.SetActive(true);
            GameObject movingBullet = Instantiate(thisBullet, muzzle.position, Quaternion.LookRotation(vec));
            movingBullet.GetComponent<bullet>().atk = atk;
            movingBullet.GetComponent<bullet>().armorAtk = armorAtk;
            movingBullet.GetComponent<bullet>().bulletMoveSpeed = bulletMoveSpeed;


            if (fallBulet != null && !anim.action.IsPlaying(anim.openFire)) Invoke("FallBullet", 0.6f);
            helpTime = Time.time + atkIntervalTime;

            Invoke("FireSituationChange",0.05f);
        }
    }

    public void UpdateAmmo()
    {
        GameObject.FindGameObjectWithTag("MainCamera").
            GetComponent<weaponChange>().enabled = false;

        if (sumAmmo <= 0 || nowAmmoCount == ammoCapacity) return;

        if (sumAmmo < ammoCapacity)
        {
            nowAmmoCount += sumAmmo;
            sumAmmo = 0;
            anim.action.Play(anim.reload);
            adoGun.PlayOneShot(recharge);

            Debug.Log("最後の装弾");
            return;
        }

        int gap = ammoCapacity - nowAmmoCount;
        nowAmmoCount += gap;
        sumAmmo -= gap;


        anim.action.Play(anim.reload);
        adoGun.PlayOneShot(recharge);
        Debug.Log("装弾終了");
    }

    private void ReloadOverCanChangeWeapon()
    {
        Debug.Log("ReloadOverCanChangeWeapon");
        if (!anim.action.IsPlaying(anim.reload))
            GameObject.FindGameObjectWithTag("MainCamera").
                    GetComponent<weaponChange>().enabled = true;
    }

    private void FallBullet()
    {
        adoGun.PlayOneShot(fallBulet);
    }

    private void AutoAmmo()
    {
        if(nowAmmoCount == 0&& sumAmmo != 0)
        {
            UpdateAmmo();
        }
    }

    private void FireSituationChange()
    {
        isFire = !isFire;
    }
}
