using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;  // grab the question text object
    [SerializeField] QuestionSO question;           // variable into which the (scriptable object) question is loaded
    [SerializeField] GameObject[] answerButtons;    // grab the answer button objects
    
    int correctAnswerIndex = 0;                     // 
    
    [SerializeField] Sprite defaultAnswerSprite;    // variable into which an answer button sprite image asset will loaded
    [SerializeField] Sprite correctAnswerSprite;    // variable into which an answer button sprite image asset will loaded

    void Start()
    {
        GetNextQuestion();
    }

    private void SetTextComponents()
    {
        questionText.text = question.GetQuestion(); // set the question text

        // here the answers are fetched from the QuestionSO and loaded into the buttons' text component
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // using the GetComponentInChildren<>() function to fetch the text component of the buttons
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }

        correctAnswerIndex = question.GetCorrectAnswerIndex();
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // grab the Button component of each answerButton
            Button button = answerButtons[i].GetComponent<Button>();

            // and set it interactable or not
            button.interactable = state;
        }
    }

    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        SetTextComponents();
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    // function to be mapped as the response to a button click
    public void OnAnswerSelected(int index)
    {
        // index is the parameter indicating which button was pressed - set in Unity editor
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!"; // self explanatory
            Image buttonImage = answerButtons[index].GetComponent<Image>(); // fetch the sprite used for the button
            buttonImage.sprite = correctAnswerSprite;   // and change it
        }
        else
        {
            // set question text to phrase + the correct answer
            questionText.text = "Sorry, the correct answer is " + question.GetAnswer(correctAnswerIndex);

            // fetch the image of the correct answer button
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();

            // anad change it to the correctAnswerSprite
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }
}
