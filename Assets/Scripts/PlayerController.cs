using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Speed of the player's movement
    public float boundary = 7f; // Limit for left and right movement
    public GameObject deathEffectPrefab; // Reference to the particle effect prefab

    void Update()
    {
        // Get horizontal input (Left/Right or A/D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Clamp the position to stay within screen boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        // Apply the new position
        transform.position = newPosition;

        // Check if player "dies"
        OnDeath();
    }

    void OnDeath()
    {
        // Check if the player's score is less than 0, indicating death condition
        if (TrashCollector.Instance.score < 0 && !GameManager.Instance.gameIsOver)
        {
            // Instantiate the death particle effect at the player's position
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            }

            // Trigger the game over sequence in GameManager
            GameManager.Instance.GameOver();
        }
    }
}
