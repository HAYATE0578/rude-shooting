using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主人公の数値を管理する
/// <summary>

public class playerStatusInformation : MonoBehaviour
{
    public float MAXHP;
    public float MAXARMOR;
    public float HP = 100;
    public float Armor = 10;
    public float deadEnemyCount;
    public float deathIntervalTime = 3;

    private void Awake()
    {
        MAXHP = HP;
        MAXARMOR = Armor;
    }

    private void Update()
    {
        JumpDeath();
        FigureLimit();
    }

    private void JumpDeath()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < -40) HP = 0;
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
    }

    private void FigureLimit()
    {
        if (HP > MAXHP) HP = MAXHP;
        if (Armor > MAXARMOR) Armor = MAXARMOR;
    }
}
