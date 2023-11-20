using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���衣����ѧ�侀�Υ᥽�åɤǏ�����Ƅӡ����Ĥ�g�F
/// <summary>

public class Bullet : MonoBehaviour
{
    public RaycastHit hit;

    public float atk = 10;
    public float armorAtk = 10;
    public float maxDistance = 200;
    public float bulletMoveSpeed = 400;

    public LayerMask mask;
    protected Vector3 targetGoal;
    public Transform eyeMidPoint;

    public float hearDistanceXX=600;

    public AudioSource ad;


    public void Start()
    {
        BulletRay();
        MakeDamage();

    }

    private void MakeDamage()
    {
        //Ŀ�ˤϔ����h���������뤫�ɤ���������å�
        if (hit.collider.name != null && hit.collider.tag == "Enemy")
        {
            hit.collider.GetComponentInParent<EnemyStatusInformation>().Damage(atk, armorAtk);
        }
        if (hit.collider.name != null && hit.collider.tag == "Wood")
        {
            hit.collider.GetComponentInParent<EnemyStatusInformation>().Damage(atk, armorAtk);
        }
        if (hit.collider.name != null && hit.collider.tag == "onOff")
        {
            hit.collider.GetComponentInParent<gameONOFF>().onOff =
                !hit.collider.GetComponentInParent<gameONOFF>().onOff;
        }
    }

    public void Update()
    {
        BulletMovement();
    }
    public void BulletRay()
    {
        //csgo�ߤ����ˡ�Ŀ�����Ĥ�Ŀ�ˤη���
        eyeMidPoint = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if (Physics.Raycast(eyeMidPoint.position, eyeMidPoint.forward, out hit, maxDistance, mask))
        {
            targetGoal = hit.point;
        }
        else//�ʤ��ȣ�������`�ȥ�ޤǰk��
        {
            targetGoal = transform.forward * 200 + transform.position;
        }

        Debug.DrawLine(transform.position, targetGoal, Color.red);
    }

    public void BulletMovement()
    {

        transform.position = Vector3.MoveTowards
            (transform.position, targetGoal, bulletMoveSpeed * Time.deltaTime);
        //���Ť�����ڃP
        if ((this.transform.position - targetGoal).sqrMagnitude < 0.1f)
        {
            Destroy(this.gameObject);
            GenerateContactEffect();
            GenerateAudioEffects();
        }
    }

    public void GenerateContactEffect()
    {
        if (hit.collider == null) return;
        GameObject prefabGO =
            Resources.Load<GameObject>("ContactEffects/Effects" + hit.collider.tag);
        if (prefabGO == null) return;
        Instantiate(prefabGO, targetGoal + 0.01f * hit.normal, Quaternion.LookRotation(hit.normal));
    }

    private void GenerateAudioEffects()
    {
        if(hit.collider.gameObject.GetComponent<AudioSource>()!=null)
            ad = hit.collider.gameObject.GetComponent<AudioSource>();
        if (ad == null) return;
        if (ad.clip!=null
            &&(GameObject.FindGameObjectWithTag("MainCamera").transform.position-targetGoal).sqrMagnitude<hearDistanceXX)
        {
            ad.PlayOneShot(ad.clip);
        }
    }
}
