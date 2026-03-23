using UnityEngine;

public class Ai : MonoBehaviour
{
    private PlayerController playerController;

    private Rigidbody2D rb;

    public float moveSpeed = 10.0f;

    public float yMaxAiRange = 2.94f;
    private float xPositionAi = 5.15f;

    // Start is called before the first frame update.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        moveSpeed = DifficultyButton.aiSpeed;
    }

    // Update is called once per frame.
    private void Update()
    { 
        InvisibleAiBlockWall();

        if (DifficultyButtonPlayer2.isTwoPlayer)
        {
            return;  
        }
        
        AiFollow();
    }

    // Keeps the invisible block wall for the y positions for the ai not to go through.
    private void InvisibleAiBlockWall()
    {
        if (transform.position.y >= yMaxAiRange)
        {
            transform.position = new Vector2(xPositionAi, yMaxAiRange);
        }
        else if (transform.position.y <= -yMaxAiRange )
        {
            transform.position = new Vector2(xPositionAi, -yMaxAiRange);
        }
    }

    // Ai follows the balls positions and predicts balls positions.
    private void AiFollow()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball != null && playerController.isGameActive)
        {
            if (ball.transform.position.y > transform.position.y + 0.3f)
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }
            else if (ball.transform.position.y < transform.position.y - 0.3f)
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
