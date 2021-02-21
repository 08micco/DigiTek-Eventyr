using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/// <summary>
/// Sætter ulven i to forskellige stadier.
/// Den kan enten patruljere eller jagte spilleren.
/// Hvis fjenden kommer for tæt på spilleren, dør spilleren.
/// </summary>

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    private GameObject playerObj;
    
    public LayerMask whatIsGround, whatIsPlayer;

    private int WalkSpeed = 3;
    private int RunSpeed = 6;

    public bool isRunning;
    private Animator wolfAnimator;

    // Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private AudioSource growl;

    private void Awake()
    {
        playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        agent = GetComponent<NavMeshAgent>();
        wolfAnimator = gameObject.GetComponent<Animator>();
        if (gameObject.name == "EndEnemy") RunSpeed = 4;
        growl = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(WolfGrowl());
    }

    private void Update()
    {
        // Tjekker om spilleren er indenfor SightRange og AttackRange ved at måle afstanden mellem spiller og fjende
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        // Hvis spilleren er udenfor SightRange er fjenden sat til at patruljere
        if (!playerInSightRange) Patrolling();
        
        // Hvis spilleren er indenfor SightRange er fjenden sat til at jagte
        if (playerInSightRange) ChasePlayer();
    }

    private IEnumerator WolfGrowl()
    {
        while (true)
        {
            var randomNum = Random.Range(3, 5);
            yield return new WaitForSeconds(randomNum);
            growl.Play();
        }
    }
    
    private void Patrolling()
    {
        // Hvis fjenden patruljere, går den med WalkSpeed og spiller gå-animationen
        agent.speed = WalkSpeed;
        isRunning = false;
        wolfAnimator.SetBool("isRunning", isRunning);
        // Hvis fjende ikke har et sted at gå, får den et nyt punkt at gå til
        if (!walkPointSet) SearchWalkPoint();

        // Går efter walkPoint
        if (walkPointSet) agent.SetDestination((walkPoint));

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        // Hvis walkPoint bliver nået
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Tilfældigt punkt findes
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Hvis det fundne punkt er et sted, som fjenden kan gå hen til bliver walkPointSet til true
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }
    
    private void ChasePlayer()
    {
        // Sætter fjenden til at løbe med hastighed og animation
        agent.speed = RunSpeed;
        isRunning = true;
        wolfAnimator.SetBool("isRunning", isRunning);
        // Hvis ulven er indenfor AttackRange dør man
        if (playerInAttackRange) OnDeath();
        // Løber efter spilleren
        agent.SetDestination(player.position);
        //transform.LookAt(player);    
    }


    private void OnDeath()
    {
        // Roterer spilleren 90 grader for at man ligger ned
        player.Rotate(90, 0, 0, Space.World);
        // Kan ikke kigge rundt eller bevæge sig
        gameObject.GetComponent<EnemyAI>().enabled = false;
        playerObj.GetComponent<PlayerMovement>().enabled = false;
        playerObj.GetComponentInChildren<PlayerLook>().enabled = false;
    }
}
