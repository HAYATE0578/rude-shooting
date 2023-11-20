using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI§Œar§Ú æ§π
/// <summary>

public class EnemyArmorValueInScreen : MonoBehaviour
{
    public float maxValue;
    public float nowValue;

    private void Update()
    {
        maxValue = GetComponentInParent<EnemyStatusInformation>().MAXARMOR;
        nowValue = GetComponentInParent<EnemyStatusInformation>().Armor;
        this.GetComponent<Slider>().value = nowValue / maxValue;
    }


}
