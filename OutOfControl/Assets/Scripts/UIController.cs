using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform Player;
    public GameObject floatingPoints;

    public Text scoreText;
    [HideInInspector]
    public int score;

    public Slider confidenceSlider;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += (int)(1 / confidenceSlider.value * points);
        floatingPoints.GetComponentInChildren<TextMesh>().text = "+" + (int)(1 / confidenceSlider.value * points);
        Instantiate(floatingPoints, new Vector3(-7f,5f), Quaternion.identity);
        confidenceSlider.value += 0.1f;
    }

    public void DecreaseConfidence()
    {
        confidenceSlider.value -= 0.25f;
    }
}
