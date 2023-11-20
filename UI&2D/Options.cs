using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class options : MonoBehaviour
{
    public GameObject slider;
    public GameObject nowGun ;
    public bool onOff;
    public void Awake()
    {
        slider.SetActive(false);
    }

    public void Update()
    {
        nowGun = GameObject.FindGameObjectWithTag("weapon") ;

        if (Input.GetKeyDown(KeyCode.O) && onOff == false)
        {
            Time.timeScale = 0;
            slider.SetActive(true);
            if(nowGun!=null && nowGun.GetComponentInChildren<Gun>() != false)
                nowGun.GetComponentInChildren<Gun>().enabled = false;
            
            Cursor.lockState = CursorLockMode.None;
            onOff = !onOff;
        }
        else if (Input.GetKeyDown(KeyCode.O) && onOff == true)
        {
            Time.timeScale = 1;
            slider.SetActive(false);
            if (nowGun != null && nowGun.GetComponentInChildren<Gun>() != false)
                nowGun.GetComponentInChildren<Gun>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            onOff = !onOff;
        }
    }
}
