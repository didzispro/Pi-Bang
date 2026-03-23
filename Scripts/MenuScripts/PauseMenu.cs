using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject pausePanel;

    public bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; 
        
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerController.isGameActive)
        {
            if (isPause)
            {
                ResumeMenu();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ResumeMenu()
    {
        pausePanel.gameObject.SetActive(false);
        isPause = false;
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        isPause = true;
        Time.timeScale = 0.0f;
    }

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
