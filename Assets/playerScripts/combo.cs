using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combo : MonoBehaviour
{

    public Animator playerAni;
    public Transform attackPoint;
    public bool isAttacking = false;
    public static combo instance;
    public float attackRange = .5f;

    public int damage = 20;

    public LayerMask enemiesLayer;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerAni = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        isAttacking = true;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.name == "Flying Eye(Clone)"){
                enemy.GetComponent<takeDamage>().beingHit(damage);
            }
            if(enemy.name == "Goblin(Clone)"){
                enemy.GetComponent<takeDamageGoblin>().beingHit(damage);
            }
            if(enemy.name == "Mush Room(Clone)"){
                enemy.GetComponent<takeDamageMushRoom>().beingHit(damage);
            }
            if(enemy.name == "Skeleton(Clone)"){
                enemy.GetComponent<takeDamageSkeleton>().beingHit(damage);
            }
            

        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}