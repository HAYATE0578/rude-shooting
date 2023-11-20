using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// <summary>

public class ValueArScPlayer : MonoBehaviour
{
    public float maxValue;
    public float nowValue;

    private void Update()
    {
        maxValue = GetComponentInParent<playerStatusInformation>().MAXARMOR;
        nowValue = GetComponentInParent<playerStatusInformation>().Armor;
        this.GetComponent<Slider>().value = nowValue / maxValue;
    }

}
