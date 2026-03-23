using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public bool isOriginalBall = true;

    private PlayerController playerController;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    private Rigidbody2D rb;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip wallHitSound;
    private ParticleSystem hitParticle;

    private CameraShake cameraShake;
    

    private AudioSource audioSource;

    private int increaseScore = 1;

    public float moveSpeed = 10.0f;
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Gives a component of a script, finding a gameobject to get the component of that script and Spawns a ball in a random range between left and right.
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * moveSpeed;


        cameraShake = Camera.main.GetComponent<CameraShake>();

        hitParticle = GameObject.Find("HitParticles").GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        audioSource = GetComponent<AudioSource>();

        moveSpeed = DifficultyButton.ballSpeed;


        RandomBallSpawn();  
    }

    // Spawns a ball in a random range between left and right.
    private void RandomBallSpawn()
    {
        if (Random.Range(0, 2) == 0)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
    }

    // When it's triggered it updates the score, destorys the ball and Spawns a ball in a random range between left and right.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeletionInvisibleBlockWallRight") && playerController.isGameActive)
        {
            gameManager.LeftText0(increaseScore);
            Destroy(gameObject); 

            if (isOriginalBall)
            {
                spawnManager.SpawnBallPosition();
            }
            
        }
        else if (other.gameObject.CompareTag("DeletionInvisibleBlockWallLeft") && playerController.isGameActive)
        {
            gameManager.RightText0(increaseScore);
            Destroy(gameObject);

            if (isOriginalBall)
            {
                spawnManager.SpawnBallPosition();
            }
        } 
    }

    // Collisions the ball and keeping the same speed when hitting the ground or collsions.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = rb.velocity.normalized * moveSpeed;

        hitParticle.transform.position = transform.position;
        hitParticle.Play();

        // Checks if player or ai is hit. If it is then increases speed. If not then keeps the same speed!
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ai"))
        {
            moveSpeed++;
            cameraShake.Shake(0.1f, 0.1f);
            audioSource.PlayOneShot(hitSound, 1.0f);
        }

        if (collision.gameObject.CompareTag("Walls"))
        {
            cameraShake.Shake(0.2f, 0.2f);   
            audioSource.PlayOneShot(wallHitSound, 1.0f);
        }
    }
}
