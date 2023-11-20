using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class valueHpScPlayer : MonoBehaviour
{
    public float maxValue;
    public float nowValue;

    private void Update()
    {
        maxValue = GetComponentInParent<playerStatusInformation>().MAXHP;
        nowValue = GetComponentInParent<playerStatusInformation>().HP;
        this.GetComponent<Slider>().value = nowValue / maxValue;
    }

}
