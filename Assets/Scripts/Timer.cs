using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30.0f;
    [SerializeField] float timeToShowCorrectAnswer = 10.0f;

    public bool loadNextQuestion;
    public float fillFraction;

    bool isAnsweringQuestion;
    float timerValue;
    
    void Update()
    {
        
    }
}
