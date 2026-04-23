using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI stunsText;
    public GameObject winTextObject;
    public GameObject darkenedBG;
    public int publicCount;
    public int stunActive = 0;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int maxCount = 20;
    private float stuns = 0;
    private bool gamePaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        countText.text = "";
        stunsText.text = "";
        winTextObject.SetActive(false);
        darkenedBG.SetActive(false);
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        SetStunsText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Collected: " + count.ToString() + "/" + maxCount;
        if (count >= maxCount)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }
    void SetStunsText()
    {
        stunsText.text = "Stuns: " + stuns.ToString();
    }

    void FixedUpdate()
    {
        if(gamePaused == false) 
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            rb.AddForce(movement * speed);
        }
    }

    async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (stuns > 0)
            {
                stuns = stuns - 1;
                SetStunsText();
                stunActive = 10;
                while (stunActive > 0) 
                {
                    await Task.Delay(System.TimeSpan.FromSeconds(0.5));
                    stunActive = stunActive - 1;
                }
            } else {
                Destroy(gameObject); 
 
                winTextObject.gameObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            publicCount = count;
            SetCountText();
        }
        if(other.gameObject.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            stuns = stuns + 1;
            SetStunsText();
        }
    }
}
