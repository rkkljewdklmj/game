using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int health = 500;
    public bool isInvulnerable = false;

    public BossHPBar Bossbar; // Reference to the BossHPBar script

    public GameObject deathEffect; // Define the death effect GameObject

    void Start()
    {
        health = maxHealth;
        Bossbar.SetMaxHealth(maxHealth);
        Debug.Log("Boss health initialized to " + health);
    }

    public void TakeDamage(int attackDamage)
    {
        if (isInvulnerable)
        {
            Debug.Log("Boss is invulnerable");
            return;
        }

        health -= attackDamage;
        Debug.Log("Boss health after taking damage: " + health);

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }

        Debug.Log("Boss health after updates: " + health);

        Bossbar.SetHealth(health);
    }

    void Die()
    {
        // Your death logic here
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}