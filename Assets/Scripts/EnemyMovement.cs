using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public Transform player;
    public TextMeshProUGUI enemySpeedText;

    private int count;
    private int stunTimer = 0;
    private NavMeshAgent navMeshAgent;
    private double speed;
    private float enemySpeed = 2.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
    }

    void Update()
    {
        if (player != null)
        {
            stunTimer = playerControllerReference.stunActive;
            Debug.Log(stunTimer);
            if (stunTimer == 0)
            {
                navMeshAgent.SetDestination(player.position);
                count = playerControllerReference.publicCount;
                speed = 2.5 + ((double)count / 8);
                enemySpeed = (float)speed;
                enemySpeedText.text = "Enemy Speed: " + speed.ToString();
                navMeshAgent.speed = enemySpeed;
            }
        }
    }
}
