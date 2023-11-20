using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class myHP : MonoBehaviour
{
    private void Update()
    {
        float HP = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatusInformation>().HP;
        this.GetComponent<Text>().text = ("HPÅF"+HP.ToString());


    }
}
