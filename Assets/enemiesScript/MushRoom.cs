using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MushRoom : MonoBehaviour
{

    public static MushRoom instance;
    public Transform target;
    public Animator enemyAni;

    public float coolDown = 2f;
    float attackDelay = 0;

    public AIPath aipath;

    public int damage = 10;

    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<takeDamageMushRoom>().isDead == false)
        {
            if (Vector2.Distance(this.transform.position, target.position) >= 10f)
            {
                aipath.enabled = false;
                enemyAni.SetFloat("speed", -1f);
            }
            else if (Vector2.Distance(this.transform.position, target.position) < 10f)
            {
                aipath.enabled = true;
                enemyAni.SetFloat("speed", 1f);
            }

            Attack();

        }

        if (GetComponent<takeDamageMushRoom>().isDead)
        {
            aipath.enabled = false;
        }



    }

    public void Attack()
    {
        if (Vector2.Distance(this.transform.position, target.position) <= 2f)
        {
            enemyAni.SetFloat("speed", -1f);
            if (attackDelay < coolDown)
            {
                enemyAni.SetBool("isAttack", false);
                attackDelay += Time.time;
            }
            else if (attackDelay >= coolDown)
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
        }
    }

}
