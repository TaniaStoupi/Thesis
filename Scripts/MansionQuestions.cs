using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionData", menuName = "MansionQuestionData" )]


public class MansionQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswer;
    }

    public Question[] questions;
    
}
