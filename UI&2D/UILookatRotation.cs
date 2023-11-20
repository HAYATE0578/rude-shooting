using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// <summary>

public class UILookatRotation : MonoBehaviour
{
    public Transform player;
    public RectTransform rectTransform;


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        this.transform.LookAt(player);
    }
}
