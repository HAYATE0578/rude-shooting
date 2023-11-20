using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///UI§Œhr§Ú æ§π
/// <summary>

public class EnemyHPValueInScreen : MonoBehaviour
{
    public float maxValue;
    public float nowValue;

    private void Update()
    {
        maxValue = GetComponentInParent<EnemyStatusInformation>().MAXHP;
        nowValue = GetComponentInParent<EnemyStatusInformation>().HP;

        this.GetComponent<Slider>().value = nowValue / maxValue;
    }


}
