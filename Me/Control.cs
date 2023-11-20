using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主人公を操作する一番重要なスクリプト
/// <summary>

public class Control : MonoBehaviour
{
    public float nowMoveSpeed = 10;
    public float groundMoveSpeed = 10;
    public float airMoveSpeed = 5;
    public float walkMoveSpeed = 3;
    public CharacterController cc;

    public float jumpLevel = 100;
    public float gravitySpeed = 9.8f;
    public Vector3 velocity;
    public GroundCheck gc;

    public AudioSource oto;
    public AudioClip hashiri0;
    public AudioClip hashiri1;
    public bool footCheck;
    public bool runCheck;
    public float helpTime;
    public float intervalTime=0.5f;

    public bool isMoving;

    public void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Update()
    {
        Movement();
        SpaceJump();
        GravityControl();
        ShiftRun();
        footAudio();
    }

    private void Movement()
    {
        runCheck = true;

        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0) isMoving = true;
        if (hor == 0 && ver == 0) isMoving = false;

        hor *= nowMoveSpeed * Time.deltaTime;
        ver *= nowMoveSpeed * Time.deltaTime;

        Vector3 dir = hor * this.transform.right + ver * this.transform.forward;
        cc.Move(dir);
    }

    private void footAudio()
    {
        if (Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.S) 
            ||Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.D))
        {
            if (helpTime < Time.time 
                && gc.groundCheck == true 
                && footCheck == false
                &&runCheck==true
                )
            {
                int i = Random.Range(0, 2);
                oto.PlayOneShot(hashiri0);
                helpTime = Time.time + intervalTime;
                footCheck = true;
            }
            if (helpTime < Time.time 
                && gc.groundCheck == true
                && footCheck == true
                && runCheck == true
                )
            {
                int i = Random.Range(0, 2);
                oto.PlayOneShot(hashiri1);
                helpTime = Time.time + intervalTime;
                footCheck = false;
            }
        }
    }

    private void SpaceJump()/
    {
        //地面にいないのは必要
        if (Input.GetKeyDown(KeyCode.Space) && gc.groundCheck == true)
        {
            oto.PlayOneShot(hashiri0);
            velocity.y = jumpLevel;
        }
        if (gc.groundCheck == true) nowMoveSpeed = groundMoveSpeed;
        if (gc.groundCheck == false) nowMoveSpeed = airMoveSpeed;
    }

    private void GravityControl()
    {
        velocity.y -= gravitySpeed*Time.deltaTime;
        if (gc.groundCheck == true) velocity.y += gravitySpeed * Time.deltaTime;
        cc.Move(velocity*Time.deltaTime);
    }

    private void ShiftRun()
    {
        //歩行して、足元の音が出ない
        if (Input.GetKey(KeyCode.LeftShift))
        {
            nowMoveSpeed = walkMoveSpeed;
            runCheck = false;
        }
    }
}
