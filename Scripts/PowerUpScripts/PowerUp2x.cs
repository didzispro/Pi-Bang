using UnityEngine;

public class PowerUp2x : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (playerController != null && !playerController.isGameActive)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            if (ballRb != null)
            {
                
                if (ballRb.velocity.x > 0)
                {
                    GameObject ai = GameObject.Find("Player");

                    if (ai != null)
                    {
                        PlayerSizeManager psm = ai.GetComponent<PlayerSizeManager>();

                        if (psm != null)
                        {
                            psm.StartGlow();
                        }
                        
                    }
                }
                else
                {
                    GameObject ai = GameObject.Find("Ai");
                    if (ai != null)
                    {
                        PlayerSizeManager psm = ai.GetComponent<PlayerSizeManager>();

                        if (psm != null)
                        {
                            
                            psm.StartGlowAi();
                        }

                    }
                }
            }
            
            Destroy(gameObject);
        }
    }
}
