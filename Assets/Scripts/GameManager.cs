using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject deathUI;

    public bool shouldResetBoatPosition = false;

    private bool _gameIsOver = false; 
    
    public bool gameIsOver
    {
        get { return _gameIsOver; }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        // freeze the game, when it's game over.
        Time.timeScale = 0.0f;
        
        _gameIsOver = true; // set the game over state
        
        // activate the deathUI if it's initialized.
        if (deathUI != null) {
            deathUI.SetActive(true);
        }

    }

    public void RestartGame()
    {
        // if the game is not over, do not do anything.
        if (!_gameIsOver)
            return;

        // deactivate the deathUI if it's initalized
        if (deathUI != null)
        {
            deathUI.SetActive(false); // Hide Death UI
        }

        // reset all player life and collected trash
        TrashCollector.Instance.score = 0;
        PlayerHealth.Instance.currentHealth = PlayerHealth.Instance.maxHealth;
        TrashCollector.Instance.UpdateGameUI(); // update
        
        // reset the game speed, when the player restarts the game.
        Time.timeScale = 1.0f;

        // expose shouldResetBoatPosition to true, so the Update() function
        // to check if the boat position should be centered again.
        shouldResetBoatPosition = true;

        // find all game objects with hazard and trash tags.
        var hazardObjects = GameObject.FindGameObjectsWithTag("Hazard");
        var trashObjects = GameObject.FindGameObjectsWithTag("Trash");

        // loop through all hazards and destroy them.
        foreach (GameObject hazard in hazardObjects) {
            Destroy(hazard);
        }

        // loop through all trash and destroy them.
        foreach (GameObject trash in trashObjects) {
            Destroy(trash);
        }

        _gameIsOver = false; // reset the game over state for the next game
    }
}
