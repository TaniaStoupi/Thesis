using UnityEngine;

[CreateAssetMenu(fileName = "Sotiros QuestionData", menuName = "SotirosQuestionData" )]


public class SotirosQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answerssotiros;
        public int correctAnswer;
    }

    public Question[] questionssotiros;
    
}
