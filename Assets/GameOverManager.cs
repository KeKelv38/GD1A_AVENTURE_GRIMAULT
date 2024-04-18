using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager gameOverManager;

    private void Awake()
    {
        if (gameOverManager != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de gameOverManager dans la scène");
            return;
        }

        gameOverManager = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }

    public void menuButton()
    {

    }

    public void quitButton()
    {
        Application.Quit();
    }


}
