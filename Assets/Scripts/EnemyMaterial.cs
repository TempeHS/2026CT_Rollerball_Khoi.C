using UnityEngine;

public class EnemyMaterial : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public Material opaque;
    public Material transparent;
    private Renderer objectRenderer;

    private int stunTimer = 0;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        stunTimer = playerControllerReference.stunActive;
        if (stunTimer > 0)
        {
            if (stunTimer%2 == 0)
            {
                objectRenderer.material = transparent;
            } else {
                objectRenderer.material = opaque;
            }
        }
    }
}
