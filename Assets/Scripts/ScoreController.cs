using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    int updateCalls = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        updateCalls++;

        if (updateCalls % 2 == 0) 
        { 
            score++;
            scoreText.text = score.ToString() + " pts";
        }
    }
}
