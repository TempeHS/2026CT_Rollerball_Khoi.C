using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public int publicCount;
    public Transform player;

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
    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
            speed = 2.5 + (publicCount / 5);
            enemySpeed = (float)speed;
            Debug.Log("Speed: " + speed);
            Debug.Log("Enemy Speed: " + enemySpeed);
            navMeshAgent.speed = enemySpeed;
        }
    }
}
