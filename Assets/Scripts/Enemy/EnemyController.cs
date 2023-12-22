using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MeleeAttack
{
    [SerializeField] private Animator animator;

    [SerializeField] private List<Transform> patrolPoints;
    private int currentPatrolIndex = 0;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private float distanceToPlayer;

    private GameObject player;

    [SerializeField] private float speedRunToPlayer;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        SetNextDestination();
    }

    private void SetNextDestination()
    {
        if (patrolPoints.Count > 0)
        {
            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    private void GoingToPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.speed = speedRunToPlayer;
        animator.SetBool("Walking", true);
    }

    private void FixedUpdate()
    { 
        float distancePlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(distancePlayer < distanceToPlayer)
        {
            GoingToPlayer();
            if (distancePlayer <= attackRange) 
            {
                Attack();
                animator.SetBool("Attack", true);
                navMeshAgent.speed = 0;
                StartCoroutine(EndAnimationAttack());
            }
        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            SetNextDestination();
        }

    }

    private IEnumerator EndAnimationAttack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Attack", false);
    }
}
