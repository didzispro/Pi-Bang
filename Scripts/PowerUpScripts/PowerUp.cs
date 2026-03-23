using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private GameObject ballPrefabs;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.isGameActive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball hit power-up!");

            Vector2 ballPosition = collision.transform.position;

            for (int i = 0; i < 2; i++)
            {
                GameObject newBall = Instantiate(ballPrefabs, ballPosition, Quaternion.identity);
                Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
                rb.velocity = Random.insideUnitCircle.normalized * 10.0f;
                newBall.GetComponent<BallMovement>().isOriginalBall = false;

                Destroy(newBall, 5.0f);
            }

            Destroy(gameObject);
        }

        
    }
    
}
