using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public Animator animator;
    public HealthBar healthBar;
    public GameObject deathEffect;
	
	
	
   
    
    void Start()
    {
       health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
      health -= damage;
     
      healthBar.SetHealth(health);
      
      if(health <= 0)
      {
         if(gameObject != null)
         {
          Destroy(gameObject);
          // reload game
         }
      }
    }
   
   


   
    
    void Die()
    {
        Debug.Log("you died");

        animator.SetBool("IsDead", true);

       

    }

}
