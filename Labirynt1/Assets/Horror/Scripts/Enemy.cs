using UnityEngine;
using UnityEngine.AI;
using System.Collections; // Dodaj to!

public class Enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float detectionRange = 10f; // Zasi?g wykrywania gracza
    public float attackRange = 1.5f; // Zasi?g ataku
    public int damage = 10; // Ilo?? obra?e? zadawanych graczowi
    private bool isAttacking = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            if (agent.isOnNavMesh)
            {
                agent.ResetPath();
            }
        }

        if (distanceToPlayer < attackRange && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        yield return new WaitForSeconds(1.5f); // Przeciwnik atakuje co 1.5 sekundy
        isAttacking = false;
    }
}
