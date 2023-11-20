using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///UI¤Îhr¤ÎÊý‚Ž¤òÊ¾¤¹
/// <summary>

public class EnemyHPValueInText : MonoBehaviour
{
    public float maxHpValue;
    public float nowHpValue;

    private void Update()
    {
        maxHpValue = GetComponentInParent<EnemyStatusInformation>().MAXHP;
        nowHpValue = GetComponentInParent<EnemyStatusInformation>().HP;
        this.GetComponent<Text>().text = ("<color=white>" +"HP:"+nowHpValue +"/"+maxHpValue+ "</color>");
    }


}
