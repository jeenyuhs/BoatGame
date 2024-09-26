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
        if (scoreText == null)
        {
            scoreTextUI = GameObject.FindWithTag("GameUI");
            scoreTextUI.AddComponent<Text>();

            var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

            scoreText = scoreTextUI.GetComponent<Text>();
            scoreText.font = arial;
            scoreText.fontSize = 24;
            scoreText.alignment = TextAnchor.UpperLeft;
        }

        UpdateGameUI();
    }

    public void CollectTrash()
    {
        // increment score by 1
        score++;
        UpdateGameUI();
    }

    public void UpdateGameUI()
    {
        // sometimes gamemanager updates faster than this gets executed
        // and will then update the timeScale, even when it's supposed to
        // be 0. this fixes it
        if (!GameManager.Instance.gameIsOver)
            Time.timeScale = 1f + (float)Math.Log(Math.Pow(Math.Max(score, 1), 0.4f));

        if (scoreText != null)
        {
            scoreText.text = "Opsamlet plastik: " + score + "\nAntal liv: " + PlayerHealth.Instance.currentHealth;
        }
    }
}
