using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance; // Singleton instance for global access
    public int maxHealth = 5; // Maximum health value
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

}
