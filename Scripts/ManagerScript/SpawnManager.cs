using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private GameObject ballPrefabs;
    [SerializeField] private GameObject powerUpMultiplyerPrefabs;
    [SerializeField] private GameObject powerUpMultiple2x;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        SpawnBallPosition();

        InvokeRepeating("RepeatSpawnPowerUp", 5.0f, 20.0f);
        InvokeRepeating("RepeatSpawnPowerUp2x", 10.0f, 30.0f);
    }

    // Spawn the ball in the same position.
    public void SpawnBallPosition()
    {
        if (playerController.isGameActive)
        {
            transform.position = new Vector2(0, 0);
            
            Instantiate(ballPrefabs, transform.position, Quaternion.identity); 
        }      
    }

    public void RepeatSpawnPowerUp()
    {
        float randomPositionY = Random.Range(-2.91f, 2.91f);
        float randomPositionX = Random.Range(-4.55f, 1.66f);

        Vector2 randomPosition = new Vector2(randomPositionX, randomPositionY);

        Instantiate(powerUpMultiplyerPrefabs, randomPosition, Quaternion.identity);
    }

    public void RepeatSpawnPowerUp2x()
    {
        float randomPositionX = Random.Range(-1.84f, 1.71f);
        float randomPositionY = Random.Range(-2.91f, 2.91f);
        
        Vector2 randomPosition = new Vector2(randomPositionX, randomPositionY);

        Instantiate(powerUpMultiple2x, randomPosition, Quaternion.identity);
    }
}
