using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private SpawnManager spawnManager;

    [SerializeField] private TextMeshProUGUI leftText0;
    [SerializeField] private TextMeshProUGUI rightText0;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI youWinText;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private TextMeshProUGUI restartText;

    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip losingSound;

    private AudioSource audioSource;

    public int playerScore;
    public int aiScore;

    private int winningScore = 10;
    private int lossingScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        audioSource = GetComponent<AudioSource>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update the score on LeftText0 when player scores.
    public void LeftText0(int leftStoreNumbers)
    {
        playerScore += leftStoreNumbers;
        leftText0.text = "" + playerScore;

        if (playerScore == winningScore)
        {
            playerController.isGameActive = false;

            youWinText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);

            spawnManager.CancelInvoke("RepeatSpawnPowerUp");
            spawnManager.CancelInvoke("RepeatSpawnPowerUp2x");

            audioSource.PlayOneShot(winSound, 1.0f);

            if (DifficultyButtonPlayer2.isTwoPlayer)
            {
                gameOverText.text = "Player 1 Wins!";
            }
            else
            {
                gameOverText.text = "You Win!";
            }
        }
    }

    // Update the score on RightText0 when ai scores.
    public void RightText0(int rightStoreNumbers)
    {
        aiScore += rightStoreNumbers;
        rightText0.text = "" + aiScore.ToString();

        if (aiScore == lossingScore)
        {
            playerController.isGameActive = false;

            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            audioSource.PlayOneShot(losingSound, 1.0f);

            spawnManager.CancelInvoke("RepeatSpawnPowerUp");
            spawnManager.CancelInvoke("RepeatSpawnPowerUp2x");

            if (DifficultyButtonPlayer2.isTwoPlayer)
            {
                gameOverText.text = "Player 2 Wins!";
            }
            else
            {
                gameOverText.text = "Game Over!";
            }
        }
    }

    // Restart back to the original scene.
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        playerController.isGameActive = false;
        youWinText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    
        audioSource.PlayOneShot(winSound, 1.0f);
    }

}
