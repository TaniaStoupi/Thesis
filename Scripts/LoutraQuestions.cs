using UnityEngine;

[CreateAssetMenu(fileName = "Loutra QuestionData", menuName = "LoutraQuestionData" )]


public class LoutraQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answersloutra;
        public int correctAnswer;
    }

    public Question[] questionsloutra;
    
}
