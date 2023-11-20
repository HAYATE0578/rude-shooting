using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラが近づくと、キャラの鎧数値が上がり、このオブジェクトが自動的にデスドレイン
/// <summary>

public class ARbuff : MonoBehaviour
{
    public float rotateSpeed = 65;

    private void Update()
    {
        //ゲームのオブジェクトが自動的に回り
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        //キャラとの距離が短ければ、稼働する
        if ((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).sqrMagnitude < 5)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatusInformation>().Armor += 20;
            AudioSource ad = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
            AudioClip ac = this.gameObject.GetComponent<AudioSource>().clip;
            ad.PlayOneShot(ac);

            Destroy(this.gameObject);
        }
    }
}
