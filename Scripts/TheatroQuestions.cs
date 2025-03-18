using UnityEngine;

[CreateAssetMenu(fileName = "Theatro QuestionData", menuName = "TheatroQuestionData" )]


public class TheatroQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answerstheatro;
        public int correctAnswer;
    }

    public Question[] questionstheatro;
    
}
