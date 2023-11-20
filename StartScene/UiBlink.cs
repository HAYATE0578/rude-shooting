using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class UiBlink : MonoBehaviour
{
    public float ran = 183;
    public bool upDown = false;
    public float blinkSpeedUp = 1;
    public float blinkSpeedDown = 1;

    public float helpTime;
    public float intervalTime=0.05f;


    public void Update()
    {
        if (upDown == false)
        {
            if (helpTime < Time.time)
            {
                ran++;
                if (ran == 255)
                {
                    upDown = !upDown;
                }
                helpTime = Time.time + intervalTime;
            }
        }
        else if (upDown == true)
        {
            if (helpTime < Time.time)
            {
                ran--;
                if (ran == 50)
                {
                    upDown = !upDown;
                }
                helpTime = Time.time + intervalTime;
            }
        }

        GetComponent<Text>().color = new Color(1, 1, 1, ran / 255f);
    }
}
