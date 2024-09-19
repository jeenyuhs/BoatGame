using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject deathUI; // Reference to the death UI Canvas

    public bool gameIsOver = false;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            // Show the death UI
            if (deathUI != null)
            {
                deathUI.SetActive(true);
            }

            // Invoke FreezeGame after a delay
            FreezeGame();
        }
    }

    void FreezeGame()
    {
        // Freeze the game by setting time scale to 0
        Time.timeScale = 0f;
    }

    // Method to reset or restart the game
    public void RestartGame()
    {
        // Reset time scale to 1 to unfreeze the game
        Time.timeScale = 1f;
        gameIsOver = false;

        // Deactivate death UI
        if (deathUI != null)
        {
            deathUI.SetActive(false);
        }

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
