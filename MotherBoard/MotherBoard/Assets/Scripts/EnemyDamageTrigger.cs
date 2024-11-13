using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f;
    private bool canAttack = true;

    // Método que se llama cuando un objeto entra en el Trigger del enemigo
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                StartCoroutine(AttackCooldown());
            }
        }
    }

    // Control del tiempo entre ataques
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
