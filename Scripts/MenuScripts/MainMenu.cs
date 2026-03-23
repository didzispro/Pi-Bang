using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Pi Bang");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }

    public void PlayGameDifficulty()
    {
        SceneManager.LoadScene("Difficulty Scene");
    }
}
