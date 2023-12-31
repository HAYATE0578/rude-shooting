using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラが除づくと、キャラの�z方�､�貧がり、このオブジェクトが徭�啜弔縫妊好疋譽ぅ�
/// <summary>

public class ARbuff : MonoBehaviour
{
    public float rotateSpeed = 65;

    private void Update()
    {
        //ゲ�`ムのオブジェクトが徭�啜弔忙悗�
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        //キャラとの鉦�xが玉ければ、借�Pする
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
