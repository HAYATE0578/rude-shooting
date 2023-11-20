using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 50���ϤΔ��򵹤���С����`�ब����
/// <summary>

public class GameWin : MonoBehaviour
{
    public float enemy;
    public float hp;
    public void Update()
    {
        GetCount();
        Restart();
    }

    public void GetCount()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").
            GetComponent<playerStatusInformation>().deadEnemyCount;

        hp = GameObject.FindGameObjectWithTag("Player").
            GetComponent<playerStatusInformation>().HP;

        //�����������֤�UI��@��
        Text [] txt = GetComponentsInChildren<Text>();
        txt[0].enabled = false;
        txt[1].enabled = false;

        if (enemy >= 50)
        {
            txt[0].enabled = true;
            Invoke("PauseGame", 1);
        }

        if (hp<=0)
        {
            txt[1].enabled = true;
            Invoke("PauseGame", 1);
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Remake();
    }

    private static void Restart()
    {
        //p�Ǥ⤦һ�ȥ��`���
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
