using System;
using UnityEngine;
using UnityEngine.UI; // Include this for UI components

public class TrashCollector : MonoBehaviour
{
    public static TrashCollector Instance; // Singleton instance for easy access
    public int score = 0; // Player's score
    private GameObject scoreTextUI;
    private Text scoreText; // Reference to the UI Text component

    void Awake()
    {
        // Singleton pattern to ensure only one instance of TrashCollector exists
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
        // Initialize the score display
        if (scoreText == null) {
            scoreTextUI = GameObject.FindWithTag("Nigga");
            scoreTextUI.AddComponent<Text>();

            var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

            scoreText = scoreTextUI.GetComponent<Text>();
            scoreText.font = arial;
            scoreText.fontSize = 24;
            scoreText.alignment = TextAnchor.UpperLeft;
        }

        UpdateScoreUI();
    }

    // Method to handle trash collection
    public void CollectTrash()
    {
        score += 1; // Increase score for each piece of trash collected
        UpdateScoreUI(); // Update the UI when score changes
        Debug.Log("Trash Collected! Score: " + score);
    }

    // Method to update the score on the UI
    public void UpdateScoreUI()
    {
        Time.timeScale = 1f + (float)Math.Log(Math.Pow(score, 0.4f));

        if (scoreText != null)
        {
            Debug.Log("updating score to " + score);
            scoreText.text = "Opsamlet plastik: " + score; // Set the text of the score UI
        }
    }
}
