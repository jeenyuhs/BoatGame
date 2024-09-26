using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Speed of the player's movement
    public float boundary = 12f; // Limit for left and right movement
    private float smooth = 3.0f;
    private float tiltAngle = 35.0f;

    void Update()
    {
        // get horizontal input (Left/Right or A/D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate the new position using vector3
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        // clamp the position to stay within screen boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        // apply the new position
        transform.position = newPosition;

        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

        // rotate the boat by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

        // check if the gamemanager says we have to reset boat position.
        if (GameManager.Instance.shouldResetBoatPosition) {
            transform.position = new Vector3(0, 0, 0);
            GameManager.Instance.shouldResetBoatPosition = false;
        }

        // Check if the player "dies"
        OnDeath();

        // testing feature
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Game Over triggered by debug key!");
            SetGameOver();
        }
    }

    void OnDeath()
    {
        // Check if the player's score is less than 0 or the player health is 0, indicating death condition
        if ((TrashCollector.Instance.score < 0 || PlayerHealth.Instance.currentHealth <= 0) && !GameManager.Instance.gameIsOver)
        {
            // Trigger the game over sequence in GameManager
            GameManager.Instance.GameOver();
        }
    }


    void SetGameOver()
    {
        if (!GameManager.Instance.gameIsOver)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ResetPosition() {
        transform.position = new Vector3(0, 0, 0);
    }
}
