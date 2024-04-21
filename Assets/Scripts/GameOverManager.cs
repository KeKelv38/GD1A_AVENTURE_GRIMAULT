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
        if (CurrentSceneManager.currentSceneManager.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.dontDestroyOnLoadScene.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }

    public void retryButton()
    {
        Inventory.inventory.RemoveCrystals(CurrentSceneManager.currentSceneManager.crystalsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.playerHealth.Respawn();
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
