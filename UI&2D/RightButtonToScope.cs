using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class rightButtonToScope : MonoBehaviour
{
    public bool isScope;
    public GameObject scope;
    public GameObject mainCamera;

    public float onSituation = 20;
    public float offSituation = 60;

    public AudioSource ad;
    public AudioClip onAndOffScope;

    public float genMoveSpeed;
    public float scopeMoveSpeed;

    public float genRotateSpeed;
    public float scopeRotateSpeed = 166.66f;


    public void Awake()
    {
        findScope();
        speedFirstSet();
    }

    private void speedFirstSet()
    {
        genRotateSpeed = Camera.main.GetComponentInChildren<RotateKyara>().rotateSpeed;
    }

    public void Update()
    {
        useScope();
        ScopeSituation();
        ScopeSpeedAndScale();
    }

    public void findScope()
    {
        scope = GameObject.FindGameObjectWithTag("scope");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        scope.SetActive(false);
    }

    private void ScopeSituation()
    {
        genMoveSpeed = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Control>().nowMoveSpeed;
        scopeMoveSpeed = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Control>().walkMoveSpeed;

    }

    public void useScope()
    {
        if (scope.activeSelf == false && Input.GetMouseButtonDown(1))
        {
            mainCamera.GetComponent<Camera>().fieldOfView = onSituation;
            scope.SetActive(true);
            ad.PlayOneShot(onAndOffScope);

            Debug.Log("スコープでき");
        }


        else if (scope.activeSelf == true && Input.GetMouseButtonDown(1))
        {
            mainCamera.GetComponent<Camera>().fieldOfView = offSituation;
            scope.SetActive(false);

            GameObject.FindGameObjectWithTag("Player").
    GetComponent<Control>().nowMoveSpeed = genMoveSpeed;

            Debug.Log("スコープ閉め");
            ad.PlayOneShot(onAndOffScope);
        }

        else
            return;
    }

    private void ScopeSpeedAndScale()
    {
        if (scope.activeSelf == true)
        {
            GameObject.FindGameObjectWithTag("rifle").transform.localScale = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player").
                GetComponent<Control>().nowMoveSpeed = scopeMoveSpeed;
            GameObject.FindGameObjectWithTag("MainCamera").
                GetComponent<RotateKyara>().rotateSpeed =
                GameObject.Find("rotateSpeedChangeFather").
                GetComponentInChildren<rotateSpeedChange>().myScopeSpeed;
        }
        if (scope.activeSelf == false)
        {
            GameObject.FindGameObjectWithTag("rifle").transform.localScale = new Vector3(130, 130, 130);
            GameObject.FindGameObjectWithTag("MainCamera").
                GetComponent<RotateKyara>().rotateSpeed =
                                GameObject.Find("rotateSpeedChangeFather").
                GetComponentInChildren<rotateSpeedChange>().mySpeed;
        }

    }
}
