using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///¥­¥å©`¥Ö¤ËÉä“Ä¤·¤Æ¡¢¥²©`¥à¤ò¥¹¥¿¥Ã¥È¤µ¤»¤ë¡£”³¤¬¥é¥ó¥À¥à¤Ë³ö¬F¤¹¤ë¡£
/// <summary>

public class GameONOFF : MonoBehaviour
{
    public bool onOff;
    public GameObject [] birthPoints;
    public GameObject enemy;
    public GameObject birthEffect;
    public GameObject cubeEffect;
    public GameObject barrierEffect;

    public float helpTime;
    public float birthIntervalTime=2;

    private float scaleOn=0;
    public float scaleMax = 1;
    public float scaleTime = 4;

    public void Awake()
    {
        FindPoints();
    }

    public void Update()
    {
        OnOffCheck();
        ColorJudge();
        EffectRotateColorJudge();
    }

    public void OnOffCheck()
    {
        int i = Random.Range(0, 5);
        if(onOff==true)
        {
            if(helpTime<Time.time)
            {
                Instantiate(enemy, birthPoints[i].transform.position, 
                    Quaternion.LookRotation(Camera.main.transform.position));
                GameObject newBirthEffect = Instantiate(birthEffect, birthPoints[i].transform.position,
                    Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position));
                Destroy(newBirthEffect, 3);
                helpTime = Time.time + birthIntervalTime;
            }
        }
    }

    public void FindPoints()
    {
        birthPoints = GameObject.FindGameObjectsWithTag("points");
    }

    public void ColorJudge()
    {
        if (!onOff)
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            cubeEffect.SetActive(false);

        }
        if (onOff)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            this.transform.Rotate(this.transform.up, 90*Time.deltaTime);
            cubeEffect.SetActive(true);
        }
    }

    public void EffectRotateColorJudge()
    {
        if (onOff == true)
        {
            foreach (var item in birthPoints)
            {
                scaleOn = Mathf.Lerp(scaleOn, scaleMax, scaleTime * Time.deltaTime);
                if (3 / 1f - scaleOn < 0.1f) scaleOn = scaleMax;

                item.GetComponentInChildren<GenerateEnemySp>().rotateSpeed = 65;
                item.GetComponentInChildren<GenerateEnemySp>().gameObject.transform.localScale = 
                    new Vector3(scaleOn, scaleOn, scaleOn);
                item.GetComponentInChildren<SpriteRenderer>().color = new Color(81f/255f,255f/255f,140f/255f,150f/255f);
            }
        }
        if (onOff == false)
        {
            foreach (var item in birthPoints)
            {
                scaleOn = Mathf.Lerp(scaleOn, 0 , scaleTime * Time.deltaTime);
                if (scaleOn- 0 < 0.1f) scaleOn = 0;

                item.GetComponentInChildren<GenerateEnemySp>().rotateSpeed = 0;
                item.GetComponentInChildren<GenerateEnemySp>().gameObject.transform.localScale =
                    new Vector3(scaleOn, scaleOn, scaleOn);
                item.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }
        }

    }
}
