using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ”³¤ÎAI
/// <summary>

public class EnemyAI : MonoBehaviour
{
    public float enemyATK = 10;
    public float enemyArmorATK = 3;

    //helpTime
    float helpATKTime;


    //intervalTime
    public float enemyATKintervalTime = 1;


    public Transform player;
    public Vector3 enemyLookPlayer;
    public EnemyAnimation ea;

    public AudioSource ad;

    public AudioClip audioATK1;
    public AudioClip audioATK2;
    public AudioClip audioATK3;
    public AudioClip audioATK4;

    public float policeRange = 10;
    public float rotateSpeed = 3;
    public float moveSpeed = 4;
    public float attackRange = 5;

    private void Awake()
    {
        FindAnimation();

    }


    private void Update()
    {
        FindPlayer();
        PoliceBeha();
        EnemyAttack();
    }

    private void FindPlayer()
    {
        ad = this.gameObject.GetComponent<AudioSource>();
        player = GameObject.Find("GroundCheckPlayer").transform;
        enemyLookPlayer = player.position - transform.position;
    }
    private void FindAnimation()
    {
        ea = GetComponent<EnemyAnimation>();
    }

    private void PoliceBeha()
    {
            LookatROT(player.position);
            if (enemyLookPlayer.magnitude < attackRange) return;
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            ea.action.Play(ea.enemyMove);



    }

    public void LookatROT(Vector3 goal)
    {
        Quaternion dir = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(goal - transform.position),
            rotateSpeed * Time.deltaTime);

        if(Quaternion.Angle(transform.rotation, Quaternion.LookRotation(goal - transform.position))<0.1f)
            transform.rotation= Quaternion.LookRotation(goal - transform.position);

        Vector3 v = dir.eulerAngles;
        transform.eulerAngles = new Vector3(0, v.y, 0);
    }

    public void EnemyAttack()
    {
        if (enemyLookPlayer.magnitude < attackRange)
        {
            GetComponent<Animation>().enabled = false;
            GetComponent<Animation>().enabled = true;
            if (helpATKTime < Time.time)
            {
                switch (Random.Range(0, 4))
                {
                    case 0: ad.PlayOneShot(audioATK1); break;
                    case 1: ad.PlayOneShot(audioATK2); break;
                    case 2: ad.PlayOneShot(audioATK3); break;
                    case 3: ad.PlayOneShot(audioATK4); break;
                }
                ea.action.PlayQueued(ea.enemyAttack);
                player.GetComponentInParent<playerStatusInformation>().Damage(enemyATK, enemyArmorATK);
                helpATKTime = Time.time + enemyATKintervalTime;
            }
        }
    }
}
