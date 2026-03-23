using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private PlayerController playerController;

    private float moveSpeed = 10.0f;
    private Rigidbody2D rb;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = DifficultyButton.playerSpeed;
    }

    void Update()
    {
        if (DifficultyButtonPlayer2.isTwoPlayer)
        {
            if (Input.GetKey(KeyCode.UpArrow) && playerController.isGameActive)
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }  
            else if (Input.GetKey(KeyCode.DownArrow) && playerController.isGameActive)
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }  
            else
            {
                rb.velocity = new Vector2(0, 0);
            }      
        }
    }
}