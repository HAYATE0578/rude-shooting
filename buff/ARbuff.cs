using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����餬���Ť��ȡ��������z�������Ϥ��ꡢ���Υ��֥������Ȥ��ԄӵĤ˥ǥ��ɥ쥤��
/// <summary>

public class ARbuff : MonoBehaviour
{
    public float rotateSpeed = 65;

    private void Update()
    {
        //���`��Υ��֥������Ȥ��ԄӵĤ˻ؤ�
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        //�����Ȥξ��x���̤���С��ڃP����
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
