using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question test here";

    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 0;

    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        if (index >= 0 && index < answers.Length)
        {
            return answers[index];
        }

        return "<invalid index>";
    }
}
