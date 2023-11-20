using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自動的にbolcksで道を作る
/// <summary>

public class CreateWay : MonoBehaviour
{
    public GameObject wayBlock;
    public float helpTime;
    public float timeInterval = 4;
     Vector3 instan;

    public void Update()
    {
        if(helpTime<Time.time)
        {
            instan= transform.position+ new Vector3(0, -2.5f, 3.5f);
            Instantiate(wayBlock, instan,Quaternion.Euler(0,0,0));
            helpTime = Time.time + timeInterval;

            Debug.Log(instan);
        }
    }

}
