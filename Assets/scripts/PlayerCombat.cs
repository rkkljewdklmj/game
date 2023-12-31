using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int enemyAttackDamage = 40;
    public int bossAttackDamage = 20; // Adjust the boss's damage as needed
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(enemyAttackDamage);
                }
            }
        }

        // You can find the boss by tag and check if it has the "BossHealth" script
        GameObject boss = GameObject.FindWithTag("Boss");
        if (boss != null)
        {
            BossHealth bossHealth = boss.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(bossAttackDamage);
            }
        }
    }
}