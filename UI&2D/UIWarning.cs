using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class UIWarning : MonoBehaviour
{
    public Text text;
    public bool isOrNot;
    public int DanYaKu;
    public string targetGunName;

    public void Update()
    {
        IsRunShoot();
        DanYaKuZero();
    }
    private void IsRunShoot()
    {
        if (Input.GetMouseButton(0))
        {
            text = this.gameObject.GetComponent<Text>();
            isOrNot = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RotateKyara>().isRunShoot;
            if (isOrNot == true) text.text ="移動中の射撃は精度が低い";
            if (isOrNot == false) text.text = null;
        }
    }
    private void DanYaKuZero()
    {

        DanYaKu = GameObject.FindGameObjectWithTag(targetGunName).GetComponent<Gun>().nowDanYaKu;
        if (DanYaKu == 0)
        {
            text.text = "Rを押して弾薬を補充しよう！";
        }
        if (Input.GetKeyDown(KeyCode.R)) text.text = null;
    }
}

