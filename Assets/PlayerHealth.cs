using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int health;
    public Animator animator;
    public HealthBar healthBar;
    public GameObject deathEffect;
    public float regenerationRate = 5.0f;
    public int regenerationAmount = 10;
    public Transform respawnPoint; // Assign the respawn point in the Inspector

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        if (health > 0 && health < maxHealth)
        {
            Regenerate();
        }
    }

    void Regenerate()
    {
        float healthToRegen = regenerationRate * Time.deltaTime;
        health = Mathf.Min(health + (int)healthToRegen, maxHealth);
        healthBar.SetHealth(health);
    }

    void Die()
    {
        Debug.Log("Player died");
        animator.SetBool("IsDead", true);

        // Play death effect and perform respawn
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Respawn the player at the "Respawn" point
        Respawn();
    }

    void Respawn()
    {
        // Reset player position to the "Respawn" point
        transform.position = respawnPoint.position;

        // Restore full health
        health = maxHealth;
        healthBar.SetHealth(health);

        // Revive the player
        animator.SetBool("IsDead", false);
    }
}