using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class deadEnemyCount : MonoBehaviour
{
    public float enemy;

    public void Update()
    {
        GetCountOfEnemy();
    }

    public void GetCountOfEnemy()
    {

        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatusInformation>().deadEnemyCount;
        this.GetComponent<Text>().text = ("“ÄÆÆ£º"+enemy + "/" + 50);
    }

}
