using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class lookAtPlayer : MonoBehaviour
{

    public Transform attackPoint;
    public AIPath aipath;

    public float attackRange = .5f;

    public LayerMask playerLayer;



    void Update()
    {

        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(4f, 4f, 1f);

        }
        else if (aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }

    }

    void FixedUpdate()
    {
        if (transform.localScale.x == 4f)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x + 1.2f, this.transform.position.y);
        }
        else if (transform.localScale.x == -4f)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x - 1.2f, this.transform.position.y);
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
