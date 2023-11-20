using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI¤Îar¤ÎÊý‚Ž¤òÊ¾¤¹
/// <summary>

public class EnemyArmorValueInText: MonoBehaviour
{
    public float maxArmorValue;
    public float nowArmorValue;

    private void Update()
    {
        maxArmorValue = GetComponentInParent<EnemyStatusInformation>().MAXARMOR;
        nowArmorValue = GetComponentInParent<EnemyStatusInformation>().Armor;
        this.GetComponent<Text>().text = 
            ("<color=white>" + "AR:" + nowArmorValue + "/" + maxArmorValue + "</color>");
    }


}
