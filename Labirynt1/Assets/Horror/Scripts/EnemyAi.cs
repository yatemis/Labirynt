using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public NavMeshAgent agent;
    public float detectionRange = 10f;
    public float viewAngle = 60f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    private bool isAttacking = false; // Flaga sprawdzaj?ca, czy trwa atak

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Wymu? odtwarzanie animacji w p?tli
        anim.Play("Zombie Crawl");
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (distanceToPlayer < attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                AttackPlayer();
            }
            else if (!isAttacking && distanceToPlayer < detectionRange && angleToPlayer < viewAngle / 2f)
            {
                agent.SetDestination(player.position);
                anim.SetBool("isMoving", true);
            }
            else if (!isAttacking)
            {
                agent.ResetPath();
                anim.SetBool("isMoving", true);
            }
        }
    }

    void AttackPlayer()
    {
        isAttacking = true; 
        agent.ResetPath(); 
        anim.SetTrigger("Attack"); 
        lastAttackTime = Time.time;

        
        Invoke(nameof(ResumeChase), 1.5f);

        
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }
        }
    }

    void ResumeChase()
    {
        isAttacking = false; 
    }
}
