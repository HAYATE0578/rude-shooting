using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// < summary >
///
/// < summary >

public class Katana : MonoBehaviour
{
    public AudioSource ado;//
    public AudioClip leftAttack;//ファイヤー

    public float atk = 10;//攻撃力 
    public float armorAtk = 10;//防御力削減
    public float atkDistance = 3;

    public float helpTime;
    public float atkIntervalTime = 0.5f;//ファイヤー間隔時間

    public KatanaAnimation anim;// fire reload



    private void Start()
    {
        anim = GetComponent<KatanaAnimation>();
    }

    private void Update()
    {
        AnimCannotChangeWeapon();
        KatanaMouseDown();
    }

    protected bool Ready()
    {
        if (anim == false) return false;
        if (anim != false && Time.time >= helpTime)//间隔
        {
            Debug.Log("切り！");
        }
        return true;
    }
    public void KatanaAttack()
    {

        if (Ready() == false) return;
        if (Ready() == true && Time.time >= helpTime)
        {
            ado.PlayOneShot(leftAttack);
            anim.action.PlayQueued(anim.leftAttack);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] woods = GameObject.FindGameObjectsWithTag("Wood");
            foreach (var item in enemies)
            {
                if ((item.transform.position - Camera.main.transform.position).magnitude < atkDistance)
                {
                    item.GetComponentInParent<EnemyStatusInformation>().Damage(atk, armorAtk);
                }             

            }
            foreach (var item in woods)
            {
                if ((item.transform.position - Camera.main.transform.position).magnitude < atkDistance)
                {
                    item.GetComponentInParent<EnemyStatusInformation>().Damage(atk, armorAtk);
                }

            }

            helpTime = Time.time + atkIntervalTime;
        }
    }

    public void AnimCannotChangeWeapon()
    {
        if (anim.action.IsPlaying(anim.leftAttack))
        {
            GameObject.FindGameObjectWithTag("MainCamera").
    GetComponent<weaponChange>().enabled = false;
            return;
        }
        GameObject.FindGameObjectWithTag("MainCamera").
GetComponent<weaponChange>().enabled = true;

    }

    public void KatanaMouseDown()
    {
        if (!anim.action.IsPlaying(anim.leftAttack) && Input.GetMouseButtonDown(0))
        {
            KatanaAttack();//ファイヤー
            Debug.Log("ファイヤー");
        }
    }
}
