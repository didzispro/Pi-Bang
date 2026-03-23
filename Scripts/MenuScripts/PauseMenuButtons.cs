using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
