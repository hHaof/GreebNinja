using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class takeDamageMushRoom : MonoBehaviour
{


    public healthBar healthBar;
    public static takeDamageMushRoom instance;

    public int maxHealth = 100;
    int currentHealth;

    public Animator enemyAni;
    public bool isHurt = false;
    public bool isDead = false;
    public AIPath aipath;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealthBar(maxHealth);
    }


    public void beingHit(int dmg)
    {
        isHurt = true;
        currentHealth = currentHealth - dmg;
        healthBar.SetHealthBar(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {

        enemyAni.SetBool("isDead", true);
        isDead = true;
        aipath.enabled = false;
       if (gameObject != null)
        {
            Destroy(gameObject, 3f);
        }
    }
}
