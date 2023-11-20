using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class valueHpTePlayer : MonoBehaviour
{
    public float maxArmorValue;
    public float nowArmorValue;

    private void Update()
    {
        maxArmorValue = GetComponentInParent<playerStatusInformation>().MAXHP;
        nowArmorValue = GetComponentInParent<playerStatusInformation>().HP;
        this.GetComponent<Text>().text =
            ("<color=white>" + "HP:" + nowArmorValue + "/" + maxArmorValue + "</color>");
    }
}
