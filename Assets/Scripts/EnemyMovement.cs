using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public Transform player;
    private int count;

    private NavMeshAgent navMeshAgent;
    private double speed;
    private float enemySpeed = 2.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
    }

    // Update is called once per frame
    void Awake()
    {
        playerControllerReference = GetComponent
    }

    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
            Debug.Log("Count: " + playerControllerReference.publicCount);
            navMeshAgent.speed = enemySpeed;
        }
    }
}
