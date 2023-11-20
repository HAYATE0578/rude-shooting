using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class rotateSpeedChange : MonoBehaviour
{
    public float mySpeed;
    public float myScopeSpeed;
    public void Awake()
    {
        mySpeed = Camera.main.GetComponentInChildren<RotateKyara>().rotateSpeed;
    }

    public void Update()
    {
        mySpeed= 200 + GetComponentInChildren<Slider>().value;
        myScopeSpeed = mySpeed * 1 / 3;
            Camera.main.GetComponentInChildren<RotateKyara>().rotateSpeed= mySpeed;

        Camera.main.GetComponentInChildren<rightButtonToScope>().scopeRotateSpeed =
            myScopeSpeed;
        Camera.main.GetComponentInChildren<rightButtonToScope>().genRotateSpeed =
    mySpeed;
    }
}
