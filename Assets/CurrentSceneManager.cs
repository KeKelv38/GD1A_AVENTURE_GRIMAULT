using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public static CurrentSceneManager currentSceneManager;
    
    public bool isPlayerPresentByDefault = false;

    public int crystalsPickedUpInThisSceneCount;

    private void Awake()
    {
        if (currentSceneManager != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de gameOverManager dans la scène");
            return;
        }

        currentSceneManager = this;
    }

    
}
