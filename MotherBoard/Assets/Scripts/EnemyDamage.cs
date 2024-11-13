using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f; // Cantidad de daño que inflige el enemigo
    public float attackCooldown = 1f; // Tiempo entre ataques
    private bool canAttack = true; // Controlar si el enemigo puede atacar

    // Método que se llama cuando el enemigo colisiona con otro objeto
    void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            // Obtener el script PlayerHealth del jugador
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Infligir daño al jugador
                playerHealth.TakeDamage(damage);
                StartCoroutine(AttackCooldown());
            }
        }
    }

    // Controlar el tiempo de espera entre ataques
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
