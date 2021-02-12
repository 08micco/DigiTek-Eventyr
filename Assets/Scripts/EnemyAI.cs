using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    private GameObject playerObj;
    
    public LayerMask whatIsGround, whatIsPlayer;

    private const int WalkSpeed = 3;
    private const int RunSpeed = 6;

    public bool isRunning;
    private Animator wolfAnimator;

    // Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        agent = GetComponent<NavMeshAgent>();
        wolfAnimator = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        

        if (!playerInSightRange) Patrolling();
        if (playerInSightRange) ChasePlayer();
        print(wolfAnimator.GetBool("isRunning"));
    }

    private void Patrolling()
    {
        agent.speed = WalkSpeed;
        isRunning = false;
        wolfAnimator.SetBool("isRunning", isRunning);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination((walkPoint));

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }
    
    private void ChasePlayer()
    {
        agent.speed = RunSpeed;
        isRunning = true;
        wolfAnimator.SetBool("isRunning", isRunning);
        if (playerInAttackRange) OnDeath();
        agent.SetDestination(player.position);
        //transform.LookAt(player);    
    }


    private void OnDeath()
    {
        player.Rotate(90, 0, 0, Space.World);
        // Kan ikke kigge rundt eller bevæge sig
        gameObject.GetComponent<EnemyAI>().enabled = false;
        playerObj.GetComponent<PlayerMovement>().enabled = false;
        playerObj.GetComponentInChildren<PlayerLook>().enabled = false;
    }
}
