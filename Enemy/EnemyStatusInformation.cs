using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class EnemyStatusInformation : MonoBehaviour
{
    public float MAXHP;
    public float MAXARMOR;
    public float HP = 100;
    public float Armor = 10;
    public float deathIntervalTime = 3;

    public AudioClip deathClip1;
    public AudioClip deathClip2;
    public AudioClip deathClip3;
    public AudioClip deathClip4;

    public GameObject generateGood10;
    public GameObject generateGood20;
    public GameObject generateGood5;


    private void Awake()
    {
        MAXHP = HP;
        MAXARMOR = Armor;
    }

    public void Damage(float atk, float armorAtk)
    {
        if (HP <= 0) return;

        Armor = Armor - armorAtk;
        if (Armor < 0) Armor = 0;

        if (Armor > 0) HP = HP - (atk * ((MAXARMOR - Armor) / MAXARMOR));
        if (Armor == 0) HP = HP - atk;

        if (HP < 0) HP = 0;

        if (HP <= 0) Death();
    }

    private void Death()
    {
        //destory
        Destroy(this.gameObject, deathIntervalTime);

        GetComponentInChildren<Collider>().enabled = false;
        GetComponent<EnemyGravity>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;


        EnemyAnimation anim = GetComponentInChildren<EnemyAnimation>();
        anim.action.Play(anim.enemyDeath);

        DeathGenerate();

        //
        AudioSource ad = GetComponentInChildren<AudioSource>();

        switch (Random.Range(0, 4))
        {
            case 0: ad.PlayOneShot(deathClip1); break;
            case 1: ad.PlayOneShot(deathClip2); break;
            case 2: ad.PlayOneShot(deathClip3); break;
            case 3: ad.PlayOneShot(deathClip4); break;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatusInformation>().
            deadEnemyCount++;
    }

    private void DeathGenerate()
    {

        if (Random.Range(0, 10) == 1) Instantiate(generateGood10, transform.position, Quaternion.LookRotation
(Camera.main.transform.forward));


        else if (Random.Range(0, 5) == 1) Instantiate(generateGood20, transform.position, Quaternion.LookRotation
(Camera.main.transform.forward));


        else if (Random.Range(0, 19) == 1) Instantiate(generateGood5, transform.position, Quaternion.LookRotation
(Camera.main.transform.forward));

    }
}
