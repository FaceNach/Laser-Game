using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private HealthScript PlayerHealth;

    [Header("Score")] 
    [SerializeField] private TextMeshProUGUI ScoreText;
    private ScoreKeeper ScoreKeeper;

    void Awake()
    {
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        HealthSlider.maxValue = PlayerHealth.GetHealth();
    }
    
    void Update()
    {
        HealthSlider.value = PlayerHealth.GetHealth();
        ScoreText.text = ScoreKeeper.GetScore().ToString("00000000");
    }
}
