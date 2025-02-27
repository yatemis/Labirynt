using UnityEngine;
using UnityEngine.AI;
using System.Collections; // Dodane dla IEnumerator

public class EnemyAI2 : MonoBehaviour
{
    public Transform player;
    public float speed = 3.5f;
    public float damage = 10f;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool canAttack = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);

            // Je?li wróg si? porusza, odtwarzamy animacj? biegu
            animator.SetBool("isRunning", agent.velocity.magnitude > 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage((int)damage); // RZUTOWANIE float ? int
                StartCoroutine(AttackCooldown());
            }

            animator.SetTrigger("Attack");
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
