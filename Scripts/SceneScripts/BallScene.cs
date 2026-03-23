using UnityEngine;

public class BallScene : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip ballhit;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            audioSource.PlayOneShot(ballhit, 1.0f);
        }
    }
}
