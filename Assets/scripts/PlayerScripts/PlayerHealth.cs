using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 20;
    public int currentHealth;
    bool isDead;
   // bool damaged;
    public ShootingScriptLeft shootleft;
    public  ShootingScriptRight shootRight;
    public  PlayerMovement movement;
    public GameObject player;


     void Awake()
    {
        currentHealth = startingHealth;
    }



    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Death();
            
        }
    }
    public void TakeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;

        if(currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            Death();
        }
    
    }

    void Death()
    {
        isDead = true;
        movement.enabled = false;
        shootleft.enabled = false;
        shootRight.enabled = false;
        Debug.Log("player has died");
        gameObject.SetActive(false);
    }

}
