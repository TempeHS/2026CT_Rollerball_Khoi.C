using UnityEngine;

public class Bobber : MonoBehaviour
{
    private float bobHeight = 0.2f;
    private float bobSpeed = 4f;
    private Vector3 startPos;
    private float newY;
    private float distanceY;

    void Start() {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        distanceY = Mathf.Sin(Time.time * bobSpeed);
        newY = startPos.y + (distanceY * bobHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
