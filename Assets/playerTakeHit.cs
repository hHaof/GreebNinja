using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTakeHit : MonoBehaviour
{

    public playerHealthBar healthBar;
    public Animator playerAni;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealthBar(maxHealth);
    }

    void Update(){

        

    }

    // Update is called once per frame
    public void takeHit(int dmg){
        currentHealth -= dmg;
        healthBar.SetHealthBar(currentHealth);
        playerAni.SetTrigger("isHurt");

        if(currentHealth <= 0){
            Die();
        }

    }

    void Die(){
        Debug.Log("your dead");
    }
}
