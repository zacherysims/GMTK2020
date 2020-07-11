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
    [HideInInspector]
    public int score;

    public Slider confidenceSlider;

    private void Start()
    {
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
        Destroy(player.gameObject);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(UnityEngine.Random.Range(0, SceneManager.sceneCount));
    }
}
