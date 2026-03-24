using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public Transform player;
    public TextMeshProUGUI enemySpeedText;
    public Material opaque;
    public Material transparent;

    private int count;
    private int stunActive;
    private NavMeshAgent navMeshAgent;
    private double speed;
    private float enemySpeed = 2.5f;
    private Renderer objectRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        objectRenderer = GetComponent<Renderer>();
        navMeshAgent.speed = enemySpeed;
    }

    void Update()
    {
        if (player != null)
        {
            stunActive = playerControllerReference.stunActive;
            if (stunActive > 0)
            {
                if (stunActive % 2 = 0)
                {
                    objectRenderer.material = opaque;
                } else {
                    objectRenderer.material = transparent;
                }
            } else {
                objectRenderer.material = opaque;
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
