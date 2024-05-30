using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper ScoreKeeper;

    void Awake()
    {
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "You scored:\n" + ScoreKeeper.GetScore();
    }
    
}
