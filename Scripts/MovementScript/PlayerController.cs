using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    public float xMaxPlayerRange = 5.0f;

    public bool isGameActive = true;

    public float moveSpeed = 10.0f;

    public float yMaxPlayerRange = 2.89f;
    private float xPositionPlayer = -9.56f;
    

    // Start is called before the first frame update.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = DifficultyButton.playerSpeed;
    }

    // Update is called once per frame.
    private void Update()
    {
        Movement();
        InvisiblePlayerBlockWall();
    }

    // Moving the player up and down using arrows!
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) && isGameActive)
        {
            rb.velocity = new Vector2(0, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S) && isGameActive)
        {
            rb.velocity = new Vector2(0, -moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    // Keeps the invisible block wall for the y positions for the player not to go through.
    private void InvisiblePlayerBlockWall()
    {
        if (transform.position.y >= yMaxPlayerRange)
        {
            rb.position = new Vector2(xPositionPlayer, yMaxPlayerRange);

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if (transform.position.y <= -yMaxPlayerRange)
        {
            rb.position = new Vector2(xPositionPlayer, -yMaxPlayerRange);

            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
    }
}
