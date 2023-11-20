using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class valueArTePlayer : MonoBehaviour
{
    public float maxArmorValue;
    public float nowArmorValue;

    private void Update()
    {
        maxArmorValue = GetComponentInParent<playerStatusInformation>().MAXARMOR;
        nowArmorValue = GetComponentInParent<playerStatusInformation>().Armor;
        this.GetComponent<Text>().text =
            ("<color=white>" + "AR:" + nowArmorValue + "/" + maxArmorValue + "</color>");
    }
}
