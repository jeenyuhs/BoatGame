using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance; // Singleton instance for global access
    public int maxHealth = 100; // Maximum health value
    public int currentHealth; // Current health value

    void Awake()
    {
        // Setup the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize current health to maximum health at the start of the game
        currentHealth = maxHealth;
    }

    // Method to reduce player's health
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Check if health falls below or equals zero
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver(); // Call the GameOver method when health reaches zero
        }

        Debug.Log("Player Health: " + currentHealth);
    }

    // Method to handle game over state
    void GameOver()
    {
        Debug.Log("Game Over!");
        // Implement further game over logic here, such as stopping the game, showing UI, etc.
    }

    // Optional: Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Ensure health does not exceed maximum health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Player Healed! Current Health: " + currentHealth);
    }
}
