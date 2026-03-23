using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButtonPlayer2 : MonoBehaviour
{
    public static bool isTwoPlayer = false;

    [SerializeField] private Button onePlayerButton;
    [SerializeField] private Button twoPlayerButton;

    void Start()
    {
        onePlayerButton.onClick.AddListener(SetOnePlayer);
        twoPlayerButton.onClick.AddListener(SetTwoPlayer);
    }

    public void SetOnePlayer()
    {
        isTwoPlayer = false;
        SceneManager.LoadScene("Pi Bang");
    }

    public void SetTwoPlayer()
    {
        isTwoPlayer = true;
        SceneManager.LoadScene("Pi Bang");
    }
}