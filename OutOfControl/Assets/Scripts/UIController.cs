using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Transform player;
    public GameObject gameOverPanel;

    public Text scoreText;
    public Text highScoreText;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highScore;

    public Slider confidenceSlider;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore.ToString();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += (int)(1 / confidenceSlider.value * points);
        confidenceSlider.value += 0.1f;
    }

    public void DecreaseConfidence()
    {
        confidenceSlider.value -= 0.25f;
        if (confidenceSlider.value <= 0f)
            GameOver();
    }

    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            highScoreText.text = "High Score: " + score.ToString();
            PlayerPrefs.SetInt("HighScore", score);
        }

        Destroy(player.gameObject);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(UnityEngine.Random.Range(0, SceneManager.sceneCount));
    }
}
