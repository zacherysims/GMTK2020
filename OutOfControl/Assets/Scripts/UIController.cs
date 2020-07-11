using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform Player;

    public Text scoreText;
    public int score;

    public Slider confidenceSlider;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += (int)(1 / confidenceSlider.value * 100);
        confidenceSlider.value += 0.1f;
    }

    public void DecreaseConfidence()
    {
        confidenceSlider.value -= 0.25f;
    }
}
