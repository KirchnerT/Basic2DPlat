using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float damage = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Attack();
        }
    }

    void Attack()
    {
        // ATTACK ANAIMATION HERE

        Debug.DrawLine(attackPoint.position - new Vector3(attackRange, 0), attackPoint.position + new Vector3(attackRange, 0), Color.magenta, 55f);

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage all enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInParent<Enemy>().Hit(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
