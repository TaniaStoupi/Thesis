using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionDataHraion", menuName = "HraionQuestionData" )]


public class HraionQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answershraion;
        public int correctAnswer;
    }

    public Question[] questionshraion;
    
}
