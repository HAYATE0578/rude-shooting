using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1234で武器をチェンジする
/// <summary>

public class WeaponChange : MonoBehaviour
{
    GameObject[] weapon;
    public AudioSource ad;
    public AudioClip change;

    public float scopeOff = 60;

    private void Awake()
    {
        weaponSearch();
    }

    private void Update()
    {
        weaponToChange();
    }

    private void weaponSearch()
    {
        weapon = GameObject.FindGameObjectsWithTag("weapon");
        foreach (var item in weapon)
        {
            item.SetActive(false);
        }
    }

    private void weaponToChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapon[0] == null) return;
            foreach (var item in weapon)
            {
                item.SetActive(false);
            }
            weapon[0].SetActive(true);
            ad.PlayOneShot(change);
            ScopeSet();
            Debug.Log("武器１用意");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weapon[1] == null) return;
            foreach (var item in weapon)
            {
                item.SetActive(false);
            }
            weapon[1].SetActive(true);
            ad.PlayOneShot(change);
            Debug.Log("武器２用意");
            ScopeSet();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapon[2] == null) return;
            foreach (var item in weapon)
            {
                item.SetActive(false);
            }
            weapon[2].SetActive(true);
            Debug.Log("武器３用意");
            ad.PlayOneShot(change);
            ScopeSet();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (weapon[3] == null) return;
            foreach (var item in weapon)
            {
                item.SetActive(false);
            }
            weapon[3].SetActive(true);
            ad.PlayOneShot(change);
            Debug.Log("武器４用意");
            ScopeSet();
        }
    }

    private void ScopeSet()
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<Camera>().fieldOfView = scopeOff;
        GameObject.FindGameObjectWithTag("weapon").GetComponent<rightButtonToScope>().scope.SetActive(false);
    }
}
