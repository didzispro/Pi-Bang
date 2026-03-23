using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public static float ballSpeed = 10.0f;
    public static float playerSpeed = 10.0f;
    public static float aiSpeed = 10.0f;
    public static bool isTwoPlayer = false;

    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;

    // Start is called before the first frame update
    void Start()
    {
        easyButton.onClick.AddListener(EasyDifficulty);
        mediumButton.onClick.AddListener(MediumDifficulty);
        hardButton.onClick.AddListener(HardDifficulty);
    }

    public void EasyDifficulty()
    {
        aiSpeed = 5.0f;
        playerSpeed = 5.0f;
        ballSpeed = 5.0f;
    }

    public void MediumDifficulty()
    {
        aiSpeed = 10.0f;
        playerSpeed = 10.0f;
        ballSpeed = 10.0f;
    }

    public void HardDifficulty()
    {
        aiSpeed = 15.0f;
        playerSpeed = 15.0f;
        ballSpeed = 15.0f;
    }

    public void SetOnePlayer()
    {
        isTwoPlayer = false;
    }

    public void SetTwoPlayer()
    {
        isTwoPlayer = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Play As");
    }
}
