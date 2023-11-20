using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// •´•·•È“ïΩ«§Úπ‹¿Ì
/// <summary>

public class RotateCharacter : MonoBehaviour
{
    public float rotateSpeed = 150;
    public Transform playerBody;
    public Gun gun;

    public bool isRunShoot;
    public bool isFrie;
    public bool isPress;

    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        FindGun();
        CameraLook();
        
    }

    private void CameraLook()
    {
        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");

        X *= rotateSpeed * Time.deltaTime;
        Y *= rotateSpeed * Time.deltaTime;

        xRotation -= Y;
        xRotation = YGunRecoil(xRotation);
        X = XGunRecoil(X);
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up*X);
    }

    private float YGunRecoil(float xRotation)
    {
        if (Input.GetMouseButton(0)&&
            gun.isFire==true&&
            gun.nowDanYaKu>0) xRotation-= 20*Time.deltaTime;
        Debug.Log("bullet aruka"+gun.isFire);
        return xRotation;
    }

    private float XGunRecoil(float X)
    {
        if (Input.GetMouseButton(0) &&
            !gun.anim.action.IsPlaying(gun.anim.reload) &&
            gun.isFire == true&&
            gun.nowDanYaKu > 0)
        {
            float leftRight = Random.Range(0, 2);

            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Control>().isMoving==false)
            {
                if (leftRight == 0) X += 30 * Time.deltaTime;
                if (leftRight == 1) X -= 30 * Time.deltaTime;
                isRunShoot = false;

            }

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Control>().isMoving == true)
            {
                if (leftRight == 0) X += 120 * Time.deltaTime;
                if (leftRight == 1) X -= 120 * Time.deltaTime;
                isRunShoot = true;

            }
        }
        return X;
    }

    private bool IsBulletExist()
    {
        if (GameObject.Find("bullet(Clone)") == null) return false;
        if (GameObject.Find("bullet(Clone)") != null) return true;
        return false;
    }

    private void FindGun()
    {
        if (GameObject.FindGameObjectWithTag("pistol") != null)
            gun = GameObject.FindGameObjectWithTag("pistol").GetComponent<Gun>();
        else if ((GameObject.FindGameObjectWithTag("ak47") != null))
            gun = GameObject.FindGameObjectWithTag("ak47").GetComponent<Gun>();
        else if ((GameObject.FindGameObjectWithTag("rifle") != null))
            gun = GameObject.FindGameObjectWithTag("rifle").GetComponent<Gun>();
        else
            return;
    }


}
