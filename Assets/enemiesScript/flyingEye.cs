using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEye : MonoBehaviour
{
    public static flyingEye instance;
    public Transform target;
    public Animator enemyAni;

    public float coolDown = 1f;
    float attackDelay = 0f;

    public int damage = 10;




    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<takeDamage>().isDead == false)
        {
            Attack();

        }


    }

    public void Attack()
    {
        if (Vector2.Distance(this.transform.position, target.position) <= 2f)
        {
            if (attackDelay < coolDown)
            {
                enemyAni.SetBool("isAttack", false);
                attackDelay += Time.time;
            }
            else if (attackDelay > coolDown)
            {
                enemyAni.SetBool("isAttack", true);
                attackDelay = 0;
            }

        }
        else if (Vector2.Distance(this.transform.position, target.position) > 2)
        {
            enemyAni.SetBool("isAttack", false);
        }
    }

    public void DealDmg()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(GetComponent<lookAtPlayer>().attackPoint.position, GetComponent<lookAtPlayer>().attackRange, GetComponent<lookAtPlayer>().playerLayer);
        foreach (Collider2D player in hitPlayer)
        { 
            player.GetComponent<playerTakeHit>().takeHit(damage);
            Debug.Log("WE HIT PLAYER!!!!");
        }
    }
}
